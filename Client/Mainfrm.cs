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
using System.Management;

namespace Client
{
    public partial class Mainfrm : Form
    {
        private static KeyboardHook khook =new KeyboardHook();
        private static Loginfrm lfrm = new Loginfrm();
        private static Hashtable broadcast_servers = new Hashtable();
        private string clientpassword = "mastercafe";
        private string clientuser = "admin";
        private Thread broadcast_thread;
        private Thread server_thread;
        private int banneractive = 0;
        private Button[] btnbanners;
        private string serverip = "";
        private System.Timers.Timer server_timer;
        private System.Timers.Timer banner_timer;
        private System.Timers.Timer hide_timer;
        private System.Timers.Timer minute_timer;
        private int connecttimeout = 0;
        private bool connected = false;
        private bool init = true;
        private Hashtable server_packets = new Hashtable();
        private static string orgname = "";
        private static string orgid = "";
        private int hidetime = 20;
        public const string host = "gamer.mn";
        public const int disconnecttime = 10;
        private Clients client = new Clients();

        private void redraw()
        {
            if (this.Height != Screen.PrimaryScreen.WorkingArea.Height || this.Location != new Point(Screen.PrimaryScreen.WorkingArea.Width - 250, 0))
            {
                this.Height = Screen.PrimaryScreen.WorkingArea.Height;
                this.Location = new Point(Screen.PrimaryScreen.Bounds.Width - 250, 0);
            }
        }

        private void broadcast_listen()
        {
            Socket sock = new Socket(AddressFamily.InterNetwork,SocketType.Dgram, ProtocolType.Udp);
            IPEndPoint iep = new IPEndPoint(IPAddress.Any, Program.port_broadcast);
            sock.Bind(iep);
            EndPoint ep = (EndPoint)iep;
            byte[] data = new byte[1024];
            while (true)
            {
                int recv = sock.ReceiveFrom(data, ref ep);
                string stringData = Encoding.UTF8.GetString(data, 0, recv);
                data = new byte[1024];
                recv = sock.ReceiveFrom(data, ref ep);
                stringData = Encoding.UTF8.GetString(data, 0, recv);
                XmlDocument xd = new XmlDocument();
                xd.LoadXml(stringData);
                if (xd.ChildNodes.Count > 0 && xd.ChildNodes[0].Name == "mastercafe" && xd.ChildNodes[0].ChildNodes.Count > 0 && xd.ChildNodes[0].ChildNodes[0].Name == "cmd")
                {
                    string name = xd.ChildNodes[0].ChildNodes[1].InnerText;
                    string ip = ep.ToString();
                    ip = ip.Substring(0, ip.IndexOf(":"));
                    if (broadcast_servers.ContainsKey(ip)==false)
                    {
                        broadcast_servers.Add(ip, name);
                        if (serverip == ""&&ip!="127.0.0.1")
                        {
                            serverip = ip;
                        }
                    }
                }
            }
            sock.Close();
        }

