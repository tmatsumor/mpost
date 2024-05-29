using System.Configuration;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;

namespace mpost
{
    public partial class frmMPost : Form
    {
        string slack_token;
        string slack_channel;
        string twitter_token_json_path;
        [DataContract] //�f�[�^�R���g���N�g����
        public partial class JsonData
        {
            [DataMember(Name = "access_token")] //�f�[�^�����o����
            public string? AccessToken { get; set; }
        }

        public frmMPost()
        {
            InitializeComponent();

            slack_token   = ConfigurationManager.AppSettings["slack_access_token"] ?? "";
            slack_channel = ConfigurationManager.AppSettings["slack_channel_name"] ?? "";
            twitter_token_json_path = ConfigurationManager.AppSettings["twitter_token_json_path"] ?? "";
            var msg = (slack_token.Length == 0)?    "slack_access_token �̎擾�Ɏ��s���܂���"
                : (slack_channel.Length == 0)?      "slack_channel_name �̎擾�Ɏ��s���܂���"
                : (twitter_token_json_path.Length == 0)? "twitter_token_json_path �̎擾�Ɏ��s���܂���"
                : string.Empty;

            if (msg != string.Empty)            // �ݒ�t�@�C���ɃL�[���Ȃ��ꍇ�͋N�����~
            {
                MessageBox.Show(msg);
                throw new Exception(msg);
            }
        }

        async private void btnPost_Click(object sender, EventArgs e)
        {
            try
            {
                var txt = txtMessage.Text.Trim().Replace(@"\", @"\\").Replace("\"", "\\\"").Replace("\r\n", "\\n");

                var dialog = MessageBox.Show("���e���܂��B��낵���ł����H",
                    "�m�F", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (dialog == DialogResult.OK)
                {
                    if (chkTwitter.Checked)
                    {
                        var twitter_token = getTwitterAccessTokenFromJsonFile(twitter_token_json_path);
                        var res = await PostToTwitter(txt.Replace("```", ""), twitter_token);
                        System.Diagnostics.Debug.WriteLine(res);
                    }

                    if (chkSlack.Checked)
                    {
                        var res = await PostToSlack(txt);
                        System.Diagnostics.Debug.WriteLine(res);
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
            ms.Seek(0, SeekOrigin.Begin); // �X�g���[���̐擪
            var data = serializer.ReadObject(ms) as JsonData;
            return data?.AccessToken;
        }
    }
}
