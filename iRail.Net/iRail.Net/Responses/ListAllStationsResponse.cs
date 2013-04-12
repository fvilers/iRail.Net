using iRail.Net.Model;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace iRail.Net.Responses
{
    [XmlRoot(ElementName = "stations", Namespace = "", IsNullable = false)]
    public class ListAllStationsResponse : ResponseBase
    {
        [XmlElement("station", Form = XmlSchemaForm.Unqualified, IsNullable = true)]
        public Station[] Stations { get; set; }
    }
}
