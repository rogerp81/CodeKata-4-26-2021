using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace DriverTrip
{
    class CompletedFile
    {
        public Boolean WritingToFile(string completedstring)
        {
            Boolean _rtn = true;
            using (StreamWriter oFile = File.AppendText(GlovalVar.CompletedSortedFile))
            {
                oFile.WriteLine(completedstring);
            }
            return _rtn;
        }
        public void sorted()
        {
            string[] _tripsmph = System.IO.File.ReadAllLines(GlovalVar.CompletedSortedFile);
            int sortfield = 1;
            foreach(string str in RunQuery(_tripsmph,sortfield))
            {
                Console.WriteLine(str);
            }
        }
        private IEnumerable<string> RunQuery(IEnumerable<string> source, int num)
        {
            //Split the string into fields
            //decimal.Parse(words[4]);
            var words = from line in source
                        let fields = line.Split(' ')
                        orderby (decimal.Parse(fields[num])) descending
                select line;
            return words;
        }
    }
}
