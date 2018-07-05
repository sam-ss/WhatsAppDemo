namespace WhatesAppDemo
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.grpMedia = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblUrlThumb = new System.Windows.Forms.Label();
            this.txtUrlThumb = new System.Windows.Forms.TextBox();
            this.txtCaption = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtMediaImageUrl = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbLink = new System.Windows.Forms.RadioButton();
            this.rbImage = new System.Windows.Forms.RadioButton();
            this.rbMessage = new System.Windows.Forms.RadioButton();
            this.rbVideo = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCustomUid = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtResponceStatus = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMobileNumber = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label7 = new System.Windows.Forms.Label();
            this.txtUserId = new System.Windows.Forms.TextBox();
            this.btnCheckStatus = new System.Windows.Forms.Button();
            this.txtStatusResult = new System.Windows.Forms.TextBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.txtUid = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtToken = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.grpMedia.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(896, 578);
            this.tabControl1.TabIndex = 7;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.DarkGray;
            this.tabPage1.Controls.Add(this.grpMedia);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.txtCustomUid);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.txtResponceStatus);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.txtMessage);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.txtMobileNumber);
            this.tabPage1.Controls.Add(this.btnSend);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(888, 552);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Send Message";
            // 
            // grpMedia
            // 
            this.grpMedia.Controls.Add(this.label11);
            this.grpMedia.Controls.Add(this.groupBox2);
            this.grpMedia.Controls.Add(this.txtMediaImageUrl);
            this.grpMedia.Location = new System.Drawing.Point(379, 74);
            this.grpMedia.Name = "grpMedia";
            this.grpMedia.Size = new System.Drawing.Size(332, 179);
            this.grpMedia.TabIndex = 29;
            this.grpMedia.TabStop = false;
            this.grpMedia.Text = "Image/ Video Parameter";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(13, 30);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(99, 13);
            this.label11.TabIndex = 23;
            this.label11.Text = "URL Image/ Video:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblUrlThumb);
            this.groupBox2.Controls.Add(this.txtUrlThumb);
            this.groupBox2.Controls.Add(this.txtCaption);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.txtDescription);
            this.groupBox2.Location = new System.Drawing.Point(16, 72);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(305, 97);
            this.groupBox2.TabIndex = 28;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Optional Parameter";
            // 
            // lblUrlThumb
            // 
            this.lblUrlThumb.AutoSize = true;
            this.lblUrlThumb.Location = new System.Drawing.Point(13, 73);
            this.lblUrlThumb.Name = "lblUrlThumb";
            this.lblUrlThumb.Size = new System.Drawing.Size(52, 13);
            this.lblUrlThumb.TabIndex = 29;
            this.lblUrlThumb.Text = "Url thumb";
            // 
            // txtUrlThumb
            // 
            this.txtUrlThumb.Location = new System.Drawing.Point(102, 70);
            this.txtUrlThumb.Name = "txtUrlThumb";
            this.txtUrlThumb.Size = new System.Drawing.Size(197, 20);
            this.txtUrlThumb.TabIndex = 28;
            // 
            // txtCaption
            // 
            this.txtCaption.Location = new System.Drawing.Point(102, 18);
            this.txtCaption.Name = "txtCaption";
            this.txtCaption.Size = new System.Drawing.Size(197, 20);
            this.txtCaption.TabIndex = 24;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(13, 47);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(63, 13);
            this.label13.TabIndex = 27;
            this.label13.Text = "Description:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(13, 21);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(49, 13);
            this.label12.TabIndex = 25;
            this.label12.Text = "Caption :";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(102, 44);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(197, 20);
            this.txtDescription.TabIndex = 26;
            // 
            // txtMediaImageUrl
            // 
            this.txtMediaImageUrl.Location = new System.Drawing.Point(118, 30);
            this.txtMediaImageUrl.Multiline = true;
            this.txtMediaImageUrl.Name = "txtMediaImageUrl";
            this.txtMediaImageUrl.Size = new System.Drawing.Size(197, 36);
            this.txtMediaImageUrl.TabIndex = 22;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbLink);
            this.groupBox1.Controls.Add(this.rbImage);
            this.groupBox1.Controls.Add(this.rbMessage);
            this.groupBox1.Controls.Add(this.rbVideo);
            this.groupBox1.Location = new System.Drawing.Point(140, 136);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(134, 132);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Options";
            // 
            // rbLink
            // 
            this.rbLink.AutoSize = true;
            this.rbLink.Location = new System.Drawing.Point(16, 67);
            this.rbLink.Name = "rbLink";
            this.rbLink.Size = new System.Drawing.Size(73, 17);
            this.rbLink.TabIndex = 19;
            this.rbLink.Text = "Send Link";
            this.rbLink.UseVisualStyleBackColor = true;
            this.rbLink.CheckedChanged += new System.EventHandler(this.rbLink_CheckedChanged);
            // 
            // rbImage
            // 
            this.rbImage.AutoSize = true;
            this.rbImage.Location = new System.Drawing.Point(16, 44);
            this.rbImage.Name = "rbImage";
            this.rbImage.Size = new System.Drawing.Size(82, 17);
            this.rbImage.TabIndex = 17;
            this.rbImage.Text = "Send Image";
            this.rbImage.UseVisualStyleBackColor = true;
            this.rbImage.CheckedChanged += new System.EventHandler(this.rbImage_CheckedChanged);
            // 
            // rbMessage
            // 
            this.rbMessage.AutoSize = true;
            this.rbMessage.Checked = true;
            this.rbMessage.Location = new System.Drawing.Point(16, 21);
            this.rbMessage.Name = "rbMessage";
            this.rbMessage.Size = new System.Drawing.Size(96, 17);
            this.rbMessage.TabIndex = 16;
            this.rbMessage.TabStop = true;
            this.rbMessage.Text = "Send Message";
            this.rbMessage.UseVisualStyleBackColor = true;
            this.rbMessage.CheckedChanged += new System.EventHandler(this.rbMessage_CheckedChanged);
            // 
            // rbVideo
            // 
            this.rbVideo.AutoSize = true;
            this.rbVideo.Location = new System.Drawing.Point(16, 90);
            this.rbVideo.Name = "rbVideo";
            this.rbVideo.Size = new System.Drawing.Size(80, 17);
            this.rbVideo.TabIndex = 18;
            this.rbVideo.Text = "Send Video";
            this.rbVideo.UseVisualStyleBackColor = true;
            this.rbVideo.CheckedChanged += new System.EventHandler(this.rbVideo_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(390, 41);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Custom Uid :";
            // 
            // txtCustomUid
            // 
            this.txtCustomUid.Location = new System.Drawing.Point(497, 38);
            this.txtCustomUid.Name = "txtCustomUid";
            this.txtCustomUid.Size = new System.Drawing.Size(179, 20);
            this.txtCustomUid.TabIndex = 14;
            this.txtCustomUid.Text = "msg-8107";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(390, 263);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Response Status:";
            // 
            // txtResponceStatus
            // 
            this.txtResponceStatus.Location = new System.Drawing.Point(497, 259);
            this.txtResponceStatus.Multiline = true;
            this.txtResponceStatus.Name = "txtResponceStatus";
            this.txtResponceStatus.ReadOnly = true;
            this.txtResponceStatus.Size = new System.Drawing.Size(197, 107);
            this.txtResponceStatus.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(78, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Message :";
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(140, 74);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(214, 53);
            this.txtMessage.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Mobile Number :";
            // 
            // txtMobileNumber
            // 
            this.txtMobileNumber.Location = new System.Drawing.Point(140, 38);
            this.txtMobileNumber.Name = "txtMobileNumber";
            this.txtMobileNumber.Size = new System.Drawing.Size(214, 20);
            this.txtMobileNumber.TabIndex = 8;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(140, 285);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(179, 33);
            this.btnSend.TabIndex = 7;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.DarkGray;
            this.tabPage3.Controls.Add(this.label7);
            this.tabPage3.Controls.Add(this.txtUserId);
            this.tabPage3.Controls.Add(this.btnCheckStatus);
            this.tabPage3.Controls.Add(this.txtStatusResult);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(888, 552);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Check Account Status";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(122, 87);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Uid :";
            // 
            // txtUserId
            // 
            this.txtUserId.Location = new System.Drawing.Point(169, 84);
            this.txtUserId.Name = "txtUserId";
            this.txtUserId.Size = new System.Drawing.Size(214, 20);
            this.txtUserId.TabIndex = 10;
            // 
            // btnCheckStatus
            // 
            this.btnCheckStatus.Location = new System.Drawing.Point(169, 132);
            this.btnCheckStatus.Name = "btnCheckStatus";
            this.btnCheckStatus.Size = new System.Drawing.Size(214, 37);
            this.btnCheckStatus.TabIndex = 1;
            this.btnCheckStatus.Text = "Check Account Status";
            this.btnCheckStatus.UseVisualStyleBackColor = true;
            this.btnCheckStatus.Click += new System.EventHandler(this.btnCheckStatus_Click);
            // 
            // txtStatusResult
            // 
            this.txtStatusResult.Location = new System.Drawing.Point(405, 84);
            this.txtStatusResult.Multiline = true;
            this.txtStatusResult.Name = "txtStatusResult";
            this.txtStatusResult.Size = new System.Drawing.Size(270, 125);
            this.txtStatusResult.TabIndex = 0;
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.Color.Gray;
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(888, 552);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Message Recived";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.DarkGray;
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.txtUid);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.txtToken);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(888, 552);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Constants";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(39, 76);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Uid :";
            // 
            // txtUid
            // 
            this.txtUid.Location = new System.Drawing.Point(89, 73);
            this.txtUid.Name = "txtUid";
            this.txtUid.Size = new System.Drawing.Size(179, 20);
            this.txtUid.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(39, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Token :";
            // 
            // txtToken
            // 
            this.txtToken.Location = new System.Drawing.Point(89, 35);
            this.txtToken.Name = "txtToken";
            this.txtToken.Size = new System.Drawing.Size(179, 20);
            this.txtToken.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(920, 602);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.grpMedia.ResumeLayout(false);
            this.grpMedia.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtResponceStatus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMobileNumber;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtUid;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtToken;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCustomUid;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbImage;
        private System.Windows.Forms.RadioButton rbMessage;
        private System.Windows.Forms.RadioButton rbVideo;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtCaption;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtMediaImageUrl;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox grpMedia;
        private System.Windows.Forms.RadioButton rbLink;
        private System.Windows.Forms.Label lblUrlThumb;
        private System.Windows.Forms.TextBox txtUrlThumb;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtUserId;
        private System.Windows.Forms.Button btnCheckStatus;
        private System.Windows.Forms.TextBox txtStatusResult;
    }
}

