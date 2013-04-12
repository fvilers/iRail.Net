using iRail.Net.Model;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace iRail.Net.Responses
{
    [XmlRootAttribute(ElementName = "connections", Namespace = "", IsNullable = false)]
    public class SchedulesResponse : ResponseBase
    {
        [XmlElement("connection", Form = XmlSchemaForm.Unqualified)]
        public Connection[] Connections { get; set; }
    }
}
