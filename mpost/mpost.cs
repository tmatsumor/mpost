﻿using System.Configuration;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using Renci.SshNet;
using Microsoft.ClearScript.V8;
using System.Text.RegularExpressions;
using System.IO;

namespace mpost
{
    public partial class frmMPost : Form
    {
        string slack_token;
        string slack_channel;
        string raspi_host;
        string raspi_port;
        string raspi_user;
        string raspi_private_key_path;
        string raspi_twitter_token_json_path;
        string previous_post_file_name;
        V8ScriptEngine v8;
        [DataContract] //データコントラクト属性
        public partial class JsonData
        {
            [DataMember(Name = "access_token")] //データメンバ属性
            public string? AccessToken { get; set; }
        }

        public frmMPost()
        {
            InitializeComponent();
            lblPet.Text = ConfigurationManager.AppSettings["icon_on_form"] ?? "";  // ペットマークを差替
            previous_post_file_name = ConfigurationManager.AppSettings["previous_post_file_name"] ?? "";

            string tt = File.ReadAllText(@"twitter-text-3.1.0.js");
            v8 = new V8ScriptEngine();
            v8.Execute(tt);

            slack_token = ConfigurationManager.AppSettings["slack_access_token"] ?? "";
            slack_channel = ConfigurationManager.AppSettings["slack_channel_name"] ?? "";
            raspi_host = ConfigurationManager.AppSettings["raspi_host"] ?? "";
            raspi_port = ConfigurationManager.AppSettings["raspi_port"] ?? "";
            raspi_user = ConfigurationManager.AppSettings["raspi_user"] ?? "";
            raspi_private_key_path = ConfigurationManager.AppSettings["raspi_private_key_path"] ?? "";
            raspi_twitter_token_json_path = ConfigurationManager.AppSettings["raspi_twitter_token_json_path"] ?? "";
            var msg = (raspi_host.Length == 0) ? "raspi_host の取得に失敗しました"
                : (raspi_port.Length == 0) ? "raspi_port の取得に失敗しました"
                : (raspi_user.Length == 0) ? "raspi_user の取得に失敗しました"
                : (raspi_private_key_path.Length == 0) ? "raspi_private_key_path の取得に失敗しました"
                : (raspi_twitter_token_json_path.Length == 0) ? "raspi_twitter_token_json_path の取得に失敗しました"
                : (slack_token.Length == 0) ? "slack_access_token の取得に失敗しました"
                : (slack_channel.Length == 0) ? "slack_channel_name の取得に失敗しました"
                : string.Empty;

            if (msg != string.Empty)            // 設定ファイルにキーがない場合は起動中止
            {
                MessageBox.Show(msg);
                throw new Exception(msg);
            }
        }

        async private void btnPost_Click(object sender, EventArgs e)
        {
            const string TWITTER_TOKEN_JSON_PATH = "./twitter_token.json";
            try
            {
                var txt = clean(txtMessage.Text);

                var dialog = MessageBox.Show("投稿します。よろしいですか？",
                    "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (dialog == DialogResult.OK)
                {
                    if (chkTwitter.Checked)
                    {
                        var txtForTwitter = Regex.Replace(txt, @"\\n?```", ""); // Slack用の ``` を除去する
                        downloadTwitterTokenJSON(raspi_private_key_path, raspi_host, raspi_port,
                            raspi_user, TWITTER_TOKEN_JSON_PATH, raspi_twitter_token_json_path);
                        var twitter_token = getTwitterAccessTokenFromJsonFile(TWITTER_TOKEN_JSON_PATH);
                        var res = await PostToTwitter(txtForTwitter, twitter_token);
                        System.Diagnostics.Debug.WriteLine(res);
                    }

                    if (chkSlack.Checked)
                    {
                        var res = await PostToSlack(txt);
                        System.Diagnostics.Debug.WriteLine(res);
                    }

                    if (chkTwitter.Checked || chkSlack.Checked)
                    {
                        if (previous_post_file_name.Length > 0)
                        {
                            File.WriteAllText(previous_post_file_name, txtMessage.Text);  // 投稿内容をファイル保管
                        }
                        txtMessage.Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
                return;
            }
        }

        async private Task<string> PostToTwitter(string txt, string? twitter_token)
        {
            string body = $@"{{""text"":""{txt}""}}";
            return await Post("tweets", body, "https://api.twitter.com/2/", twitter_token);
        }

        async private Task<string> PostToSlack(string txt)
        {
            string body = $@"{{""text"":""{txt}"",""token"":""{slack_token}"",""channel"":""{slack_channel}""}}";
            return await Post("chat.postMessage", body, "https://slack.com/api/", slack_token);
        }

        async private Task<string> Post(string requestUri, string body, string baseAddress, string? token)
        {
            var msg = new HttpRequestMessage(HttpMethod.Post, requestUri);
            if (token != null)
            {
                msg.Headers.Add("Authorization", $"Bearer " + token);
            }
            msg.Content = new StringContent(body, Encoding.UTF8, "application/json");

            using var client = new HttpClient();
            client.BaseAddress = new Uri(baseAddress);
            var res = await client.SendAsync(msg);
            return await res.Content.ReadAsStringAsync();
        }
        private string? getTwitterAccessTokenFromJsonFile(string path)
        {
            var serializer = new DataContractJsonSerializer(typeof(JsonData));
            var json = File.ReadAllText(path);
            var ms = new MemoryStream(Encoding.UTF8.GetBytes((json)));
            ms.Seek(0, SeekOrigin.Begin); // ストリームの先頭
            var data = serializer.ReadObject(ms) as JsonData;
            return data?.AccessToken;
        }

        private void downloadTwitterTokenJSON(string raspi_private_key_path,
            string raspi_host, string raspi_port, string raspi_user,
            string twitter_token_json_path, string raspi_twitter_token_json_path)
        {
            using (var privateKey = new PrivateKeyFile(raspi_private_key_path))
            using (var client = new ScpClient(raspi_host,
                Convert.ToInt32(raspi_port), raspi_user, new[] { privateKey }))
            {
                client.RemotePathTransformation = RemotePathTransformation.ShellQuote;
                client.Connect();
                FileInfo fi = new FileInfo(twitter_token_json_path);
                client.Download(raspi_twitter_token_json_path, fi);
            }
        }

        private void txtMessage_TextChanged(object sender, EventArgs e)
        {
            v8.Execute(@"res = twttr.txt.parseTweet(""" + clean(txtMessage.Text) + @""");");
            dynamic vid = v8.Evaluate("res.valid ");
            btnPost.Enabled = vid;

            var len = v8.Evaluate("res.weightedLength");
            var wc = Math.Ceiling(Convert.ToDecimal(len) / 2);
            lblCurrentWC.Text = wc.ToString();

            if (wc > 140)
            {
                lblMaxWC.ForeColor = Color.Red;
                lblCurrentWC.ForeColor = Color.Red;
            }
            else
            {
                lblMaxWC.ForeColor = Color.Black;
                lblCurrentWC.ForeColor = Color.Black;
            }
        }

        private string clean(string str)
        {
            return str.Trim()
                .Replace(@"\", @"\\")
                .Replace("\"", "\\\"")
                .Replace("\n", "\\n")
                .Replace("\r", "");
        }

        private void tsmItemPreviousPost_Click(object sender, EventArgs e)
        {
            if (previous_post_file_name.Length > 0 && File.Exists(previous_post_file_name))
            {
                txtMessage.Text = File.ReadAllText(previous_post_file_name);
            }
        }

        private void tsmItemClear_Click(object sender, EventArgs e)
        {
            txtMessage.Clear();
        }
    }
}