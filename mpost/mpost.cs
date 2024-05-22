using System.Configuration;
using System.Text;

namespace mpost
{
    public partial class frmMPost : Form
    {
        string? token;
        public frmMPost()
        {
            InitializeComponent();

            token = ConfigurationManager.AppSettings["twitter_access_token"];
            var msg = (token == null) ? "twitter_access_token の取得に失敗しました"
                : string.Empty;

            if (msg != string.Empty)
            {
                MessageBox.Show(msg);
                throw new Exception(msg);
            }
        }

        async private void btnPost_Click(object sender, EventArgs e)
        {
            var txt = txtMessage.Text.Trim();

            var dialog = MessageBox.Show("投稿します。よろしいですか？",
                "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (dialog == DialogResult.OK)
            {
                if(chkTwitter.Checked)
                {
                    var res = await PostToTwitter(txt);
                    System.Diagnostics.Debug.WriteLine(res);
                }
            }
        }

        async private Task<string> PostToTwitter(string txt)
        {
            var msg = new HttpRequestMessage(HttpMethod.Post, "tweets");
            msg.Headers.Add("Authorization", $"Bearer " + token);
            string body = $@"{{""text"":""{ txt }""}}";
            msg.Content = new StringContent(body, Encoding.UTF8, "application/json");

            using var client = new HttpClient();
            client.BaseAddress = new Uri("https://api.twitter.com/2/");
            var res = await client.SendAsync(msg);
            return await res.Content.ReadAsStringAsync();
        }
    }
}
