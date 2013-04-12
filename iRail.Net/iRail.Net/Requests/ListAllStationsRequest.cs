
namespace iRail.Net.Requests
{
    public class ListAllStationsRequest : JsonRequestBase
    {
        public ListAllStationsRequest()
            : base("/stations/")
        {
        }
    }
}