        public Mainfrm()
        {
            try
            {
                UdpClient listener = new UdpClient(Program.port_servertoclient);
                listener.Close();
            }
            catch
            {
                System.Environment.Exit(0);
            }
            RegistryKey regserver = Registry.CurrentUser.OpenSubKey("SOFTWARE\\MCCLIENT\\", true);
            if (regserver == null)
            {
                Registry.CurrentUser.CreateSubKey("SOFTWARE\\MCCLIENT\\");
                regserver = Registry.CurrentUser.OpenSubKey("SOFTWARE\\MCCLIENT\\", true);
            }
            try
            {
                clientpassword = Program.Decompress(regserver.GetValue("pwd").ToString());
            }
            catch
            {
                ;
            }
            try
            {
                clientuser = Program.Decompress(regserver.GetValue("user").ToString());
            }
            catch
            {
                ;
            }
            try
            {
                serverip = Program.Decompress(regserver.GetValue("serverip").ToString());
            }
            catch
            {
                ;
            }
            regserver.Close();
            client.name = SystemInformation.ComputerName;
            client.mac = getmac();
            InitializeComponent();
            Thread thread_check = new Thread(new ThreadStart(startcheck));
            thread_check.IsBackground = true;
            //t.Start();
            Guard.rest_changepassword(false);
            Guard.rest_explorer(false);
            Guard.rest_logoff(false);
            Guard.rest_taskmanager(false);
            Guard.rest_workstation(false);
            Guard.rest_switchuser(false);
            Guard.rest_blockshutdown(false);
            Guard.disablebrowsersound();
            Guard.minall();
            broadcast_thread = new Thread(new ThreadStart(broadcast_listen));
            broadcast_thread.Start();
            server_thread = new Thread(new ThreadStart(server_listen));
            server_thread.Start();
            minute_timer = new System.Timers.Timer(10000);
            minute_timer.Elapsed += new ElapsedEventHandler(minute_timerelapsed);
            server_timer = new System.Timers.Timer(1000);
            server_timer.Elapsed += new ElapsedEventHandler(server_timerelapsed);
            server_timer.Start();
            khook.Hook();
            lfrm.textBox_timecode.KeyDown += login_timecodekeydown;
            lfrm.textBox_password.KeyDown += login_passwordkeydown;
            lfrm.button_timecode.Click += login_timecodeclick;
            lfrm.button_user.Click += login_userclick;
            lfrm.ShowDialog(this);
            khook.Unhook();
            Guard.rest_changepassword(true);
            Guard.rest_explorer(true);
            Guard.rest_logoff(true);
            Guard.rest_taskmanager(true);
            Guard.rest_workstation(true);
            Guard.rest_switchuser(true);
            redraw();
            banner_timer = new System.Timers.Timer(20000);
            banner_timer.Elapsed += new ElapsedEventHandler(banner_timerelapsed);
            hide_timer = new System.Timers.Timer(1000);
            hide_timer.Elapsed += new ElapsedEventHandler(hide_timerelapsed);
            hide_timer.Start();
            Thread banner_thread=new Thread(new ThreadStart(getbanner));
            banner_thread.Start();
        }

        void login_userclick(object sender, EventArgs e)
        {
            login_member();
        }

        void login_timecodeclick(object sender, EventArgs e)
        {
            login_timecode();
        }

