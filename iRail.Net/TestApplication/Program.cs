using System;
using System.Threading.Tasks;
using iRail.Net;
using iRail.Net.Model;
using iRail.Net.Wrappers;

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
            var stations = await client.ListAllStationsAsync(Lang.Fr);

            foreach (var station in stations)
            {
                Console.WriteLine(station);
            }
        }
    }
}
