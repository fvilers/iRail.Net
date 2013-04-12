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
            ISerializationWrapper serializer = new XmlSerializationWrapper();
            IRailClient client = new RailClient(httpClient, serializer);

            Task.Run(() => TestClientAsync(client)).Wait();

            Console.WriteLine("END");
            Console.Read();
        }

        private async static Task TestClientAsync(IRailClient client)
        {
            //await ListAllStationsAsync(client);
            await SchedulesAsync(client);
        }

        private async static Task SchedulesAsync(IRailClient client)
        {
            var connections = await client.SchedulesAsync("Nivelles", "Alost");

            foreach (var connection in connections)
            {
                Console.WriteLine("{0} - Duration: {1} ", connection.Id, new TimeSpan(0, 0, connection.Duration));
                Console.WriteLine("Departure from {0} at {1} with vehicle {2} on platform {3} in direction of {4} (delay {5} seconds)",
                    connection.Departure.Station, connection.Departure.Time.Formatted, connection.Departure.Vehicle, connection.Departure.Platform, connection.Departure.Direction, connection.Departure.Delay);

                foreach (var via in connection.Vias.Via)
                {

                    Console.WriteLine("Via {0} at {1} with vehicle {2} on platform {3} in direction of {4} (time between {5} seconds)", via.Station, via.Departure.Time.Formatted, via.Vehicle, via.Departure.Platform, via.Direction, via.TimeBetween);
                }

                Console.WriteLine("Arrival to {0} at {1} with vehicle {2} on platform {3} in direction of {4} (delay {5} seconds)",
                    connection.Arrival.Station, connection.Arrival.Time.Formatted, connection.Arrival.Vehicle, connection.Arrival.Platform, connection.Arrival.Direction, connection.Arrival.Delay);
            }
        }

        private async static Task ListAllStationsAsync(IRailClient client)
        {
            var stations = await client.ListAllStationsAsync(Lang.Fr);

            foreach (var station in stations)
            {
                Console.WriteLine(station);
            }
        }
    }
}
