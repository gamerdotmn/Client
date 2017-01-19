using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Timers;
using System.Diagnostics;
using System.IO;
using Microsoft.Win32;
using System.Threading;

namespace Guard
{
    public partial class Guard : Form
    {
        public static bool run = false;
        private void Check()
        {
            if (run)
            {
                return;
            }
            run = true;
                int c = 0;
                Process[] ps = Process.GetProcessesByName("Client");
                for (int i = 0; i < ps.Length; i++)
                {
                    if (Application.StartupPath == ps[i].MainModule.FileName.Substring(0, ps[i].MainModule.FileName.LastIndexOf("\\")))
                    {
                        c++;
                    }
                }
                if (c == 0)
                {
                    if (File.Exists(Application.StartupPath + "\\Client.exe"))
                    {
                        if (File.Exists(Application.StartupPath + "\\Guard.exe"))
                        {
                            if (File.Exists(Application.StartupPath + "\\Loader.exe"))
                            {
                                RegistryKey regserver = Registry.CurrentUser.OpenSubKey("SOFTWARE\\MCCLIENT\\", true);
                                if (regserver == null)
                                {
                                    Registry.CurrentUser.CreateSubKey("SOFTWARE\\MCCLIENT\\");
                                    regserver = Registry.CurrentUser.OpenSubKey("SOFTWARE\\MCCLIENT\\", true);
                                }
                                if (regserver.GetValue("exit") == null)
                                {
                                    try
                                    {
                                        System.Diagnostics.ProcessStartInfo _pi = new System.Diagnostics.ProcessStartInfo();
                                        _pi.FileName = Application.StartupPath + "\\Loader.exe";
                                        _pi.Arguments = " -client";
                                        _pi.UseShellExecute = true;
                                        System.Diagnostics.Process.Start(_pi);
                                    }
                                    catch
                                    {
                                        ;
                                    }
                                }
                                else
                                {
                                    regserver.DeleteValue("exit");
                                    System.Environment.Exit(0);
                                }
                                regserver.Close();
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
            run = false;
        }
        private void StartCheck()
        {
            //Thread.Sleep(5000);
            while (true)
            {
                Thread t = new Thread(new ThreadStart(Check));
                t.IsBackground = true;
                t.Start();
                Thread.Sleep(500);
            }
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams pm = base.CreateParams;
                pm.ExStyle |= 0x80;
                return pm;
            }
        }
        public Guard()
        {
            InitializeComponent();
            this.Opacity = 0;
            this.Location = new Point(-100, -100);
            Thread t = new Thread(new ThreadStart(StartCheck));
            t.IsBackground = true;
            t.Start();
        }

        private void Guard_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }
    }
}
