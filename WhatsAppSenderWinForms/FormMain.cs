using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WhatsAppSenderWinForms
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private async void btnSend_Click(object sender, EventArgs e)
        {
            btnSend.Enabled = false;
            txtResponse.Text = string.Empty;

            string accessToken = txtAccessToken.Text.Trim();
            string phoneNumberId = txtPhoneNumberId.Text.Trim();
            string recipient = txtRecipient.Text.Trim();
            string messageText = txtMessage.Text;

            if (string.IsNullOrWhiteSpace(accessToken) ||
                string.IsNullOrWhiteSpace(phoneNumberId) ||
                string.IsNullOrWhiteSpace(recipient) ||
                string.IsNullOrWhiteSpace(messageText))
            {
                MessageBox.Show("الرجاء تعبئة جميع الحقول.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnSend.Enabled = true;
                return;
            }

            string sanitizedRecipient = new string(recipient.Where(char.IsDigit).ToArray());

            try
            {
                var apiUrl = $"https://graph.facebook.com/v20.0/{phoneNumberId}/messages";

                var payload = new
                {
                    messaging_product = "whatsapp",
                    to = sanitizedRecipient,
                    type = "text",
                    text = new
                    {
                        body = messageText
                    }
                };

                var json = JsonSerializer.Serialize(payload);
                using var httpClient = new HttpClient();
                using var request = new HttpRequestMessage(HttpMethod.Post, apiUrl);

                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                request.Content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await httpClient.SendAsync(request);
                var responseBody = await response.Content.ReadAsStringAsync();

                txtResponse.Text = $"Status: {(int)response.StatusCode} {response.ReasonPhrase}{Environment.NewLine}{responseBody}";

                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show("فشل الإرسال. راجع الاستجابة لمعرفة التفاصيل.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("تم إرسال الرسالة بنجاح.", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                txtResponse.Text = ex.ToString();
                MessageBox.Show("حدث خطأ أثناء الإرسال.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnSend.Enabled = true;
            }
        }
    }
}