using System.Xml.Serialization;

namespace DnDLookup.dto.fc5
{
    // ReSharper disable InconsistentNaming
    public class FC5AutoLevel
    {
        [XmlAttribute("level")] public string Level { get; set; }
        [XmlAttribute("UA")] public string UA { get; set; }
        [XmlAttribute("optional")] public string Optional { get; set; }
        [XmlElement("feature")] public FC5Feature[] Features { get; set; }
        [XmlElement("slots")] public string Slots { get; set; }
    }
}