using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace DriverTrip
{
    class ProcessFiles
    {
        public Boolean Processingfiles(string inputfilename)
        {
            //Counters to make sure we have trips that match drivers
            Int64 _drivercount = 0;
            Int64 _tripcount = 0;
            Int64 _neitherdriverortrip = 0;

            DriverTrip.LogEntry _wrtlog = new DriverTrip.LogEntry();
            DriverTrip.Driver _writedriver = new Driver();
            DriverTrip.Trip _writetrip = new Trip();
            string line;
            string[] words;
            Boolean _rtn = false;
            StreamReader infile = new StreamReader(inputfilename);

            //Will process the input file into two files a driver file and a trip file based on the 
            //command the first column of the line.
            while((line = infile.ReadLine()) != null)
            {                
                words = line.Split(' ');                
                if (words[0] == "Driver")
                {
                    _drivercount++;
                    //Write the drive to not lose any data
                    _writedriver.Writedriver(words[1]);
                }
                else
                { 
                    //If it is not Drive then check to make sure it is trip
                    if(words[0] == "Trip")
                    {                        
                        _tripcount++;
                        _writetrip.tripprocessing(line);                        

                    }
                    else
                    {
                        _neitherdriverortrip++;
                    }
                }             
            }
            //We at least have one driver and one trip -- do they match???
            if((_drivercount >=1) && (_tripcount >=1))
            {                
                Report r = new Report();
                CompletedFile c = new CompletedFile();
                if(r.ProcessingFiles() == true)
                {
                    c.sorted();
                }
            }
            _wrtlog.Writetolog("Total Drivers: " + _drivercount + " Total Tip Count: " + _tripcount + " Errors in file " + _neitherdriverortrip);
            return _rtn;
            
        }
    }
}
