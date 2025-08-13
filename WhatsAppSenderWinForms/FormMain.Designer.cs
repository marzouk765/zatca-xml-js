namespace WhatsAppSenderWinForms
{
    partial class FormMain
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label labelAccessToken;
        private System.Windows.Forms.TextBox txtAccessToken;
        private System.Windows.Forms.Label labelPhoneNumberId;
        private System.Windows.Forms.TextBox txtPhoneNumberId;
        private System.Windows.Forms.Label labelRecipient;
        private System.Windows.Forms.TextBox txtRecipient;
        private System.Windows.Forms.Label labelMessage;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txtResponse;
        private System.Windows.Forms.Label labelResponse;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.labelAccessToken = new System.Windows.Forms.Label();
            this.txtAccessToken = new System.Windows.Forms.TextBox();
            this.labelPhoneNumberId = new System.Windows.Forms.Label();
            this.txtPhoneNumberId = new System.Windows.Forms.TextBox();
            this.labelRecipient = new System.Windows.Forms.Label();
            this.txtRecipient = new System.Windows.Forms.TextBox();
            this.labelMessage = new System.Windows.Forms.Label();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.txtResponse = new System.Windows.Forms.TextBox();
            this.labelResponse = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelAccessToken
            // 
            this.labelAccessToken.AutoSize = true;
            this.labelAccessToken.Location = new System.Drawing.Point(12, 15);
            this.labelAccessToken.Name = "labelAccessToken";
            this.labelAccessToken.Size = new System.Drawing.Size(98, 15);
            this.labelAccessToken.TabIndex = 0;
            this.labelAccessToken.Text = "Access Token:";
            // 
            // txtAccessToken
            // 
            this.txtAccessToken.Location = new System.Drawing.Point(140, 12);
            this.txtAccessToken.Name = "txtAccessToken";
            this.txtAccessToken.Size = new System.Drawing.Size(520, 23);
            this.txtAccessToken.TabIndex = 1;
            this.txtAccessToken.UseSystemPasswordChar = true;
            // 
            // labelPhoneNumberId
            // 
            this.labelPhoneNumberId.AutoSize = true;
            this.labelPhoneNumberId.Location = new System.Drawing.Point(12, 50);
            this.labelPhoneNumberId.Name = "labelPhoneNumberId";
            this.labelPhoneNumberId.Size = new System.Drawing.Size(111, 15);
            this.labelPhoneNumberId.TabIndex = 2;
            this.labelPhoneNumberId.Text = "Phone Number ID:";
            // 
            // txtPhoneNumberId
            // 
            this.txtPhoneNumberId.Location = new System.Drawing.Point(140, 47);
            this.txtPhoneNumberId.Name = "txtPhoneNumberId";
            this.txtPhoneNumberId.Size = new System.Drawing.Size(520, 23);
            this.txtPhoneNumberId.TabIndex = 3;
            // 
            // labelRecipient
            // 
            this.labelRecipient.AutoSize = true;
            this.labelRecipient.Location = new System.Drawing.Point(12, 85);
            this.labelRecipient.Name = "labelRecipient";
            this.labelRecipient.Size = new System.Drawing.Size(123, 15);
            this.labelRecipient.TabIndex = 4;
            this.labelRecipient.Text = "Recipient (E.164):";
            // 
            // txtRecipient
            // 
            this.txtRecipient.Location = new System.Drawing.Point(140, 82);
            this.txtRecipient.Name = "txtRecipient";
            this.txtRecipient.PlaceholderText = "مثال: 15551234567";
            this.txtRecipient.Size = new System.Drawing.Size(520, 23);
            this.txtRecipient.TabIndex = 5;
            // 
            // labelMessage
            // 
            this.labelMessage.AutoSize = true;
            this.labelMessage.Location = new System.Drawing.Point(12, 120);
            this.labelMessage.Name = "labelMessage";
            this.labelMessage.Size = new System.Drawing.Size(59, 15);
            this.labelMessage.TabIndex = 6;
            this.labelMessage.Text = "Message:";
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(140, 117);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMessage.Size = new System.Drawing.Size(520, 120);
            this.txtMessage.TabIndex = 7;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(585, 248);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 27);
            this.btnSend.TabIndex = 8;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // labelResponse
            // 
            this.labelResponse.AutoSize = true;
            this.labelResponse.Location = new System.Drawing.Point(12, 290);
            this.labelResponse.Name = "labelResponse";
            this.labelResponse.Size = new System.Drawing.Size(65, 15);
            this.labelResponse.TabIndex = 9;
            this.labelResponse.Text = "Response:";
            // 
            // txtResponse
            // 
            this.txtResponse.Location = new System.Drawing.Point(12, 308);
            this.txtResponse.Multiline = true;
            this.txtResponse.Name = "txtResponse";
            this.txtResponse.ReadOnly = true;
            this.txtResponse.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResponse.Size = new System.Drawing.Size(648, 160);
            this.txtResponse.TabIndex = 10;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(672, 480);
            this.Controls.Add(this.txtResponse);
            this.Controls.Add(this.labelResponse);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.labelMessage);
            this.Controls.Add(this.txtRecipient);
            this.Controls.Add(this.labelRecipient);
            this.Controls.Add(this.txtPhoneNumberId);
            this.Controls.Add(this.labelPhoneNumberId);
            this.Controls.Add(this.txtAccessToken);
            this.Controls.Add(this.labelAccessToken);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WhatsApp Sender (Cloud API)";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}