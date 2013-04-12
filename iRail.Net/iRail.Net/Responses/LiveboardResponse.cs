using iRail.Net.Model;
using System;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace iRail.Net.Responses
{
    [Serializable]
    [XmlRoot("liveboard", Namespace = "", IsNullable = true)]
    public class LiveboardResponse : ResponseBase
    {
        [XmlElement("station", IsNullable = true)]
        public Station Station { get; set; }

        [XmlElementAttribute("departures", Form = XmlSchemaForm.Unqualified)]
        public Liveboard Liveboard { get; set; }

    }
}
