
namespace iRail.Net.Requests
{
    public class LiveboardRequest : JsonRequestBase
    {
        public LiveboardRequest()
            : base("/liveboard/")
        {
        }

        public string Station
        {
            get { return GetParameter<string>("station"); }
            set { SetParameter("station", value); }
        }

        public bool Fast
        {
            get { return GetParameter<bool>("fast"); }
            set { SetParameter("fast", value); }
        }

        public string StationId
        {
            get { return GetParameter<string>("id"); }
            set { SetParameter("id", value); }
        }
    }
}
