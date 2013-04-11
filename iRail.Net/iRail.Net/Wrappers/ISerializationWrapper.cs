namespace iRail.Net.Wrappers
{
    public interface ISerializationWrapper
    {
        T Deserialize<T>(string value);
    }
}