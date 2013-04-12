using System;

namespace iRail.Net.Model
{
    public class TransportType
    {
        private static readonly TransportType Train = new TransportType("train");
        private static readonly TransportType Bus = new TransportType("bus");
        private static readonly TransportType Taxi = new TransportType("taxi");

        private readonly string _transportType;

        private TransportType(string transportType)
        {
            if (transportType == null) throw new ArgumentNullException("transportType");
            _transportType = transportType;
        }
    }
}
