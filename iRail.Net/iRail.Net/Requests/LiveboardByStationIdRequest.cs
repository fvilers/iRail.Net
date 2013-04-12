using System;

namespace iRail.Net.Requests
{
    public class LiveboardByStationIdRequest : JsonRequestBase
    {
        public LiveboardByStationIdRequest(string stationId)
            : base("/liveboard/")
        {
            if (stationId == null) throw new ArgumentNullException("stationId");
            StationId = stationId;
        }

        public string StationId
        {
            get { return GetParameter<string>("id"); }
            private set { SetParameter("id", value); }
        }

        public bool? Fast
        {
            get { return GetParameter<bool?>("fast"); }
            set { SetParameter("fast", value); }
        }
    }
}
