using System;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace iRail.Net.Model
{
    public class VehicleInformation
    {
        [XmlElement("vehicle", Form = XmlSchemaForm.Unqualified, IsNullable = true)]
        public Vehicle Vehicle { get; set; }

        [XmlElement("stops", Form = XmlSchemaForm.Unqualified)]
        public CollectionStop Stops { get; set; }

    }

    [SerializableAttribute]
    [XmlType(AnonymousType = true)]
    public class CollectionStop
    {
        [XmlElement("stop", Form = XmlSchemaForm.Unqualified)]
        public Stop[] Stop { get; set; }

        [XmlAttribute("number")]
        public int Number { get; set; }
    }

    public class Stop
    {
        [XmlElement("station", Form = XmlSchemaForm.Unqualified, IsNullable = true)]
        public Station Station { get; set; }

        [XmlElementAttribute("time", Form = XmlSchemaForm.Unqualified, IsNullable = true)]
        public Time Time { get; set; }

        [XmlAttributeAttribute("id")]
        public string Id { get; set; }

        /// <remarks/>
        [XmlAttributeAttribute("delay")]
        public int Delay { get; set; }

    }

    [SerializableAttribute]
    [XmlTypeAttribute(AnonymousType = true)]
    public class Vehicle
    {
        [XmlAttribute("locationX")]
        public string LocationX { get; set; }

        [XmlAttribute("locationY")]
        public string LocationY { get; set; }

        [XmlText]
        public string Value { get; set; }

        public override string ToString()
        {
            return Value;
        }
    }
}
