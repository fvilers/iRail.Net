using System;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace iRail.Net.Model
{
    [Serializable]
    [XmlType(AnonymousType = true)]
    public class CollectionStop
    {
        [XmlElement("stop", Form = XmlSchemaForm.Unqualified)]
        public Stop[] Stop { get; set; }

        [XmlAttribute("number")]
        public int Number { get; set; }
    }
}