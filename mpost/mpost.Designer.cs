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
            components = new System.ComponentModel.Container();
            btnPost = new Button();
            chkSlack = new CheckBox();
            chkTwitter = new CheckBox();
            lblCurrentWC = new Label();
            lblMaxWC = new Label();
            lblPet = new Label();
            cmsPet = new ContextMenuStrip(components);
            tsmItemPreviousPost = new ToolStripMenuItem();
            txtMessage = new TextBox();
            tsmItemClear = new ToolStripMenuItem();
            cmsPet.SuspendLayout();
            SuspendLayout();
            // 
            // btnPost
            // 
            btnPost.Enabled = false;
            btnPost.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            btnPost.Location = new Point(501, 119);
            btnPost.Name = "btnPost";
            btnPost.Size = new Size(75, 34);
            btnPost.TabIndex = 0;
            btnPost.Text = "投稿";
            btnPost.UseVisualStyleBackColor = true;
            btnPost.Click += btnPost_Click;
            // 
            // chkSlack
            // 
            chkSlack.AutoSize = true;
            chkSlack.Checked = true;
            chkSlack.CheckState = CheckState.Checked;
            chkSlack.Font = new Font("Yu Gothic UI", 12F);
            chkSlack.Location = new Point(144, 123);
            chkSlack.Name = "chkSlack";
            chkSlack.Size = new Size(65, 25);
            chkSlack.TabIndex = 1;
            chkSlack.Text = "Slack";
            chkSlack.UseVisualStyleBackColor = true;
            // 
            // chkTwitter
            // 
            chkTwitter.AutoSize = true;
            chkTwitter.Checked = true;
            chkTwitter.CheckState = CheckState.Checked;
            chkTwitter.Font = new Font("Yu Gothic UI", 12F);
            chkTwitter.Location = new Point(63, 123);
            chkTwitter.Name = "chkTwitter";
            chkTwitter.Size = new Size(76, 25);
            chkTwitter.TabIndex = 1;
            chkTwitter.Text = "Twitter";
            chkTwitter.UseVisualStyleBackColor = true;
            // 
            // lblCurrentWC
            // 
            lblCurrentWC.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblCurrentWC.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            lblCurrentWC.Location = new Point(410, 123);
            lblCurrentWC.Name = "lblCurrentWC";
            lblCurrentWC.Size = new Size(41, 23);
            lblCurrentWC.TabIndex = 2;
            lblCurrentWC.Text = "0";
            lblCurrentWC.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblMaxWC
            // 
            lblMaxWC.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblMaxWC.AutoSize = true;
            lblMaxWC.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            lblMaxWC.Location = new Point(448, 124);
            lblMaxWC.Name = "lblMaxWC";
            lblMaxWC.Size = new Size(47, 21);
            lblMaxWC.TabIndex = 2;
            lblMaxWC.Text = "/ 140";
            // 
            // lblPet
            // 
            lblPet.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblPet.AutoSize = true;
            lblPet.BackColor = Color.Transparent;
            lblPet.ContextMenuStrip = cmsPet;
            lblPet.Font = new Font("Yu Gothic UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            lblPet.Location = new Point(4, 112);
            lblPet.Name = "lblPet";
            lblPet.Size = new Size(54, 37);
            lblPet.TabIndex = 2;
            lblPet.Text = "🐢";
            // 
            // cmsPet
            // 
            cmsPet.Items.AddRange(new ToolStripItem[] { tsmItemPreviousPost, tsmItemClear });
            cmsPet.Name = "cmsPet";
            cmsPet.Size = new Size(175, 48);
            // 
            // tsmItemPreviousPost
            // 
            tsmItemPreviousPost.Name = "tsmItemPreviousPost";
            tsmItemPreviousPost.Size = new Size(174, 22);
            tsmItemPreviousPost.Text = "一つ前の投稿を表示";
            tsmItemPreviousPost.Click += tsmItemPreviousPost_Click;
            // 
            // txtMessage
            // 
            txtMessage.BackColor = Color.White;
            txtMessage.Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            txtMessage.ForeColor = Color.Black;
            txtMessage.ImeMode = ImeMode.On;
            txtMessage.Location = new Point(2, 2);
            txtMessage.Multiline = true;
            txtMessage.Name = "txtMessage";
            txtMessage.PlaceholderText = "ここに投稿する内容を書きます";
            txtMessage.Size = new Size(580, 111);
            txtMessage.TabIndex = 0;
            txtMessage.TextChanged += txtMessage_TextChanged;
            // 
            // tsmItemClear
            // 
            tsmItemClear.Name = "tsmItemClear";
            tsmItemClear.Size = new Size(174, 22);
            tsmItemClear.Text = "クリア";
            tsmItemClear.Click += tsmItemClear_Click;
            // 
            // frmMPost
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = SystemColors.Control;
            ClientSize = new Size(584, 157);
            Controls.Add(txtMessage);
            Controls.Add(lblPet);
            Controls.Add(lblMaxWC);
            Controls.Add(btnPost);
            Controls.Add(lblCurrentWC);
            Controls.Add(chkSlack);
            Controls.Add(chkTwitter);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmMPost";
            ShowIcon = false;
            SizeGripStyle = SizeGripStyle.Hide;
            Text = "mpost";
            TopMost = true;
            cmsPet.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnPost;
        private CheckBox chkSlack;
        private CheckBox chkTwitter;
        private Label lblCurrentWC;
        private Label lblMaxWC;
        private Label lblPet;
        private TextBox txtMessage;
        private ContextMenuStrip cmsPet;
        private ToolStripMenuItem tsmItemPreviousPost;
        private ToolStripMenuItem tsmItemClear;
    }
}
