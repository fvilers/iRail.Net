using iRail.Net.Model;
using System;
using System.Threading.Tasks;

namespace iRail.Net
{
    public interface IRailClient
    {
        Task<Station[]> ListAllStationsAsync(Language language = null);
        Task<Connection[]> SchedulesAsync(string fromStation, string toStation, DateTime? when = null, TimeSel timeSel = null, TransportType transportType = null, Language language = null);
        Task<Liveboard> LiveboardAsync(string station, bool? fast = null, Language language = null);
        Task<Liveboard> LiveboardByStationIdAsync(string stationId, Language language = null);
        Task<VehicleInformation> VehiculeAsync(string vehicleId, bool? fast = null, Language language = null);
    }
}