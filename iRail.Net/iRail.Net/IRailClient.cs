using iRail.Net.Model;
using System;
using System.Threading.Tasks;

namespace iRail.Net
{
    public interface IRailClient
    {
        Task<Station[]> ListAllStationsAsync(Lang lang);
        Task<Connection[]> SchedulesAsync(string fromStation, string toStation, DateTime? when = null, TimeSel timeSel = null, TransportType transportType = null);
    }
}