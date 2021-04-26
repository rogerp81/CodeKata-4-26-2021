using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace DriverTrip
{
    class Trip
    {
        public  Boolean tripprocessing(string trip)
        {
            Boolean _rtn = true;
            using (StreamWriter oFile = File.AppendText(GlovalVar.TripFile))
            {
                oFile.WriteLine(trip);
            }

            return _rtn;
        }
    }

}
