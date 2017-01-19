using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
namespace Loader
{
    public partial class Loader : Form
    {
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams pm = base.CreateParams;
                pm.ExStyle |= 0x80;
                return pm;
            }
        }
        public Loader()
        {
            InitializeComponent();
            this.Opacity = 0;
            this.Location = new Point(-100, -100);
            if (File.Exists(Application.StartupPath + "\\Client.exe"))
            {
                if (File.Exists(Application.StartupPath + "\\Guard.exe"))
                {
                    if (File.Exists(Application.StartupPath + "\\Loader.exe"))
                    {
                        System.Diagnostics.ProcessStartInfo _pi = new System.Diagnostics.ProcessStartInfo();
                        _pi.FileName = Application.StartupPath + "\\Client.exe";
                        _pi.UseShellExecute = true;
                        System.Diagnostics.Process.Start(_pi);

                        System.Diagnostics.ProcessStartInfo _pig = new System.Diagnostics.ProcessStartInfo();
                        _pig.FileName = Application.StartupPath + "\\Guard.exe";
                        _pig.UseShellExecute = true;
                        System.Diagnostics.Process.Start(_pig);

                        System.Environment.Exit(0);
                    }
                    else
                    {
                        System.Diagnostics.ProcessStartInfo _pi = new System.Diagnostics.ProcessStartInfo("shutdown", " -r -t 0 -f");
                        _pi.WindowStyle = ProcessWindowStyle.Hidden;
                        _pi.CreateNoWindow = true;
                        _pi.UseShellExecute = true;
                        Process.Start(_pi);
                    }
                }
                else
                {
                    System.Diagnostics.ProcessStartInfo _pi = new System.Diagnostics.ProcessStartInfo("shutdown", " -r -t 0 -f");
                    _pi.WindowStyle = ProcessWindowStyle.Hidden;
                    _pi.CreateNoWindow = true;
                    _pi.UseShellExecute = true;
                    Process.Start(_pi);
                }
            }
            else
            {
                System.Diagnostics.ProcessStartInfo _pi = new System.Diagnostics.ProcessStartInfo("shutdown", " -r -t 0 -f");
                _pi.WindowStyle = ProcessWindowStyle.Hidden;
                _pi.CreateNoWindow = true;
                _pi.UseShellExecute = true;
                Process.Start(_pi);
            }
        }

        private void Loader_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }
    }
}
