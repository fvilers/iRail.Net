using Newtonsoft.Json;
using System.Threading.Tasks;

namespace iRail.Net.Wrappers
{
    public class JsonSerializationWrapper : ISerializationWrapper
    {
        public T Deserialize<T>(string value)
        {
            return JsonConvert.DeserializeObject<T>(value);
        }

        public Task<T> DeserializeAsync<T>(string value)
        {
            return JsonConvert.DeserializeObjectAsync<T>(value);
        }
    }
}
