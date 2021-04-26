using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace DriverTrip
{
    class Driver
    {
        public Boolean Writedriver(string driver)
        {
            Boolean _rtn = false;
            //using var sw = new StreamWriter(GlovalVar.DriverFile);
            //sw.WriteLine(driver);
            using (StreamWriter oFile = File.AppendText(GlovalVar.DriverFile))
            {
                oFile.WriteLine(driver);
            }

            return _rtn;
        }
    }
}
