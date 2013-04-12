
using iRail.Net.Model;
using System;

namespace iRail.Net.Requests
{
    public class SchedulesRequest : JsonRequestBase
    {
        public SchedulesRequest(string fromStation, string toStation)
            : base("/connections/")
        {
            if (fromStation == null) throw new ArgumentNullException("fromStation");
            if (toStation == null) throw new ArgumentNullException("toStation");

            FromStation = fromStation;
            ToStation = toStation;
        }

        public string FromStation
        {
            get { return GetParameter<string>("from"); }
            private set { SetParameter("from", value); }
        }

        public string ToStation
        {
            get { return GetParameter<string>("to"); }
            private set { SetParameter("to", value); }
        }

        public string Date
        {
            get { return GetParameter<string>("date"); }
            set { SetParameter("date", value); }
        }

        public string Time
        {
            get { return GetParameter<string>("time"); }
            set { SetParameter("time", value); }
        }

        public TimeSel TimeSel
        {
            get { return GetParameter<TimeSel>("timeSel"); }
            set { SetParameter("timeSel", value); }
        }

        public TransportType TransportType
        {
            get { return GetParameter<TransportType>("typeOfTransport"); }
            set { SetParameter("typeOfTransport", value); }
        }
    }
}
