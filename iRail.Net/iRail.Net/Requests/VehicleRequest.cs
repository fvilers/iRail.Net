
namespace iRail.Net.Requests
{
    public class VehicleRequest : RequestBase
    {
        public VehicleRequest()
            : base("/vehicle/")
        {
        }

        public string VehicleId
        {
            get { return GetParameter<string>("id"); }
            set { SetParameter("id", value); }
        }

        public bool Fast
        {
            get { return GetParameter<bool>("fast"); }
            set { SetParameter("fast", value); }
        }
    }
}
