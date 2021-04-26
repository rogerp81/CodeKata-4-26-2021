using System;
using System.Collections.Generic;
using System.Text;

namespace DriverTrip
{
    class LogEntry
    {
        public void Writetolog(string logmessage)
        {
            //All console write should either be written to a log, database or something 
            //so they are not lost as a console window could be closed 
            Console.WriteLine(logmessage);
        }
    }
}
