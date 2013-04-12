
using iRail.Net.Model;

namespace iRail.Net.Requests
{
    public class SchedulesRequest : RequestBase
    {
        public SchedulesRequest()
            : base("/connections/")
        {
        }

        public string FromStation
        {
            get { return GetParameter<string>("from"); }
            set { SetParameter("from", value); }
        }

        public string ToStation
        {
            get { return GetParameter<string>("to"); }
            set { SetParameter("to", value); }
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
    }
}
