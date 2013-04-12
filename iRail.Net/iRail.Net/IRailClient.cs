using iRail.Net.Model;
using System;
using System.Threading.Tasks;

namespace iRail.Net
{
    public interface IRailClient
    {
        Task<Station[]> ListAllStationsAsync(Language lang);
        Task<Connection[]> SchedulesAsync(string fromStation, string toStation, DateTime? when = null, TimeSel timeSel = null, TransportType transportType = null);
        Task<Liveboard> LiveboardAsync(string station, bool? fast = null);
        Task<Liveboard> LiveboardByStationIdAsync(string stationId);
        Task<VehicleInformation> VehiculeAsync(string vehicleId, bool? fast = null);
    }
}