using System;
using System.Xml.Serialization;

namespace iRail.Net.Model
{
    [Serializable]
    [XmlType(AnonymousType = true)]
    public class ViaCollection
    {
        [XmlElement("via", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public Via[] Via { get; set; }

        [XmlAttribute("number")]
        public int Number { get; set; }
    }
}
