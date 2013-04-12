
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
            get { return Parameters["from"] as string; }
            set
            {
                if (value == null)
                {
                    Parameters.Remove("from");
                }
                else
                {
                    Parameters["from"] = value;
                }
            }
        }

        public string ToStation
        {
            get { return Parameters["to"] as string; }
            set
            {
                if (value == null)
                {
                    Parameters.Remove("to");
                }
                else
                {
                    Parameters["to"] = value;
                }
            }
        }
    }
}
