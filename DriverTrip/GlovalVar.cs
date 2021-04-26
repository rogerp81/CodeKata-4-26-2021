using System;
using System.Collections.Generic;
using System.Text;

namespace DriverTrip
{
    class GlovalVar
    {
        public const string Filename = @"NewDriver.txt";
        public const string DriverFile = @"Driverfile.txt";
        public const string TripFile = @"TripFile.Txt";
        public const string MissingDriverFile = @"MissingDriverFile.txt";
        public const string MissingTripFile = @"MissingTripFile.txt";
        public const string CompletedSortedFile = @"CompletedFile.txt";
        private Int64 _totaldrivers;
        private Int64 _totaltrips; 
        public Int64 TotalDrivers
        {
            get
            {
                return _totaldrivers;
            }
            set
            {
                _totaldrivers = value;
            }
        }
        public Int64 TotalTrips
        {
            get
            {
                return _totaltrips;
            }
            set
            {
                _totaltrips = value;
            }
        }
    }
}
