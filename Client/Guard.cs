using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;
using System.Threading;
using System.Timers;
using System.Xml;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Web;
using System.Diagnostics;
using Microsoft.Win32;
using System.IO.Compression;
using System.Collections;
using LowLevelHooks.Keyboard;
using System.Security.Principal;

namespace Client
{
    public class Guard
    {
        [DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll", EntryPoint = "SendMessage", SetLastError = true)]
        public static extern IntPtr SendMessage(IntPtr hWnd, Int32 Msg, IntPtr wParam, IntPtr lParam);
        public const int WM_COMMAND = 0x111;
        public const int MIN_ALL = 419;
        public const int MIN_ALL_UNDO = 416;
        [DllImport("user32.dll")]
        public static extern bool SetForeGroundWindow(IntPtr hWnd);
        [DllImport("user32.dll")]
        public static extern int GetForegroundWindow();
        [DllImport("user32.dll")]
        public static extern int GetWindowText(int hWnd, StringBuilder text, int count);
        public const int FEATURE_DISABLE_NAVIGATION_SOUNDS = 21;
        public const int SET_FEATURE_ON_PROCESS = 0x00000002;
        [DllImport("urlmon.dll")]
        [PreserveSig]
        [return: MarshalAs(UnmanagedType.Error)]
        public static extern int CoInternetSetFeatureEnabled(int FeatureEntry, [MarshalAs(UnmanagedType.U4)] int dwFlags, bool fEnable);
        public static void disablebrowsersound()
        {
            CoInternetSetFeatureEnabled(FEATURE_DISABLE_NAVIGATION_SOUNDS, SET_FEATURE_ON_PROCESS, true);
        }
        public static void minall()
        {
            IntPtr lHwnd = FindWindow("Shell_TrayWnd", null);
            SendMessage(lHwnd, WM_COMMAND, (IntPtr)MIN_ALL, IntPtr.Zero);
        }

        public static void rest_taskmanager(bool enable)
        {
            try
            {
                var reg = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies", true);
                if (reg == null)
                {
                    Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies");
                }
            }
            catch
            {
                try
                {
                    Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies");
                }
                catch { ;}
            }
            try
            {
                var reg = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\System", true);
                if (reg == null)
                {
                    Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\System");
                }
            }
            catch
            {
                try
                {
                    Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\System");
                }
                catch { ;}
            }
            if (enable == false)
            {
                try
                {
                    Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\System", true).SetValue("DisableTaskMgr", "1", RegistryValueKind.DWord);
                }
                catch { ;}
            }
            else
            {
                try
                {
                    Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\System", true).SetValue("DisableTaskMgr", "0", RegistryValueKind.DWord);
                }
                catch { ;}
            }
        }

        public static void rest_explorer(bool enable)
        {
            try
            {
                var reg = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies", true);
                if (reg == null)
                {
                    Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies");
                }
            }
            catch
            {
                try
                {
                    Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies");
                }
                catch { ;}
            }
            try
            {
                var reg = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\Explorer", true);
                if (reg == null)
                {
                    Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\Explorer");
                }
            }
            catch
            {
                try
                {
                    Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\Explorer");
                }
                catch { ;}
            }
            if (enable == false)
            {
                try
                {
                    Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\Explorer", true).SetValue("NoDesktop", "1", RegistryValueKind.DWord);
                }
                catch { ;}
            }
            else
            {
                try
                {
                    Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\Explorer", true).SetValue("NoDesktop", "0", RegistryValueKind.DWord);
                }
                catch { ;}
            }
        }

        public static void rest_logoff(bool enable)
        {
            try
            {
                var reg = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies", true);
                if (reg == null)
                {
                    Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies");
                }
            }
            catch
            {
                try
                {
                    Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies");
                }
                catch { ;}
            }
            try
            {
                var reg = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\Explorer", true);
                if (reg == null)
                {
                    Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\Explorer");
                }
            }
            catch
            {
                try
                {
                    Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\Explorer");
                }
                catch { ;}
            }
            if (enable == false)
            {
                try
                {
                    Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\Explorer", true).SetValue("NoLogoff", "1", RegistryValueKind.DWord);
                }
                catch { ;}
            }
            else
            {
                try
                {
                    Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\Explorer", true).SetValue("NoLogoff", "0", RegistryValueKind.DWord);
                }
                catch { ;}
            }
        }

        public static void rest_changepassword(bool enable)
        {
            bool k = true;
            try
            {
                var reg = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies", true);
                if (reg == null)
                {
                    Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies");
                }
            }
            catch
            {
                try
                {
                    Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies");
                }
                catch { ;}
            }

            try
            {
                var reg = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\System", true);
                if (reg == null)
                {
                    Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\System");
                }
            }
            catch
            {
                try
                {
                    Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\System");
                }
                catch { ;}
            }

            if (enable == false)
            {
                try
                {
                    Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\System", true).SetValue("DisableChangePassword", "1", RegistryValueKind.DWord);
                }
                catch { ;}
            }
            else
            {
                try
                {
                    Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\System", true).SetValue("DisableChangePassword", "0", RegistryValueKind.DWord);
                }
                catch { ;}
            }
        }

        public static void rest_workstation(bool enable)
        {
            try
            {
                var reg = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies", true);
                if (reg == null)
                {
                    Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies");
                }
            }
            catch
            {
                try
                {
                    Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies");
                }
                catch { ;}
            }
            try
            {
                var reg = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\System", true);
                if (reg == null)
                {
                    Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\System");
                }
            }
            catch
            {
                try
                {
                    Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\System");
                }
                catch { ;}
            }
            if (enable == false)
            {
                try
                {
                    Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\System", true).SetValue("DisableLockWorkstation", "1", RegistryValueKind.DWord);
                }
                catch { ;}
            }
            else
            {
                try
                {
                    Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\System", true).SetValue("DisableLockWorkstation", "0", RegistryValueKind.DWord);
                }
                catch { ;}
            }
        }

        public static void rest_switchuser(bool enable)
        {

            if (enable == false)
            {
                try
                {
                    Registry.LocalMachine.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\System", true).SetValue("HideFastUserSwitching", "1", RegistryValueKind.DWord);
                }
                catch { ;}
            }
            else
            {
                try
                {
                    Registry.LocalMachine.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\System", true).SetValue("HideFastUserSwitching", "0", RegistryValueKind.DWord);
                }
                catch { ;}
            }
        }

        public static void rest_blockshutdown(bool enable)
        {
            if (enable == false)
            {
                try
                {
                    Registry.LocalMachine.OpenSubKey(@"Software\Policies\Microsoft\Windows\System", true).SetValue("AllowBlockingAppsAtShutdown", "1", RegistryValueKind.DWord);
                }
                catch { ;}
            }
            else
            {
                try
                {
                    Registry.LocalMachine.OpenSubKey(@"Software\Policies\Microsoft\Windows\System", true).SetValue("AllowBlockingAppsAtShutdown", "0", RegistryValueKind.DWord);
                }
                catch { ;}
            }
        }

    }
}
