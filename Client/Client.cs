using System;
using System.Collections.Generic;
using System.Text;

namespace Client
{
    public class Clients
    {
        public string name=null;
        public string mac=null;
        public int? status=null;
        public int? usedminute=null;
        public int? remainminute=null;
        public DateTime? start = null;
        public string app = null;
        public string title=null;
        public clienttimecode tc = new clienttimecode();
        public Guid? ht;
        public clientgroup group=new clientgroup();
        public clientmember member=new clientmember();
    }
}
