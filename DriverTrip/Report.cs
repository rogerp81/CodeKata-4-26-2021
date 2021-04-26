using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace DriverTrip
{
    class Report
    {
        //Begin processing the files
        public Boolean ProcessingFiles()
        {
            DriverTrip.LogEntry _wrtlog = new DriverTrip.LogEntry();
            Boolean _rtn = false;
            Boolean constrant = true;
            string _line;
            string _driver;
            string _stopTime;
            string _startTime;
            decimal _milestraveled = 0;
            decimal _milesperhour;
            string _strmilesperhour;
            int totalminutes = 0;
            TimeSpan elapsedtime;
            string[] words;
            //If we get here we assume that we have data files so we are not checking for the file exists.
            //Read the trip file first to do the calcuations and then verify that we have a list driver.
            StreamReader infile = new StreamReader(GlovalVar.TripFile);
            StreamWriter outfile = new StreamWriter(GlovalVar.MissingDriverFile);            
            DriverTrip.CompletedFile _completefile = new CompletedFile();
            while ((_line = infile.ReadLine()) != null)
            {
                //Split the line into its parts
                words = _line.Split(' ');
                _driver = words[1];
                _startTime = words[2];
                _stopTime = words[3];
                _milestraveled = decimal.Round(decimal.Parse(words[4]),0);
                //Calculate elapsedtime
                elapsedtime = DateTime.Parse(_stopTime).Subtract(DateTime.Parse(_startTime));
                //Conver to total minute
                totalminutes = CalculateTimeInMinutes(elapsedtime.ToString());
                //Figure miles per hour
                _milesperhour = (_milestraveled / totalminutes) * 60;
                //Convert to string with correct decimal places 
                _strmilesperhour = string.Format("{0:N0}", _milesperhour);

                    //see if there is a matching drive in the driver file
                    if (!Verifydriver(_driver))
                    {
                        outfile.WriteLine(_driver);
                        _wrtlog.Writetolog("Data No Driver valid in driver's file " + _driver);
                    }
                    else
                    {
                    //write data to completedfile verified driver 
                    if (constrant == true)
                    {
                        if ((_milesperhour < 100) && (_milesperhour > 5))
                        {
                            _rtn = true;
                            _completefile.WritingToFile($"{_driver}: {_milestraveled} @ {_strmilesperhour} mph");
                        }
                    }
                    else
                    {
                        _rtn = true;
                        _completefile.WritingToFile($"{_driver}: {_milestraveled} @ {_strmilesperhour} mph");
                    }
                    }
            }

            //Check the driver file to see if there is anyone left over that does not have any data.            
               if(constrant != true)
                _rtn = CheckDriver();
            return _rtn;
        }
        private int CalculateTimeInMinutes(string passedIntStringTime)
        {
            //Takes a passed in string time and converts it to minutes
            DateTime time = DateTime.Parse(passedIntStringTime);
            return (int)(time - time.Date).TotalMinutes;
        }
        private Boolean Verifydriver(string passedInDriver)
        {
            Boolean _rtn = false;
            DriverTrip.LogEntry _wrtlog = new DriverTrip.LogEntry();
            string[] _driverText = File.ReadAllLines(GlovalVar.DriverFile);
            File.WriteAllText(GlovalVar.DriverFile, String.Empty);
            using(StreamWriter sw = new StreamWriter(GlovalVar.DriverFile))
            {
                
                foreach (string s in _driverText)
                {
                    _rtn = false;
                    if (!s.Equals(passedInDriver))
                    {
                        _rtn = true;
                        sw.WriteLine(s);
                    }
                }
                if (_rtn == false)
                    Console.WriteLine(passedInDriver);
            }
            return _rtn;
        }
        private Boolean CheckDriver()
        {
            //Gets the drivers that do not have a trip and put them in the file with 0 mph
            Boolean _rtn = false;
            DriverTrip.CompletedFile _completefile = new CompletedFile();
            string[] _driverText = File.ReadAllLines(GlovalVar.DriverFile);
            File.WriteAllText(GlovalVar.DriverFile, String.Empty);
            using (StreamWriter sw = new StreamWriter(GlovalVar.DriverFile))
            {
                foreach(string s in _driverText)
                {
                    _completefile.WritingToFile($"{s}: 0 @ 0 mph");                    
                    _rtn = true;
                }
            }
            return _rtn;
        }
    }
}
