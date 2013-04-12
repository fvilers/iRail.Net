using iRail.Net;
using iRail.Net.Model;
using iRail.Net.Wrappers;
using System;
using System.Threading.Tasks;

namespace TestApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            IHttpClientWrapper httpClient = new HttpClientWrapper();
            ISerializationWrapper serializer = new JsonSerializationWrapper();
            IRailClient client = new RailClient(httpClient, serializer);

            Task.Run(() => TestClientAsync(client)).Wait();

            Console.WriteLine("END");
            Console.Read();
        }

        private async static Task TestClientAsync(IRailClient client)
        {
            //await ListAllStationsAsync(client);
            //await SchedulesAsync(client);
            //await LiveboardAsync(client);
            //await LiveboardByStationIdAsync(client);
            //await VehicleInformationAsync(client);
            await ErrorHandlingdAsync(client);
        }

        private async static Task ErrorHandlingdAsync(IRailClient client)
        {
            const string station = "";
            Departure[] departures;

            try
            {
                departures = await client.LiveboardAsync(station, language: Language.French);
            }
            catch (RailClientException e)
            {
                Console.WriteLine("Error code: {0}", e.ErrorCode);
                Console.WriteLine("Message: {0}", e.Message);
                return;
            }

            foreach (var departure in departures)
            {
                Console.WriteLine("Departure from {0} at {1} with vehicle {2} on platform {3} in direction of {4} (delay {5} seconds)",
                    station, departure.Time, departure.Vehicle, departure.Platform.Normal, departure.Station.Name, departure.Delay);
            }
        }

        private async static Task VehicleInformationAsync(IRailClient client)
        {
            const string vehicleId = "Be.NMBS.P1234";
            var stops = await client.VehiculeAsync(vehicleId, language: Language.French);

            foreach (var stop in stops)
            {
                Console.WriteLine("Vehicle {0} stops at {1} at {2}", vehicleId, stop.Station.Name, stop.Time);
            }
        }

        private async static Task LiveboardByStationIdAsync(IRailClient client)
        {
            const string stationId = "BE.NMBS.008814209";
            var departures = await client.LiveboardByStationIdAsync(stationId, Language.French);

            foreach (var departure in departures)
            {
                Console.WriteLine("Departure from {0} at {1} with vehicle {2} on platform {3} in direction of {4} (delay {5} seconds)",
                    stationId, departure.Time, departure.Vehicle, departure.Platform.Normal, departure.Station.Name, departure.Delay);
            }
        }

        private async static Task LiveboardAsync(IRailClient client)
        {
            const string station = "Nivelles";
            var departures = await client.LiveboardAsync(station, language: Language.French);

            foreach (var departure in departures)
            {
                Console.WriteLine("Departure from {0} at {1} with vehicle {2} on platform {3} in direction of {4} (delay {5} seconds)",
                    station, departure.Time, departure.Vehicle, departure.Platform.Normal, departure.Station.Name, departure.Delay);
            }
        }

        private async static Task SchedulesAsync(IRailClient client)
        {
            var connections = await client.SchedulesAsync("Nivelles", "Alost", DateTime.Now.AddHours(2), TimeSel.Departure, language: Language.French);

            foreach (var connection in connections)
            {
                Console.WriteLine("{0} - Duration: {1} ", connection.Id, connection.Duration);
                Console.WriteLine("Departure from {0} at {1} with vehicle {2} on platform {3} in direction of {4} (delay {5} seconds)",
                    connection.Departure.Station.Name, connection.Departure.Time, connection.Departure.Vehicle, connection.Departure.Platform.Normal, connection.Departure.Direction.Name, connection.Departure.Delay);

                foreach (var via in connection.Vias.Items)
                {

                    Console.WriteLine("Via {0} at {1} with vehicle {2} on platform {3} in direction of {4} (time between {5} seconds)", via.Station.Name, via.Departure.Time, via.Vehicle, via.Departure.Platform.Normal, via.Direction.Name, via.TimeBetween);
                }

                Console.WriteLine("Arrival to {0} at {1} with vehicle {2} on platform {3} in direction of {4} (delay {5} seconds)",
                    connection.Arrival.Station.Name, connection.Arrival.Time, connection.Arrival.Vehicle, connection.Arrival.Platform.Normal, connection.Arrival.Direction.Name, connection.Arrival.Delay);
            }
        }

        private async static Task ListAllStationsAsync(IRailClient client)
        {
            var stations = await client.ListAllStationsAsync(Language.French);

            foreach (var station in stations)
            {
                Console.WriteLine(station.Name);
            }
        }
    }
}
