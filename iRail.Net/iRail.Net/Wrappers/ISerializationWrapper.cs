using System.Threading.Tasks;

namespace iRail.Net.Wrappers
{
    public interface ISerializationWrapper
    {
        T Deserialize<T>(string value);
        Task<T> DeserializeAsync<T>(string value);
    }
}