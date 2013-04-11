using System;
using System.Xml.Serialization;

namespace iRail.Net.Model
{
    [Serializable]
    [XmlTypeAttribute(AnonymousType = true)]
    public class Station
    {
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }

        [XmlAttribute(AttributeName = "locationX")]
        public decimal LocationX { get; set; }

        [XmlAttribute(AttributeName = "locationY")]
        public decimal LocationY { get; set; }

        [XmlAttribute(AttributeName = "standardname")]
        public string StandardName { get; set; }

        [XmlTextAttribute]
        public string Value { get; set; }

        public override string ToString()
        {
            return Value;
        }
    }
}