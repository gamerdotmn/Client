namespace Client
{
    partial class Loginfrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Loginfrm));
            this.label_pcname = new System.Windows.Forms.Label();
            this.panel_main = new System.Windows.Forms.Panel();
            this.labelerr_member = new Client.Labelerr();
            this.labelerr_timecode = new Client.Labelerr();
            this.button_user = new System.Windows.Forms.Button();
            this.textBox_password = new System.Windows.Forms.TextBox();
            this.textBox_user = new System.Windows.Forms.TextBox();
            this.textBox_timecode = new System.Windows.Forms.TextBox();
            this.button_timecode = new System.Windows.Forms.Button();
            this.panel_main.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_pcname
            // 
            this.label_pcname.AutoSize = true;
            this.label_pcname.BackColor = System.Drawing.Color.Transparent;
            this.label_pcname.Font = new System.Drawing.Font("Impact", 40F, System.Drawing.FontStyle.Bold);
            this.label_pcname.ForeColor = System.Drawing.Color.White;
            this.label_pcname.Location = new System.Drawing.Point(591, 10);
            this.label_pcname.Name = "label_pcname";
            this.label_pcname.Size = new System.Drawing.Size(0, 66);
            this.label_pcname.TabIndex = 1;
            // 
            // panel_main
            // 
            this.panel_main.BackColor = System.Drawing.Color.Transparent;
            this.panel_main.BackgroundImage = global::Client.Properties.Resources.subback;
            this.panel_main.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel_main.Controls.Add(this.labelerr_member);
            this.panel_main.Controls.Add(this.labelerr_timecode);
            this.panel_main.Controls.Add(this.button_user);
            this.panel_main.Controls.Add(this.textBox_password);
            this.panel_main.Controls.Add(this.textBox_user);
            this.panel_main.Controls.Add(this.textBox_timecode);
            this.panel_main.Controls.Add(this.button_timecode);
            this.panel_main.Location = new System.Drawing.Point(160, 60);
            this.panel_main.Name = "panel_main";
            this.panel_main.Size = new System.Drawing.Size(480, 480);
            this.panel_main.TabIndex = 2;
            // 
            // labelerr_member
            // 
            this.labelerr_member.AutoSize = true;
            this.labelerr_member.ForeColor = System.Drawing.Color.White;
            this.labelerr_member.Location = new System.Drawing.Point(40, 427);
            this.labelerr_member.Name = "labelerr_member";
            this.labelerr_member.Size = new System.Drawing.Size(0, 13);
            this.labelerr_member.TabIndex = 7;
            // 
            // labelerr_timecode
            // 
            this.labelerr_timecode.AutoSize = true;
            this.labelerr_timecode.ForeColor = System.Drawing.Color.White;
            this.labelerr_timecode.Location = new System.Drawing.Point(40, 170);
            this.labelerr_timecode.Name = "labelerr_timecode";
            this.labelerr_timecode.Size = new System.Drawing.Size(0, 13);
            this.labelerr_timecode.TabIndex = 6;
            // 
            // button_user
            // 
            this.button_user.Enabled = false;
            this.button_user.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_user.Location = new System.Drawing.Point(393, 366);
            this.button_user.Name = "button_user";
            this.button_user.Size = new System.Drawing.Size(75, 23);
            this.button_user.TabIndex = 5;
            this.button_user.Text = "Нэвтрэх";
            this.button_user.UseVisualStyleBackColor = true;
            // 
            // textBox_password
            // 
            this.textBox_password.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_password.Location = new System.Drawing.Point(268, 340);
            this.textBox_password.Name = "textBox_password";
            this.textBox_password.Size = new System.Drawing.Size(200, 20);
            this.textBox_password.TabIndex = 4;
            this.textBox_password.UseSystemPasswordChar = true;
            this.textBox_password.TextChanged += new System.EventHandler(this.textBox_password_TextChanged);
            // 
            // textBox_user
            // 
            this.textBox_user.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_user.Location = new System.Drawing.Point(268, 301);
            this.textBox_user.Name = "textBox_user";
            this.textBox_user.Size = new System.Drawing.Size(200, 20);
            this.textBox_user.TabIndex = 3;
            this.textBox_user.TextChanged += new System.EventHandler(this.textBox_user_TextChanged);
            // 
            // textBox_timecode
            // 
            this.textBox_timecode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_timecode.Location = new System.Drawing.Point(268, 94);
            this.textBox_timecode.Name = "textBox_timecode";
            this.textBox_timecode.Size = new System.Drawing.Size(200, 20);
            this.textBox_timecode.TabIndex = 1;
            this.textBox_timecode.UseSystemPasswordChar = true;
            this.textBox_timecode.TextChanged += new System.EventHandler(this.textBox_timecode_TextChanged);
            // 
            // button_timecode
            // 
            this.button_timecode.Enabled = false;
            this.button_timecode.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_timecode.Location = new System.Drawing.Point(393, 120);
            this.button_timecode.Name = "button_timecode";
            this.button_timecode.Size = new System.Drawing.Size(75, 23);
            this.button_timecode.TabIndex = 2;
            this.button_timecode.Text = "Нэвтрэх";
            this.button_timecode.UseVisualStyleBackColor = true;
            // 
            // Loginfrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = global::Client.Properties.Resources.b;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.ControlBox = false;
            this.Controls.Add(this.panel_main);
            this.Controls.Add(this.label_pcname);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Loginfrm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Loginfrm_FormClosing);
            this.panel_main.ResumeLayout(false);
            this.panel_main.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_pcname;
        public System.Windows.Forms.Panel panel_main;
        public System.Windows.Forms.Button button_user;
        public System.Windows.Forms.TextBox textBox_password;
        public System.Windows.Forms.TextBox textBox_user;
        public System.Windows.Forms.TextBox textBox_timecode;
        public System.Windows.Forms.Button button_timecode;
        public Labelerr labelerr_member;
        public Labelerr labelerr_timecode;
    }
}