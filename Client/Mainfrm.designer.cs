namespace Client
{
    partial class Mainfrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Mainfrm));
            this.panel = new System.Windows.Forms.Panel();
            this.button_hide = new System.Windows.Forms.Button();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.button_logout = new System.Windows.Forms.Button();
            this.labelerr_startt = new Client.Labelerr();
            this.label_2 = new System.Windows.Forms.Label();
            this.labelerr_moneyused = new Client.Labelerr();
            this.label_5 = new System.Windows.Forms.Label();
            this.labelerr_remaint = new Client.Labelerr();
            this.label_4 = new System.Windows.Forms.Label();
            this.labelerr_usedt = new Client.Labelerr();
            this.label_3 = new System.Windows.Forms.Label();
            this.labelerr_member = new Client.Labelerr();
            this.label_1 = new System.Windows.Forms.Label();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.msh = new System.Windows.Forms.ToolStripMenuItem();
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            this.panel.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.BackgroundImage = global::Client.Properties.Resources.statusback1;
            this.panel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel.Controls.Add(this.button_hide);
            this.panel.Controls.Add(this.button_logout);
            this.panel.Controls.Add(this.labelerr_startt);
            this.panel.Controls.Add(this.label_2);
            this.panel.Controls.Add(this.labelerr_moneyused);
            this.panel.Controls.Add(this.label_5);
            this.panel.Controls.Add(this.labelerr_remaint);
            this.panel.Controls.Add(this.label_4);
            this.panel.Controls.Add(this.labelerr_usedt);
            this.panel.Controls.Add(this.label_3);
            this.panel.Controls.Add(this.labelerr_member);
            this.panel.Controls.Add(this.label_1);
            this.panel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel.Location = new System.Drawing.Point(0, 325);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(250, 275);
            this.panel.TabIndex = 3;
            // 
            // button_hide
            // 
            this.button_hide.Enabled = false;
            this.button_hide.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_hide.ImageIndex = 1;
            this.button_hide.ImageList = this.imageList;
            this.button_hide.Location = new System.Drawing.Point(25, 45);
            this.button_hide.Name = "button_hide";
            this.button_hide.Size = new System.Drawing.Size(206, 25);
            this.button_hide.TabIndex = 1;
            this.button_hide.TabStop = false;
            this.button_hide.Text = "Нуух (20)";
            this.button_hide.UseVisualStyleBackColor = true;
            this.button_hide.Click += new System.EventHandler(this.button_hide_Click);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "door_out.png");
            this.imageList.Images.SetKeyName(1, "download_for_windows.png");
            // 
            // button_logout
            // 
            this.button_logout.Enabled = false;
            this.button_logout.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_logout.ImageIndex = 0;
            this.button_logout.ImageList = this.imageList;
            this.button_logout.Location = new System.Drawing.Point(25, 75);
            this.button_logout.Name = "button_logout";
            this.button_logout.Size = new System.Drawing.Size(206, 25);
            this.button_logout.TabIndex = 2;
            this.button_logout.TabStop = false;
            this.button_logout.Text = "Гарах";
            this.button_logout.UseVisualStyleBackColor = true;
            this.button_logout.Click += new System.EventHandler(this.button_logout_Click);
            // 
            // labelerr_startt
            // 
            this.labelerr_startt.AutoSize = true;
            this.labelerr_startt.BackColor = System.Drawing.Color.Transparent;
            this.labelerr_startt.ForeColor = System.Drawing.Color.White;
            this.labelerr_startt.Location = new System.Drawing.Point(128, 142);
            this.labelerr_startt.Name = "labelerr_startt";
            this.labelerr_startt.Size = new System.Drawing.Size(0, 13);
            this.labelerr_startt.TabIndex = 11;
            // 
            // label_2
            // 
            this.label_2.AutoSize = true;
            this.label_2.BackColor = System.Drawing.Color.Transparent;
            this.label_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_2.ForeColor = System.Drawing.Color.White;
            this.label_2.Location = new System.Drawing.Point(41, 142);
            this.label_2.Name = "label_2";
            this.label_2.Size = new System.Drawing.Size(84, 13);
            this.label_2.TabIndex = 10;
            this.label_2.Text = "Эхэлсэн цаг:";
            // 
            // labelerr_moneyused
            // 
            this.labelerr_moneyused.AutoSize = true;
            this.labelerr_moneyused.BackColor = System.Drawing.Color.Transparent;
            this.labelerr_moneyused.ForeColor = System.Drawing.Color.White;
            this.labelerr_moneyused.Location = new System.Drawing.Point(128, 229);
            this.labelerr_moneyused.Name = "labelerr_moneyused";
            this.labelerr_moneyused.Size = new System.Drawing.Size(0, 13);
            this.labelerr_moneyused.TabIndex = 9;
            // 
            // label_5
            // 
            this.label_5.AutoSize = true;
            this.label_5.BackColor = System.Drawing.Color.Transparent;
            this.label_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_5.ForeColor = System.Drawing.Color.White;
            this.label_5.Location = new System.Drawing.Point(46, 229);
            this.label_5.Name = "label_5";
            this.label_5.Size = new System.Drawing.Size(79, 13);
            this.label_5.TabIndex = 8;
            this.label_5.Text = "Мөнгөн дүн:";
            // 
            // labelerr_remaint
            // 
            this.labelerr_remaint.AutoSize = true;
            this.labelerr_remaint.BackColor = System.Drawing.Color.Transparent;
            this.labelerr_remaint.ForeColor = System.Drawing.Color.White;
            this.labelerr_remaint.Location = new System.Drawing.Point(128, 200);
            this.labelerr_remaint.Name = "labelerr_remaint";
            this.labelerr_remaint.Size = new System.Drawing.Size(0, 13);
            this.labelerr_remaint.TabIndex = 5;
            // 
            // label_4
            // 
            this.label_4.AutoSize = true;
            this.label_4.BackColor = System.Drawing.Color.Transparent;
            this.label_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_4.ForeColor = System.Drawing.Color.White;
            this.label_4.Location = new System.Drawing.Point(34, 200);
            this.label_4.Name = "label_4";
            this.label_4.Size = new System.Drawing.Size(91, 13);
            this.label_4.TabIndex = 4;
            this.label_4.Text = "Үлдэгдэл цаг:";
            // 
            // labelerr_usedt
            // 
            this.labelerr_usedt.AutoSize = true;
            this.labelerr_usedt.BackColor = System.Drawing.Color.Transparent;
            this.labelerr_usedt.ForeColor = System.Drawing.Color.White;
            this.labelerr_usedt.Location = new System.Drawing.Point(128, 171);
            this.labelerr_usedt.Name = "labelerr_usedt";
            this.labelerr_usedt.Size = new System.Drawing.Size(0, 13);
            this.labelerr_usedt.TabIndex = 3;
            // 
            // label_3
            // 
            this.label_3.AutoSize = true;
            this.label_3.BackColor = System.Drawing.Color.Transparent;
            this.label_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_3.ForeColor = System.Drawing.Color.White;
            this.label_3.Location = new System.Drawing.Point(25, 171);
            this.label_3.Name = "label_3";
            this.label_3.Size = new System.Drawing.Size(100, 13);
            this.label_3.TabIndex = 2;
            this.label_3.Text = "Ашигласан цаг:";
            // 
            // labelerr_member
            // 
            this.labelerr_member.AutoSize = true;
            this.labelerr_member.BackColor = System.Drawing.Color.Transparent;
            this.labelerr_member.ForeColor = System.Drawing.Color.White;
            this.labelerr_member.Location = new System.Drawing.Point(128, 114);
            this.labelerr_member.Name = "labelerr_member";
            this.labelerr_member.Size = new System.Drawing.Size(0, 13);
            this.labelerr_member.TabIndex = 1;
            // 
            // label_1
            // 
            this.label_1.AutoSize = true;
            this.label_1.BackColor = System.Drawing.Color.Transparent;
            this.label_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_1.ForeColor = System.Drawing.Color.White;
            this.label_1.Location = new System.Drawing.Point(72, 114);
            this.label_1.Name = "label_1";
            this.label_1.Size = new System.Drawing.Size(53, 13);
            this.label_1.TabIndex = 0;
            this.label_1.Text = "Гишүүн:";
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.contextMenuStrip;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Visible = true;
            this.notifyIcon.DoubleClick += new System.EventHandler(this.notify_doubleclick);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msh});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.contextMenuStrip.Size = new System.Drawing.Size(68, 26);
            this.contextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.menu_open);
            // 
            // msh
            // 
            this.msh.Name = "msh";
            this.msh.Size = new System.Drawing.Size(67, 22);
            this.msh.Click += new System.EventHandler(this.menu_click);
            // 
            // webBrowser
            // 
            this.webBrowser.AllowWebBrowserDrop = false;
            this.webBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser.IsWebBrowserContextMenuEnabled = false;
            this.webBrowser.Location = new System.Drawing.Point(0, 0);
            this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.ScrollBarsEnabled = false;
            this.webBrowser.Size = new System.Drawing.Size(250, 325);
            this.webBrowser.TabIndex = 4;
            this.webBrowser.TabStop = false;
            this.webBrowser.Url = new System.Uri("", System.UriKind.Relative);
            this.webBrowser.WebBrowserShortcutsEnabled = false;
            this.webBrowser.Navigating += new System.Windows.Forms.WebBrowserNavigatingEventHandler(this.webBrowser_Navigating);
            // 
            // Mainfrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.ClientSize = new System.Drawing.Size(250, 600);
            this.ControlBox = false;
            this.Controls.Add(this.webBrowser);
            this.Controls.Add(this.panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Mainfrm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Mainfrm_FormClosing);
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem msh;
        private System.Windows.Forms.Label label_1;
        private Labelerr labelerr_member;
        private System.Windows.Forms.Label label_3;
        private Labelerr labelerr_usedt;
        private System.Windows.Forms.Label label_4;
        private Labelerr labelerr_remaint;
        private Labelerr labelerr_moneyused;
        private System.Windows.Forms.Label label_5;
        private Labelerr labelerr_startt;
        private System.Windows.Forms.Label label_2;
        private System.Windows.Forms.Button button_logout;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.Button button_hide;
        private System.Windows.Forms.WebBrowser webBrowser;


    }
}