namespace Dollars_Chat
{
    partial class Chat
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Chat));
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSend = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.lblConnected = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ChooseVip = new System.Windows.Forms.ComboBox();
            this.lblvipUI = new System.Windows.Forms.Label();
            this.btnPlayMusic = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.lblKick = new System.Windows.Forms.Label();
            this.txtKick = new System.Windows.Forms.TextBox();
            this.btnKick = new System.Windows.Forms.Button();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.chatBubble11 = new Dollars_Chat.ChatBubble1();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            this.SuspendLayout();
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(87, 645);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(398, 20);
            this.txtMessage.TabIndex = 5;
            this.txtMessage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMessage_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(16, 647);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Message: ";
            // 
            // btnSend
            // 
            this.btnSend.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnSend.FlatAppearance.BorderSize = 0;
            this.btnSend.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btnSend.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSend.Image = ((System.Drawing.Image)(resources.GetObject("btnSend.Image")));
            this.btnSend.Location = new System.Drawing.Point(490, 643);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(140, 23);
            this.btnSend.TabIndex = 6;
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.chatBubble11);
            this.panel1.Location = new System.Drawing.Point(1, 99);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(664, 527);
            this.panel1.TabIndex = 7;
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox6.Image")));
            this.pictureBox6.Location = new System.Drawing.Point(159, 22);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(1, 1);
            this.pictureBox6.TabIndex = 24;
            this.pictureBox6.TabStop = false;
            this.pictureBox6.MouseEnter += new System.EventHandler(this.pictureBox6_MouseEnter);
            // 
            // pictureBox5
            // 
            this.pictureBox5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.Location = new System.Drawing.Point(134, 6);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(61, 40);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 23;
            this.pictureBox5.TabStop = false;
            this.pictureBox5.Visible = false;
            this.pictureBox5.Click += new System.EventHandler(this.pictureBox5_Click);
            // 
            // lblConnected
            // 
            this.lblConnected.Font = new System.Drawing.Font("MS Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConnected.ForeColor = System.Drawing.Color.White;
            this.lblConnected.Location = new System.Drawing.Point(14, 64);
            this.lblConnected.Name = "lblConnected";
            this.lblConnected.Size = new System.Drawing.Size(535, 32);
            this.lblConnected.TabIndex = 19;
            this.lblConnected.Text = "label1";
            this.lblConnected.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Black;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-138, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(956, 70);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // ChooseVip
            // 
            this.ChooseVip.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ChooseVip.Enabled = false;
            this.ChooseVip.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ChooseVip.FormattingEnabled = true;
            this.ChooseVip.Items.AddRange(new object[] {
            "Red",
            "Red (Kanji)",
            "Yellow",
            "Yellow (Kanji)",
            "Green",
            "Green (Kanji)",
            "Pink",
            "Black"});
            this.ChooseVip.Location = new System.Drawing.Point(87, 671);
            this.ChooseVip.Name = "ChooseVip";
            this.ChooseVip.Size = new System.Drawing.Size(121, 21);
            this.ChooseVip.TabIndex = 9;
            this.ChooseVip.Text = "Red";
            this.ChooseVip.Visible = false;
            this.ChooseVip.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.YourComboBox_KeyPress);
            // 
            // lblvipUI
            // 
            this.lblvipUI.AutoSize = true;
            this.lblvipUI.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblvipUI.ForeColor = System.Drawing.Color.White;
            this.lblvipUI.Location = new System.Drawing.Point(22, 676);
            this.lblvipUI.Name = "lblvipUI";
            this.lblvipUI.Size = new System.Drawing.Size(46, 15);
            this.lblvipUI.TabIndex = 10;
            this.lblvipUI.Text = "VIP UI: ";
            this.lblvipUI.Visible = false;
            // 
            // btnPlayMusic
            // 
            this.btnPlayMusic.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.btnPlayMusic.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPlayMusic.Enabled = false;
            this.btnPlayMusic.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnPlayMusic.FlatAppearance.BorderSize = 0;
            this.btnPlayMusic.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btnPlayMusic.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnPlayMusic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlayMusic.Image = ((System.Drawing.Image)(resources.GetObject("btnPlayMusic.Image")));
            this.btnPlayMusic.Location = new System.Drawing.Point(468, 696);
            this.btnPlayMusic.Name = "btnPlayMusic";
            this.btnPlayMusic.Size = new System.Drawing.Size(182, 33);
            this.btnPlayMusic.TabIndex = 15;
            this.btnPlayMusic.UseVisualStyleBackColor = true;
            this.btnPlayMusic.Visible = false;
            this.btnPlayMusic.Click += new System.EventHandler(this.btnPlayMusic_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(36, 6);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(72, 41);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 16;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.pictureBox3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(583, 3);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(49, 45);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 17;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox4.Enabled = false;
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(432, 701);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(30, 28);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 18;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Visible = false;
            this.pictureBox4.Click += new System.EventHandler(this.pictureBox4_Click);
            this.pictureBox4.MouseHover += new System.EventHandler(this.pictureBox4_MouseHover);
            // 
            // lblKick
            // 
            this.lblKick.AutoSize = true;
            this.lblKick.Enabled = false;
            this.lblKick.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKick.ForeColor = System.Drawing.Color.White;
            this.lblKick.Location = new System.Drawing.Point(11, 707);
            this.lblKick.Name = "lblKick";
            this.lblKick.Size = new System.Drawing.Size(68, 15);
            this.lblKick.TabIndex = 20;
            this.lblKick.Text = "Kick User: ";
            this.lblKick.Visible = false;
            // 
            // txtKick
            // 
            this.txtKick.Enabled = false;
            this.txtKick.Location = new System.Drawing.Point(87, 705);
            this.txtKick.Name = "txtKick";
            this.txtKick.Size = new System.Drawing.Size(165, 20);
            this.txtKick.TabIndex = 21;
            this.txtKick.Visible = false;
            this.txtKick.WordWrap = false;
            this.txtKick.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtKick_KeyDown);
            // 
            // btnKick
            // 
            this.btnKick.BackColor = System.Drawing.Color.White;
            this.btnKick.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnKick.Enabled = false;
            this.btnKick.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKick.Location = new System.Drawing.Point(258, 703);
            this.btnKick.Name = "btnKick";
            this.btnKick.Size = new System.Drawing.Size(75, 23);
            this.btnKick.TabIndex = 22;
            this.btnKick.Text = "Kick";
            this.btnKick.UseVisualStyleBackColor = false;
            this.btnKick.Visible = false;
            this.btnKick.Click += new System.EventHandler(this.btnKick_Click);
            // 
            // pictureBox7
            // 
            this.pictureBox7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.pictureBox7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox7.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox7.Image")));
            this.pictureBox7.Location = new System.Drawing.Point(525, 3);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(52, 45);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox7.TabIndex = 25;
            this.pictureBox7.TabStop = false;
            this.pictureBox7.Click += new System.EventHandler(this.pictureBox7_Click);
            // 
            // chatBubble11
            // 
            this.chatBubble11.AutoSize = true;
            this.chatBubble11.BackColor = System.Drawing.Color.Black;
            this.chatBubble11.Location = new System.Drawing.Point(10, 29);
            this.chatBubble11.Margin = new System.Windows.Forms.Padding(5);
            this.chatBubble11.Name = "chatBubble11";
            this.chatBubble11.Size = new System.Drawing.Size(619, 118);
            this.chatBubble11.TabIndex = 0;
            this.chatBubble11.Visible = false;
            // 
            // Chat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(665, 747);
            this.Controls.Add(this.pictureBox7);
            this.Controls.Add(this.pictureBox6);
            this.Controls.Add(this.btnKick);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.txtKick);
            this.Controls.Add(this.lblKick);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.lblConnected);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.btnPlayMusic);
            this.Controls.Add(this.lblvipUI);
            this.Controls.Add(this.ChooseVip);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Chat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dollar Chat";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Panel panel1;
        private ChatBubble1 chatBubble11;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox ChooseVip;
        private System.Windows.Forms.Label lblvipUI;
        private System.Windows.Forms.Button btnPlayMusic;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label lblConnected;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label lblKick;
        private System.Windows.Forms.TextBox txtKick;
        private System.Windows.Forms.Button btnKick;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pictureBox7;
    }
}

