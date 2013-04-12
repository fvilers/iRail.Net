using iRail.Net.Model;
using iRail.Net.Requests;
using iRail.Net.Responses;
using iRail.Net.Wrappers;
using System;
using System.Threading.Tasks;

namespace iRail.Net
{
    // TODO: NuGet package
    public class RailClient : IRailClient
    {
        private readonly IHttpClientWrapper _httpClient;
        private readonly ISerializationWrapper _serializer;

        public RailClient(IHttpClientWrapper httpClient, ISerializationWrapper serializer)
        {
            if (httpClient == null) throw new ArgumentNullException("httpClient");
            if (serializer == null) throw new ArgumentNullException("serializer");
            _httpClient = httpClient;
            _serializer = serializer;
        }

        public async Task<Station[]> ListAllStationsAsync(Language language = null)
        {
            if (language == null) throw new ArgumentNullException("language");

            var request = new ListAllStationsRequest
            {
                Language = language
            };
            var response = await GetAsync<ListAllStationsResponse>(request);

            return response.Stations;
        }

        // TODO: find out how to use transportType
        public async Task<Connection[]> SchedulesAsync(string fromStation, string toStation, DateTime? when = null, TimeSel timeSel = null, TransportType transportType = null, Language language = null)
        {
            if (fromStation == null) throw new ArgumentNullException("fromStation");
            if (toStation == null) throw new ArgumentNullException("toStation");

            var request = new SchedulesRequest(fromStation, toStation)
            {
                TimeSel = timeSel,
                TransportType = transportType,
                Language = language
            };

            if (when.HasValue)
            {
                request.Date = String.Format("{0:ddMMyy}", when.Value);
                request.Time = String.Format("{0:HHmm}", when.Value);
            }

            var response = await GetAsync<SchedulesResponse>(request);

            return response.Connections;
        }

        public async Task<Departure[]> LiveboardAsync(string station, bool? fast = null, Language language = null)
        {
            if (station == null) throw new ArgumentNullException("station");

            var request = new LiveboardRequest(station)
            {
                Fast = fast,
                Language = language
            };

            var response = await GetAsync<LiveboardResponse>(request);

            return response.Departures.Items;
        }

        public async Task<Departure[]> LiveboardByStationIdAsync(string stationId, Language language = null)
        {
            if (stationId == null) throw new ArgumentNullException("stationId");

            var request = new LiveboardByStationIdRequest(stationId)
            {
                Language = language
            };
            var response = await GetAsync<LiveboardResponse>(request);

            return response.Departures.Items;
        }

        public async Task<Stop[]> VehiculeAsync(string vehicleId, bool? fast = null, Language language = null)
        {
            if (vehicleId == null) throw new ArgumentNullException("vehicleId");

            var request = new VehicleRequest(vehicleId)
            {
                Fast = fast,
                Language = language
            };

            var response = await GetAsync<VehicleResponse>(request);

            return response.Stops.Items;
        }

        private async Task<TResponse> GetAsync<TResponse>(JsonRequestBase request)
        {
            var result = await _httpClient.TryGetAsync(request);
            
            if (!result.Item1)
            {
                throw new RailClientException(await _serializer.DeserializeAsync<ErrorResponse>(result.Item2));
            }

            return await _serializer.DeserializeAsync<TResponse>(result.Item2);
        }
    }

    public class RailClientException : Exception
    {
        public int ErrorCode { get; private set; }

        public RailClientException(ErrorResponse errorResponse)
            : base(errorResponse.Message)
        {
            ErrorCode = errorResponse.ErrorCode;
        }
    }
}
