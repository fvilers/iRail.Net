using System;

namespace iRail.Net.Model
{
    public class TimeSel
    {
        public static readonly TimeSel Departure = new TimeSel("depart");
        public static readonly TimeSel Arrival = new TimeSel("arrive");

        private readonly string _timeSel;

        private TimeSel(string timeSel)
        {
            if (timeSel == null) throw new ArgumentNullException("timeSel");
            _timeSel = timeSel;
        }

        public override string ToString()
        {
            return _timeSel;
        }
    }
}
