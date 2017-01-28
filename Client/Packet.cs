using System;
using System.Collections.Generic;
using System.Text;

namespace Client
{
    public class Banner
    {
        public string id;
        public string url;
    }
    public class Getbanner
    {
        public Banner[] banners;
        public string starturl;
    }
    public class Packet
    {
        public string id;
        public int cnt;
        public string[] packets;
        public string ip;
    }

    public class PacketClientServerSyn
    {
        public string command = "syn";
        public string name;
        public string mac;
        public int? status;
        public string member_name;
        public int? usedminute;
        public int? remainminute;
        public DateTime? start;
        public string app;
        public string title;
        public string tc;
        public Guid? ht;
        public int? wei;
    }

    public class PacketClientServerInitrequest
    {
        public string command = "initrequest";
        public string name;
    }

    public class PacketServerClientInit
    {
        public string command = "init";
        public string orgname;
        public string orgid;
        public string clientuser;
        public string clientpassword;
        public clientgroup group;
        public int portid;
    }

    public class PacketServerClientSyn
    {
        public string command = "syn";
    }

    public class PackeClientServerAdminLogout
    {
        public string command = "adminlogout";
    }

    public class PacketClientServerMemberLogin
    {
        public string command = "memberlogin";
        public string member;
        public string password;
    }

    public class PacketServerClientMemberLoginok
    {
        public string command = "memberloginok";
        public string member;
        public int money;
        public DateTime start;
    }

    public class PacketServerClientMemberLoginalready
    {
        public string command = "memberloginalready";
        public string name;
    }

    public class PacketClientServerMemberLogout
    {
        public string command = "memberlogout"; 
    }

    public class PacketClientServerTimecodeLogin
    {
        public string command = "timecodelogin";
        public string timecode;
    }

    public class PacketServerClientTimecodeLoginfailed
    {
        public string command = "timecodeloginfailed";
    }

    public class PacketServerClientTimecodeLoginempty
    {
        public string command = "timecodeloginempty";
    }

    public class PacketServerClientTimecodeExpired
    {
        public string command = "timecodeexpired";
    }

    public class PacketServerClientTimecodeLoginok
    {
        public string command = "timecodeloginok";
        public string code;
        public int money;
        public DateTime start;
    }

    public class PacketServerClientTiemcodeDisabled
    {
        public string command = "timecodedisabled";
    }

    public class PacketServerClientTimecodeLoginalready
    {
        public string command = "timecodeloginalready";
        public string name;
    }

    public class PacketClientServerTimecodeLogout
    {
        public string command = "timecodelogout";
    }
}
    