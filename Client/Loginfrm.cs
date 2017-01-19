using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Timers;
using System.Runtime.InteropServices;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.Diagnostics;

namespace Client
{
    public partial class Loginfrm : Form
    {
        public bool canclose = false;
        public System.Timers.Timer timer_redraw = new System.Timers.Timer(500);
        public Loginfrm()
        {
            InitializeComponent();
            this.BackColor = System.Drawing.ColorTranslator.FromHtml("#010101");
            this.Text = SystemInformation.ComputerName;
            this.label_pcname.Text = SystemInformation.ComputerName;
            Redraw();
            timer_redraw.Elapsed += new ElapsedEventHandler(timer_redraw_Elapsed);
            timer_redraw.Start();
        }

        private void Redraw()
        {
            
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate
                        {
                            //this.Location = new Point(0, 0);
                            //this.Size = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
                            //this.label_pcname.Location = new Point(Screen.PrimaryScreen.Bounds.Width - label_pcname.Width - 50, 50);
                            //this.panel_main.Location = new Point(Screen.PrimaryScreen.Bounds.Width / 2 - panel_main.Width / 2, Screen.PrimaryScreen.Bounds.Height / 2 - panel_main.Height / 2);
                            //this.Activate();
                            //this.BringToFront();
                            //this.TopMost = true;
                            //this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
                        }));
            }
            else
            {
                //this.Location = new Point(0, 0);
                //this.Size = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
                //this.label_pcname.Location = new Point(Screen.PrimaryScreen.Bounds.Width - label_pcname.Width - 50, 50);
                //this.panel_main.Location = new Point(Screen.PrimaryScreen.Bounds.Width / 2 - panel_main.Width / 2, Screen.PrimaryScreen.Bounds.Height / 2 - panel_main.Height / 2);
                //this.Activate();
                //this.BringToFront();
                //this.TopMost = true;
                //this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            }
        }
        
        private void Loginfrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (canclose == false)
            {
                e.Cancel = true;
            }
        }

        private void timer_redraw_Elapsed(object sender, EventArgs e)
        {
            Redraw();
        }

        private void textBox_timecode_TextChanged(object sender, EventArgs e)
        {
            if (textBox_timecode.Text == "cl")
            {
                canclose = true;
                this.Close();
            }
            if (textBox_timecode.Text.Length > 0)
            {
                button_timecode.Enabled = true;
            }
            else
            {
                button_timecode.Enabled = false;
            }
        }

        private void textBox_user_TextChanged(object sender, EventArgs e)
        {
            if (textBox_password.Text.Length > 0 && textBox_user.Text.Length > 0)
            {
                button_user.Enabled = true;
            }
            else
            {
                button_user.Enabled = false;
            }
        }

        private void textBox_password_TextChanged(object sender, EventArgs e)
        {
            if (textBox_password.Text.Length > 0 && textBox_user.Text.Length > 0)
            {
                button_user.Enabled = true;
            }
            else
            {
                button_user.Enabled = false;
            }
        }
    }
}
