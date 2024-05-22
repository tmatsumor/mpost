using System.Configuration;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace mpost
{
    public partial class frmMPost : Form
    {
        string? twitter_token;
        string? slack_token;
        string? slack_channel;
        public frmMPost()
        {
            InitializeComponent();

            twitter_token = ConfigurationManager.AppSettings["twitter_access_token"];
            slack_token   = ConfigurationManager.AppSettings["slack_access_token"];
            slack_channel = ConfigurationManager.AppSettings["slack_channel_name"];
            var msg = (twitter_token == null) ? "twitter_access_token の取得に失敗しました"
                : (slack_token == null)?        "slack_access_token の取得に失敗しました"
                : (slack_channel == null)?      "slack_channel_name の取得に失敗しました"
                : string.Empty;

            if (msg != string.Empty)            // 設定ファイルにキーがない場合は起動中止
            {
                MessageBox.Show(msg);
                throw new Exception(msg);
            }
        }

        async private void btnPost_Click(object sender, EventArgs e)
        {
            var txt = txtMessage.Text.Trim().Replace("\r\n", "\\n");  // JSON用に改行置換

            var dialog = MessageBox.Show("投稿します。よろしいですか？",
                "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (dialog == DialogResult.OK)
            {
                if(chkTwitter.Checked)
                {
                    var res = await PostToTwitter(txt);
                    System.Diagnostics.Debug.WriteLine(res);
                }

                if (chkSlack.Checked)
                {
                    var res = await PostToSlack(txt);
                    System.Diagnostics.Debug.WriteLine(res);
                }
            }
        }

        async private Task<string> PostToTwitter(string txt)
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
    }
}
