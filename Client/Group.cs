using System;
using System.Collections.Generic;
using System.Text;

namespace Client
{
    public class clientgroup
    {
        public Guid id;
        public string name;
        public int timecodeprice;
        public int memberprice;
        public int hourprice;
        public bool timecode;
        public bool member;
        public bool hour;
        public bool prepairhour;
        public int minprice;
    }
}
