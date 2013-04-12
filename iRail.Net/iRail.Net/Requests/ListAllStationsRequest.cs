using iRail.Net.Model;

namespace iRail.Net.Requests
{
    public class ListAllStationsRequest : RequestBase
    {
        public ListAllStationsRequest()
            : base("/stations/")
        {
        }

        public Language Lang
        {
            get { return GetParameter<Language>("lang"); }
            set { SetParameter("lang", value); }
        }
    }
}
