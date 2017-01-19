using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Client
{
    public class Labelerr:Label
    {
        private System.Timers.Timer oTimer = new System.Timers.Timer();
        private string err;
        private int c;
        public string _Text = String.Empty;
        public void Settext(string _err)
        {
            _Text = _err;
            this.err = _err;
            int interval = 500 / err.Length;
            if (oTimer.Enabled)
            {
                oTimer.Enabled = false;
            }
            oTimer = null;
            oTimer = new System.Timers.Timer();
            oTimer.Interval = interval;
            oTimer.Elapsed+=new System.Timers.ElapsedEventHandler(oTimer_Elapsed);
            oTimer.Enabled = true;
            c = 0;
        }
        delegate void Callbackp(string msg);
        private void Changetext(string param)
        {
            if (this.InvokeRequired)
            {
                Callbackp oCallbackp = new Callbackp(Changetext);
                this.Invoke(oCallbackp, param);
            }
            else
            {
                this.Text = param.ToString();
            }
        }
        private void oTimer_Elapsed(object sender, EventArgs e)
        {
            if (c+1>err.Length)
            {
                oTimer.Enabled = false;
                return;
            }
            string temp = String.Empty;
            for (int i = 0; i<= c; i++)
            {
                temp = temp + err[i];
            }
            Changetext(temp);
            c++;
        }
    }
}
