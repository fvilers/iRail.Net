
using System;

namespace iRail.Net.Requests
{
    public class LiveboardRequest : JsonRequestBase
    {
        public LiveboardRequest(string station)
            : base("/liveboard/")
        {
            if (station == null) throw new ArgumentNullException("station");
            Station = station;
        }

        public string Station
        {
            get { return GetParameter<string>("station"); }
            private set { SetParameter("station", value); }
        }

        public bool? Fast
        {
            get { return GetParameter<bool?>("fast"); }
            set { SetParameter("fast", value); }
        }

        public string StationId
        {
            get { return GetParameter<string>("id"); }
            set { SetParameter("id", value); }
        }
    }
}
