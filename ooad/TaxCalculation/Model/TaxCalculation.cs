using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxCalculation.Model
{
    class TaxCalculation
    {
        public LogType _log;

        public TaxCalculation(LogType log)
        {
            _log = log;
        }

        public LogType GetLog { get { return this._log; } }

        public int Calculate(int amount,int rate)
        {
            try
            {
                int r = amount / rate;
                return r;
            }
            catch(Exception ex)
            {
                if(this.GetLog == LogType.TXT)
                {
                    TxtLogger txf = new TxtLogger();
                    txf.Log(ex.Message);
                    return -1;
                }
                XmlLogger xm = new XmlLogger();
                xm.Log(ex.Message);
                return -1;
            }
        }      
    }
}
