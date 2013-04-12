using System.IO;
using System.Xml.Serialization;

namespace iRail.Net.Wrappers
{
    public class XmlSerializationWrapper : ISerializationWrapper
    {
        public T Deserialize<T>(string value)
        {
            var serializer = new XmlSerializer(typeof(T));
            
            using (var reader = new StringReader(value))
            {
                return (T)serializer.Deserialize(reader);
            }
        }
    }
}