        void login_passwordkeydown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && lfrm.textBox_password.Text.Length > 0&&lfrm.textBox_user.Text.Length>0)
            {
                login_member();
            }
        }

        void login_timecodekeydown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter&&lfrm.textBox_timecode.Text.Length>0)
            {
                login_timecode();
            }
        }

        public static bool run = false;

        private void startcheck()
        {
            //Thread.Sleep(5000);
            while (true)
            {
                Thread t = new Thread(new ThreadStart(check));
                t.IsBackground = true;
                t.Start();
                try
                {
                    Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run\\", true).SetValue("Client", Application.StartupPath + "\\Loader.exe");
                }
                catch
                {
                    ;
                }
                Thread.Sleep(500);
            }
        }

        private int wei()
        {
            ManagementObjectSearcher searcher =
                   new ManagementObjectSearcher("root\\CIMV2",
                   "SELECT * FROM Win32_WinSAT");
            double weid = 0.0;
            foreach (ManagementObject queryObj in searcher.Get())
            {
                weid = double.Parse(queryObj["WinSPRLevel"].ToString());
            }
            weid = weid * 10;
            return (int)weid;
        }

        private void check()
        {
            if (run)
            {
                return;
            }
            run = true;
            int c = 0;
            Process[] ps = Process.GetProcessesByName("Guard");
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
                            try
                            {
                                System.Diagnostics.ProcessStartInfo _pi = new System.Diagnostics.ProcessStartInfo();
                                _pi.FileName = Application.StartupPath + "\\Loader.exe";
                                _pi.Arguments = " -guard";
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

        private void hide_timerelapsed(object sender, ElapsedEventArgs e)
        {
            if (button_hide.InvokeRequired)
            {
                button_hide.Invoke(new MethodInvoker(delegate
                        {
                            button_hide.Text = "Нуух (" + hidetime + ")";
                        }));
            }
            else
            {
                button_hide.Text = "Нуух (" + hidetime + ")";
            }
            hidetime=hidetime-1;
            if (hidetime == 0)
            {
                hide_timer.Stop();
                if (button_hide.InvokeRequired)
                {
                    button_hide.Invoke(new MethodInvoker(delegate
                        {
                            button_hide.Text = "Нуух";
                            button_hide.Enabled = true;
                        }));
                }
                else
                {
                    button_hide.Text = "Нуух";
                    button_hide.Enabled = true;
                }
            }
        }

        private void banner_timerelapsed(object sender, ElapsedEventArgs e)
        {
            banneractive++;
            if (banneractive == btnbanners.Length)
            {
                banneractive = 0;
            }
            drawbtnbanners();
        }

        private void login_timecode()
        {
            if (orgid.Length < 1 || connected == false)
            {
                lfrm.labelerr_timecode.Settext("Сервертэй холбогдоогүй байна.");
            }
            else
            {
                PacketClientServerTimecodeLogin packettimecodelogin = new PacketClientServerTimecodeLogin();
                packettimecodelogin.timecode = lfrm.textBox_timecode.Text;
                Send(serverip, Program.port_clienttoserver, Newtonsoft.Json.JsonConvert.SerializeObject(packettimecodelogin));
            }
        }

        private void login_member()
        {
                if (lfrm.textBox_user.Text.ToLower() == clientuser.ToLower())
                {
                    if (lfrm.textBox_password.Text.ToLower() == clientpassword.ToLower())
                    {
                        client.status = 2;
                        lfrm.canclose = true;
                        lfrm.Close();
                        button_logout.Enabled = true;
                    }
                    else
                    {
                        lfrm.labelerr_member.Settext("Та хандах эрхгүй байна.");
                    }
                }
                else
                {
                    if (orgid.Length < 1 || connected == false)
                    {
                        lfrm.labelerr_member.Settext("Сервертэй холбогдоогүй байна.");
                    }
                    else
                    {
                        PacketClientServerMemberLogin packetmemberlogin = new PacketClientServerMemberLogin();
                        packetmemberlogin.member = lfrm.textBox_user.Text;
                        packetmemberlogin.password = lfrm.textBox_password.Text;
                        Send(serverip, Program.port_clienttoserver, Newtonsoft.Json.JsonConvert.SerializeObject(packetmemberlogin));
                    }
                }
        }

        private void killnotresponding()
        {
            Process[] ps = Process.GetProcesses();
            for (int i = 0; i < ps.Length; i++)
            {
                if (ps[i].Responding == false && ps[i].ProcessName.ToLower() != "client" && ps[i].ProcessName.ToLower() != "guard")
                {
                    ps[i].Kill();
                }
            }
        }

        public int string_minute(string _string)
        {
            int ret;
            string _hour = _string.Substring(0, _string.IndexOf(":"));
            int hour = int.Parse(_hour);
            string _min = _string.Substring(_string.IndexOf(":") + 1, 2);
            int min = int.Parse(_min);
            ret = hour * 60 + min;
            return (ret);
        }

        public string minute_string(int _minute)
        {
            string ret = "";
            int hour = _minute / 60;
            int min = _minute % 60;
            string _hour = hour.ToString();
            if (_hour.Length == 1)
            {
                _hour = "0" + _hour;
            }
            string _min = min.ToString();
            if (_min.Length == 1)
            {
                _min = "0" + _min;
            }
            ret = _hour + ":" + _min;
            return (ret);
        }

        private void status()
        {
            if (client.status == 3)
            {
                int total = (client.member.money * 60) / client.group.memberprice;
                client.remainminute = total - client.usedminute;
                if (client.remainminute <= 0)
                {
                    PacketClientServerMemberLogout packet = new PacketClientServerMemberLogout();
                    Send(serverip, Program.port_clienttoserver, Newtonsoft.Json.JsonConvert.SerializeObject(packet));
                }
                else
                {
                    labelerr_usedt.Settext(minute_string((int)client.usedminute));
                    labelerr_remaint.Settext(minute_string((int)client.remainminute));
                    int money = client.member.money - (client.group.memberprice / 60) * (int)client.usedminute;
                    labelerr_moneyused.Settext(money.ToString() + "₮");
                }
                
            }
            if (client.status == 4)
            {
                int total = (client.tc.money * 60) / client.group.timecodeprice;
                client.remainminute = total - client.usedminute;
                if (client.remainminute <= 0)
                {
                    PacketClientServerTimecodeLogout packet = new PacketClientServerTimecodeLogout();
                    Send(serverip, Program.port_clienttoserver, Newtonsoft.Json.JsonConvert.SerializeObject(packet));
                }
                else
                {
                    labelerr_usedt.Settext(minute_string((int)client.usedminute));
                    labelerr_remaint.Settext(minute_string((int)client.remainminute));
                    int money = client.tc.money - (client.group.timecodeprice / 60) * (int)client.usedminute;
                    labelerr_moneyused.Settext(money.ToString() + "₮");
                }
            }
        }

        private void minute_timerelapsed(object sender, ElapsedEventArgs e)
        {
            client.usedminute++;
            status();    
        }

        private void server_adminlogoutok()
        {
            System.Environment.Exit(0);
        }

        private void server_memberloginfailed()
        {
            lfrm.labelerr_member.Settext("Та хандах эрхгүй байна.");
        }

        private void server_memberloginalready(PacketServerClientMemberLoginalready packet)
        {
            lfrm.labelerr_member.Settext("'" + packet.name + "' дээр нэвтэрсэн байна.");
        }

        private void server_memberloginempty()
        {
            lfrm.labelerr_member.Settext("Үлдэгдэл хүрэлцэхгүй байна.");
        }

        private void server_memberdisabled()
        {
            lfrm.labelerr_member.Settext("Тус компьютер дээр гишүүний эрхээр нэвтрэх боломжгүй.");
        }

        private void server_memberlogoutok()
        {
            System.Environment.Exit(0);
        }

        private void server_timecodelogoutok()
        {
            System.Environment.Exit(0);
        }

        private void server_memberloginok(PacketServerClientMemberLoginok packet)
        {
            if (lfrm.InvokeRequired)
            {
                lfrm.Invoke(new MethodInvoker(delegate
                {
                    lfrm.canclose = true;
                    lfrm.Close();
                }));
            }
            else
            {
                lfrm.canclose = true;
                lfrm.Close();
            }
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate
                {
                    button_logout.Enabled = true;
                    minute_timer.Start();
                }));
            }
            else
            {
                button_logout.Enabled = true;
                minute_timer.Start();
            }
            client.status = 3;
            client.member = new clientmember();
            client.member.name = packet.member;
            client.member.money = packet.money;
            client.usedminute = 0;
            client.start = packet.start;
            labelerr_member.Settext(client.member.name);
            labelerr_startt.Settext(((DateTime)client.start).ToString("HH:mm"));
            status();
        }

        private void server_timecodeloginok(PacketServerClientTimecodeLoginok packet)
        {
            if (lfrm.InvokeRequired)
            {
                lfrm.Invoke(new MethodInvoker(delegate
                {
                    lfrm.canclose = true;
                    lfrm.Close();
                }));
            }
            else
            {
                lfrm.canclose = true;
                lfrm.Close();
            }
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate
                {
                    button_logout.Enabled = true;
                    minute_timer.Start();
                    label_1.Visible = false;
                }));
            }
            else
            {
                button_logout.Enabled = true;
                minute_timer.Start();
                label_1.Visible = false;
            }
            client.status = 4;
            client.tc = new clienttimecode();
            client.tc.code = packet.code;
            client.tc.money = packet.money;
            client.usedminute = 0;
            client.start = packet.start;
            labelerr_startt.Settext(((DateTime)client.start).ToString("HH:mm"));
            status();
        }

        private void server_timecodeloginfailed()
        {
            lfrm.labelerr_timecode.Settext("Та хандах эрхгүй байна.");
        }

        private void server_timecodeloginalready(PacketServerClientTimecodeLoginalready packet)
        {
            lfrm.labelerr_timecode.Settext("'" + packet.name + "' дээр нэвтэрсэн байна.");
        }

        private void server_timecodeloginempty()
        {
            lfrm.labelerr_timecode.Settext("Үлдэгдэл хүрэлцэхгүй байна.");
        }

        private void server_timecodeexpired()
        {
            lfrm.labelerr_timecode.Settext("Хүчинтэй хугацаа дууссан байна.");
        }

        private void server_timecodedisabled()
        {
            lfrm.labelerr_timecode.Settext("Тус компьютер дээр кодоор нэвтрэх боломжгүй.");
        }


        private void server_management(string ip,string data)
        {
            if (data.Length == 0)
            {
                return;
            }
            ip = ip.Substring(0, ip.IndexOf(":"));
            if (ip != serverip)
            {
                return;
            }
            string cmd = (string)Newtonsoft.Json.Linq.JObject.Parse(data)["command"];
            switch (cmd)
            {
                case "syn": server_syn(); break;
                case "init": server_init(Newtonsoft.Json.JsonConvert.DeserializeObject<PacketServerClientInit>(data)); break;
                case "adminlogoutok": server_adminlogoutok(); break;
                case "memberloginfailed": server_memberloginfailed(); break;
                case "memberloginalready": server_memberloginalready(Newtonsoft.Json.JsonConvert.DeserializeObject<PacketServerClientMemberLoginalready>(data)); break;
                case "memberloginok": server_memberloginok(Newtonsoft.Json.JsonConvert.DeserializeObject<PacketServerClientMemberLoginok>(data)); break;
                case "memberloginempty": server_memberloginempty(); break;
                case "memberdisabled": server_memberdisabled(); break;
                case "memberlogoutok": server_memberlogoutok(); break;
                case "timecodeloginfailed": server_timecodeloginfailed(); break;
                case "timecodeloginempty": server_timecodeloginempty(); break;
                case "timecodeexpired": server_timecodeexpired(); break;
                case "timecodeloginok": server_timecodeloginok(Newtonsoft.Json.JsonConvert.DeserializeObject<PacketServerClientTimecodeLoginok>(data)); break;
                case "timecodedisabled": server_timecodedisabled(); break;
                case "timecodeloginalready": server_timecodeloginalready(Newtonsoft.Json.JsonConvert.DeserializeObject<PacketServerClientTimecodeLoginalready>(data)); break;
                case "timecodelogoutok": server_timecodelogoutok(); break;
                default: break;
            }
        }

        private void server_syn()
        {
            if (connected == false)
            {
                connected = true;
                server_connect();
            }
            connecttimeout = 0;
        }

        private void server_init(PacketServerClientInit packet)
        {
            init = true;
            clientpassword = packet.clientpassword;
            clientuser = packet.clientuser;
            RegistryKey regserver = Registry.CurrentUser.OpenSubKey("SOFTWARE\\MCCLIENT\\", true);
            if (regserver == null)
            {
                Registry.CurrentUser.CreateSubKey("SOFTWARE\\MCCLIENT\\");
                regserver = Registry.CurrentUser.OpenSubKey("SOFTWARE\\MCCLIENT\\", true);
            }
            try
            {
                regserver.SetValue("pwd", Program.Compress(clientpassword));
            }
            catch
            {
                ;
            }
            try
            {
                regserver.SetValue("user", Program.Compress(clientuser));
            }
            catch
            {
                ;
            }
            regserver.Close();
            client.group = packet.group;
            orgid=packet.orgid;
            orgname = packet.orgname;
        }

        private void server_exit()
        {
            RegistryKey regserver = Registry.CurrentUser.OpenSubKey("SOFTWARE\\MCCLIENT\\", true);
            if (regserver == null)
            {
                Registry.CurrentUser.CreateSubKey("SOFTWARE\\MCCLIENT\\");
                regserver = Registry.CurrentUser.OpenSubKey("SOFTWARE\\MCCLIENT\\", true);
            }
            regserver.SetValue("exit", true);
            regserver.Close();
            System.Environment.Exit(0);
        }

        private void server_message(string msg)
        {
            //if (status > 1)
            //{
                System.Diagnostics.ProcessStartInfo pi = new ProcessStartInfo("msg", " * \"" + msg + "\"");
                pi.WindowStyle = ProcessWindowStyle.Hidden;
                pi.CreateNoWindow = true;
                pi.UseShellExecute = false;
                Process.Start(pi);
                Guard.minall();
            //}
        }

        private void server_shutdown()
        {
            System.Diagnostics.ProcessStartInfo pi = new ProcessStartInfo("shutdown", " -s -t 0 -f");
            pi.WindowStyle = ProcessWindowStyle.Hidden;
            pi.CreateNoWindow = true;
            pi.UseShellExecute = false;
            Process.Start(pi);
        }

        private void server_reboot()
        {
            System.Diagnostics.ProcessStartInfo pi = new ProcessStartInfo("shutdown", " -r -t 0 -f");
            pi.WindowStyle = ProcessWindowStyle.Hidden;
            pi.CreateNoWindow = true;
            pi.UseShellExecute = false;
            Process.Start(pi);
        }

        private void server_collect(object obj)
        {
            string[] param = (string[])obj;
            string msg = param[1];
            string ip = param[0];
            string total = "";
            try
            {
                XmlDocument xd = new XmlDocument();
                xd.LoadXml(param[1]);
                if (xd.ChildNodes.Count > 0 && xd.ChildNodes[0].Name == "rc")
                {
                    string id = xd.ChildNodes[0].ChildNodes[0].InnerText;
                    string spart = xd.ChildNodes[0].ChildNodes[1].InnerText;
                    int part = Convert.ToInt32(spart);
                    string scount = xd.ChildNodes[0].ChildNodes[2].InnerText;
                    int count = Convert.ToInt32(scount);
                    string data = xd.ChildNodes[0].ChildNodes[3].InnerText;

                    if (server_packets.ContainsKey(id))
                    {
                        Packet p = (Packet)server_packets[id];
                        p.packets[part] = data;
                        server_packets[id] = p;
                    }
                    else
                    {
                        Packet p = new Packet();
                        p.packets = new string[count];
                        p.id = id;
                        p.ip = param[0];
                        p.cnt = count;
                        p.packets[part] = data;
                        server_packets.Add(id, p);
                    }
                    Packet ptotal = (Packet)server_packets[id];

                    if (part + 1 == count)
                    {

                        for (var i = 0; i < count; i++)
                        {
                            total = total + ptotal.packets[i];
                        }
                        total = Program.Decompress(total);
                        server_management(ip,total);
                    }
                }
            }
            catch
            {
                ;
            }
            
        }

        private void server_listen()
        {
            UdpClient client_udp = new UdpClient(Program.port_servertoclient);
            IPEndPoint groupEP = new IPEndPoint(IPAddress.Any, Program.port_servertoclient);
            while (true)
            {
                try
                {
                    byte[] allmessage = client_udp.Receive(ref groupEP);
                    Thread _Thread = new Thread(new ParameterizedThreadStart(server_collect));
                    string[] param = new string[2];
                    param[0] = groupEP.ToString();
                    param[1] = System.Text.Encoding.UTF8.GetString(allmessage);
                    _Thread.Start((object)param);
                }
                catch { ;}
            }
        }

        private void Send(string clientip, int port, string message)
        {
            string[] param = new string[3];
            param[0] = clientip;
            param[1] = port.ToString();
            param[2] = message;
            Thread _Thread = new Thread(new ParameterizedThreadStart(_Send));
            _Thread.Start((object)param);
        }

        private void _Send(object obj)
        {
            int step = 60000;
            int sleep = 10;
            string[] param = (string[])obj;
            string ip = param[0];
            int port = Convert.ToInt32(param[1]);
            string data = param[2];
            string id = Guid.NewGuid().ToString();
            data = Program.Compress(data);
            int cnt = data.Length / step;
            while (step * cnt < data.Length)
            {
                cnt = cnt + 1;
            }
            string[] packets = new string[cnt];
            for (int i = 0; i < cnt; i++)
            {
                if (i + 1 == cnt)
                {
                    step = data.Length - i * step;
                }
                packets[i] = data.Substring(i * step, step);
                byte[] message = System.Text.Encoding.UTF8.GetBytes("<rc><id>" + id + "</id><part>" + i + "</part><count>" + cnt + "</count><data>" + packets[i] + "</data></rc>");
                try
                {
                    UdpClient sock = new UdpClient(ip, port);
                    sock.Send(message, message.Length);
                    sock.Close();
                    Thread.Sleep(sleep);
                }
                catch
                {
                    ;
                }
            }
        }

        private void server_connect()
        {
            init = false;
        }

        private void server_disconnect()
        {
            if (client.status > 2)
            {
                System.Environment.Exit(0);
            }
        }
        
        private void getbanner()
        {
            try
            {
                WebRequest req = WebRequest.Create("http://"+host+"/api/banner.php");
                WebResponse res = req.GetResponse();
                Stream stream = res.GetResponseStream();
                StreamReader streamr = new StreamReader(stream);
                string data = streamr.ReadToEnd();
                Getbanner banner=Newtonsoft.Json.JsonConvert.DeserializeObject<Getbanner>(data);

                btnbanners = new Button[banner.banners.Length];

                int loc = (banner.banners.Length * 15) / 2;
                loc = (250 / 2) - loc;
                bool h = true;
                for (int i = 0; i < banner.banners.Length; i++)
                {
                    btnbanners[i] = new Button();
                    string url = banner.banners[i].url;
                    string id = banner.banners[i].id;
                    if (i == 0)
                    {
                        webBrowser.Url = new Uri("http://"+host+"/api/banners/" + id + "/index.php");
                        btnbanners[i].BackColor = System.Drawing.Color.Black;
                    }
                    else
                    {
                        btnbanners[i].BackColor = System.Drawing.Color.White;
                    }
                    btnbanners[i].Cursor = Cursors.Hand;
                    btnbanners[i].FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                    btnbanners[i].Location = new System.Drawing.Point((loc + i * 15), webBrowser.Height - 20);
                    btnbanners[i].Name = id;
                    btnbanners[i].Size = new System.Drawing.Size(10, 10);
                    btnbanners[i].TabStop = false;
                    btnbanners[i].UseVisualStyleBackColor = false;
                    btnbanners[i].Tag = url;
                    btnbanners[i].Click += btnbanner_click;
                    btnbanners[i].TabStop = false;
                    if (this.InvokeRequired)
                    {
                        this.Invoke(new MethodInvoker(delegate
                        {
                            this.Controls.Add(this.btnbanners[i]);
                            btnbanners[i].BringToFront();
                        }));
                    }
                    else
                    {
                        this.Controls.Add(this.btnbanners[i]);
                        btnbanners[i].BringToFront();
                    }
                }

                banner_timer.Start();
                Process.Start(banner.starturl);
            }
            catch (Exception ex)
            {

            }
        }

        private void drawbtnbanners()
        {
            for (int i = 0; i < btnbanners.Length; i++)
            {
                btnbanners[i].BackColor = System.Drawing.Color.White;
            }
            btnbanners[banneractive].BackColor = System.Drawing.Color.Black;
            webBrowser.Url = new Uri("http://"+host+"/api/banners/" + btnbanners[banneractive].Name + "/index.php");
        }

        private void btnbanner_click(object sender, EventArgs e)
        {
            banner_timer.Stop();
            for (int i = 0; i < btnbanners.Length; i++)
            {
                if (btnbanners[i].Name == (string)(sender as Button).Name)
                {
                    banneractive = i;
                    break;
                }
            }
            drawbtnbanners();
            banner_timer.Start();
        }

        private string getmac()
        {
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            string m = "";
            foreach (NetworkInterface nic in nics)
            {
                m=m+nic.GetPhysicalAddress().ToString()+" ";
            }
            return (m);
        }

        private void server_sendsyn()
        {
            PacketClientServerSyn packet = new PacketClientServerSyn();
            packet.app = "";
            packet.title = "";
            const int nChars = 256;
            int handle = 0;
            StringBuilder Buff = new StringBuilder(nChars);
            try
            {
                handle = Guard.GetForegroundWindow();
                System.Diagnostics.Process[] ps = System.Diagnostics.Process.GetProcesses();
                foreach (System.Diagnostics.Process p in ps)
                {
                    if ((int)p.MainWindowHandle == handle)
                    {
                        int li = p.MainModule.FileName.LastIndexOf("\\") + 1;
                        packet.app += p.MainModule.FileName.Substring(li, p.MainModule.FileName.Length - li);
                        break;
                    }
                }
                if (Guard.GetWindowText(handle, Buff, nChars) > 0)
                {
                    packet.title += Buff.ToString();
                }
            }
            catch { ;}
            packet.name = client.name;
            packet.mac = client.mac;
            packet.status = client.status;
            packet.member_name = client.member.name;
            packet.usedminute = client.usedminute;
            packet.remainminute = client.remainminute;
            packet.start = client.start;
            packet.tc = client.tc.code;
            packet.ht = client.ht;
            Send(serverip, Program.port_clienttoserver, Newtonsoft.Json.JsonConvert.SerializeObject(packet));
            connecttimeout++;
            if (connecttimeout > disconnecttime)
            {
                if (connected)
                {
                    connected = false;
                    server_disconnect();
                }
            }
            if (init == false)
            {
                PacketClientServerInitrequest packetinitrequest = new PacketClientServerInitrequest();
                packetinitrequest.name = client.name;
                Send(serverip, Program.port_clienttoserver, Newtonsoft.Json.JsonConvert.SerializeObject(packetinitrequest));
            }
        }

        private void server_timerelapsed(object sender, EventArgs e)
        {
            server_sendsyn();
        }

        private void menu_click(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                this.TopMost = false;
                this.Visible = false;
                this.WindowState = FormWindowState.Minimized;
            }
            else
            {
                this.TopMost = true;
                this.Visible = true;
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void menu_open(object sender, CancelEventArgs e)
        {
            if (this.Visible)
            {
                msh.Text = "Нуух";
            }
            else
            {
                msh.Text = "Нээх";
            }
        }

        private void button_hide_Click(object sender, EventArgs e)
        {
            this.TopMost = false;
            this.Visible = false;
            this.WindowState = FormWindowState.Minimized;
        }

        private void notify_doubleclick(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                this.TopMost = false;
                this.Visible = false;
                this.WindowState = FormWindowState.Minimized;
            }
            else
            {
                this.TopMost = true;
                this.Visible = true;
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void Mainfrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }

        private void webBrowser_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            if (e.Url.ToString().IndexOf("#click")>-1)
            {
                Process.Start(btnbanners[banneractive].Tag.ToString());
            }
        }

        private void button_logout_Click(object sender, EventArgs e)
        {
            if (client.status == 2)
            {
                PackeClientServerAdminLogout packet = new PackeClientServerAdminLogout();
                Send(serverip, Program.port_clienttoserver, Newtonsoft.Json.JsonConvert.SerializeObject(packet));
            }
            if (client.status == 3)
            {
                PacketClientServerMemberLogout packet = new PacketClientServerMemberLogout();
                Send(serverip, Program.port_clienttoserver, Newtonsoft.Json.JsonConvert.SerializeObject(packet));
            }
            if (client.status == 4)
            {
                PacketClientServerTimecodeLogout packet = new PacketClientServerTimecodeLogout();
                Send(serverip, Program.port_clienttoserver, Newtonsoft.Json.JsonConvert.SerializeObject(packet));
            }
        }

    }
}