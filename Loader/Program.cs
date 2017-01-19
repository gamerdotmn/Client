using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace Loader
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Loader());
            }
            else
            {
                if (args[0] == "-client")
                {
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
                else if (args[0] == "-guard")
                {
                    if (File.Exists(Application.StartupPath + "\\Client.exe"))
                    {
                        if (File.Exists(Application.StartupPath + "\\Guard.exe"))
                        {
                            if (File.Exists(Application.StartupPath + "\\Loader.exe"))
                            {
                                System.Diagnostics.ProcessStartInfo _pi = new System.Diagnostics.ProcessStartInfo();
                                _pi.FileName = Application.StartupPath + "\\Guard.exe";
                                _pi.UseShellExecute = true;
                                System.Diagnostics.Process.Start(_pi);

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
                else
                {
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new Loader());
                }
            }
        }
    }
}
