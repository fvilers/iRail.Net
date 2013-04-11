using iRail.Net.Model;

namespace iRail.Net.Requests
{
    public class ListAllStationsRequest : RequestBase
    {
        public ListAllStationsRequest()
            : base("/stations/")
        {
        }

        public Lang Lang
        {
            get { return Parameters["lang"] as Lang; }
            set { Parameters["lang"] = value; }
        }
    }
}
