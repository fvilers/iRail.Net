using System;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace iRail.Net.Model
{
    [Serializable]
    [XmlType(AnonymousType = true)]
    public class Liveboard
    {
        [XmlElementAttribute("departure", Form = XmlSchemaForm.Unqualified)]
        public Departure[] Departures { get; set; }

        [XmlAttribute("number")]
        public string Number { get; set; }
    }
}
