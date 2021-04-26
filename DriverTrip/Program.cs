using System;
using System.IO;


namespace DriverTrip
{    
    class Program
    {
        
        static void Main(string[] args)
        {
            cleanfiles();
            DriverTrip.LogEntry _wrtlog = new DriverTrip.LogEntry();
            DriverTrip.ProcessFiles _processFiles = new ProcessFiles();
            //Check to see if file exists -- if it does then start processing
            //string filename = @"NewDriver.txt";            
            string _msg = "";
            _msg = $"------------------------- Program Strat Time {DateTime.Now}";
            _wrtlog.Writetolog(_msg);
            if (File.Exists(GlovalVar.Filename))
            {
                _msg = $"------------- Processing Start Time {DateTime.Now}";
                _wrtlog.Writetolog(_msg);
                if (_processFiles.Processingfiles(GlovalVar.Filename))
                {
                    _msg = $"------------- Processing Completed End Time {DateTime.Now}";
                }
                else
                {                                       
                    _msg = $"------------- Processing Completed End Time {DateTime.Now}";
                }
                _wrtlog.Writetolog(_msg);
            }
            else
            {
                _msg ="-> -> -> -> File does not exist<- <- <- <-";
                _wrtlog.Writetolog(_msg);
            }
            
            _msg = $"------------------------- Program End Time {DateTime.Now}";
            _wrtlog.Writetolog(_msg);
        }
        public static void cleanfiles()
        {
           //Make sure we start with a clean file              
           if(File.Exists(GlovalVar.DriverFile))
            {
                File.Delete(GlovalVar.DriverFile);
            }

            //Make sure we start with a clean file              
            if (File.Exists(GlovalVar.TripFile))
            {
                File.Delete(GlovalVar.TripFile);
            }

            //Make sure we start with a clean file              
            if (File.Exists(GlovalVar.CompletedSortedFile))
            {
                File.Delete(GlovalVar.CompletedSortedFile);
            }

            //Make sure we start with a clean file              
            if (File.Exists(GlovalVar.MissingDriverFile))
            {
                File.Delete(GlovalVar.MissingDriverFile);
            }

            //Make sure we start with a clean file              
            if (File.Exists(GlovalVar.MissingTripFile))
            {
                File.Delete(GlovalVar.MissingTripFile);
            }
            return;
        }

    }
}
