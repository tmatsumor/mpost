namespace mpost
{
    partial class frmMPost
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            spcMain = new SplitContainer();
            txtMessage = new TextBox();
            lblPet = new Label();
            lblMaxWC = new Label();
            lblCurrentWC = new Label();
            chkTwitter = new CheckBox();
            chkSlack = new CheckBox();
            btnPost = new Button();
            ((System.ComponentModel.ISupportInitialize)spcMain).BeginInit();
            spcMain.Panel1.SuspendLayout();
            spcMain.Panel2.SuspendLayout();
            spcMain.SuspendLayout();
            SuspendLayout();
            // 
            // spcMain
            // 
            spcMain.Dock = DockStyle.Fill;
            spcMain.FixedPanel = FixedPanel.Panel2;
            spcMain.Location = new Point(0, 0);
            spcMain.Name = "spcMain";
            spcMain.Orientation = Orientation.Horizontal;
            // 
            // spcMain.Panel1
            // 
            spcMain.Panel1.Controls.Add(txtMessage);
            // 
            // spcMain.Panel2
            // 
            spcMain.Panel2.Controls.Add(lblPet);
            spcMain.Panel2.Controls.Add(lblMaxWC);
            spcMain.Panel2.Controls.Add(lblCurrentWC);
            spcMain.Panel2.Controls.Add(chkTwitter);
            spcMain.Panel2.Controls.Add(chkSlack);
            spcMain.Panel2.Controls.Add(btnPost);
            spcMain.Size = new Size(584, 243);
            spcMain.SplitterDistance = 187;
            spcMain.TabIndex = 0;
            // 
            // txtMessage
            // 
            txtMessage.Dock = DockStyle.Fill;
            txtMessage.Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            txtMessage.Location = new Point(0, 0);
            txtMessage.Multiline = true;
            txtMessage.Name = "txtMessage";
            txtMessage.PlaceholderText = "ここに投稿する内容を書きます";
            txtMessage.Size = new Size(584, 187);
            txtMessage.TabIndex = 0;
            // 
            // lblPet
            // 
            lblPet.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblPet.AutoSize = true;
            lblPet.BackColor = Color.Transparent;
            lblPet.Font = new Font("Yu Gothic UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            lblPet.Location = new Point(3, 3);
            lblPet.Name = "lblPet";
            lblPet.Size = new Size(54, 37);
            lblPet.TabIndex = 2;
            lblPet.Text = "🐢";
            // 
            // lblMaxWC
            // 
            lblMaxWC.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblMaxWC.AutoSize = true;
            lblMaxWC.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            lblMaxWC.Location = new Point(442, 16);
            lblMaxWC.Name = "lblMaxWC";
            lblMaxWC.Size = new Size(47, 21);
            lblMaxWC.TabIndex = 2;
            lblMaxWC.Text = "/ 140";
            // 
            // lblCurrentWC
            // 
            lblCurrentWC.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblCurrentWC.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            lblCurrentWC.Location = new Point(404, 15);
            lblCurrentWC.Name = "lblCurrentWC";
            lblCurrentWC.Size = new Size(41, 23);
            lblCurrentWC.TabIndex = 2;
            lblCurrentWC.Text = "0";
            lblCurrentWC.TextAlign = ContentAlignment.MiddleRight;
            // 
            // chkTwitter
            // 
            chkTwitter.AutoSize = true;
            chkTwitter.Checked = true;
            chkTwitter.CheckState = CheckState.Checked;
            chkTwitter.Font = new Font("Yu Gothic UI", 12F);
            chkTwitter.Location = new Point(60, 15);
            chkTwitter.Name = "chkTwitter";
            chkTwitter.Size = new Size(76, 25);
            chkTwitter.TabIndex = 1;
            chkTwitter.Text = "Twitter";
            chkTwitter.UseVisualStyleBackColor = true;
            // 
            // chkSlack
            // 
            chkSlack.AutoSize = true;
            chkSlack.Checked = true;
            chkSlack.CheckState = CheckState.Checked;
            chkSlack.Font = new Font("Yu Gothic UI", 12F);
            chkSlack.Location = new Point(142, 15);
            chkSlack.Name = "chkSlack";
            chkSlack.Size = new Size(65, 25);
            chkSlack.TabIndex = 1;
            chkSlack.Text = "Slack";
            chkSlack.UseVisualStyleBackColor = true;
            // 
            // btnPost
            // 
            btnPost.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            btnPost.Location = new Point(498, 9);
            btnPost.Name = "btnPost";
            btnPost.Size = new Size(75, 34);
            btnPost.TabIndex = 0;
            btnPost.Text = "投稿";
            btnPost.UseVisualStyleBackColor = true;
            btnPost.Click += btnPost_Click;
            // 
            // frmMPost
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(584, 243);
            Controls.Add(spcMain);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmMPost";
            ShowIcon = false;
            SizeGripStyle = SizeGripStyle.Hide;
            Text = "mpost";
            TopMost = true;
            spcMain.Panel1.ResumeLayout(false);
            spcMain.Panel1.PerformLayout();
            spcMain.Panel2.ResumeLayout(false);
            spcMain.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)spcMain).EndInit();
            spcMain.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer spcMain;
        private TextBox txtMessage;
        private CheckBox chkTwitter;
        private CheckBox chkSlack;
        private Button btnPost;
        private Label lblMaxWC;
        private Label lblCurrentWC;
        private Label lblPet;
    }
}
