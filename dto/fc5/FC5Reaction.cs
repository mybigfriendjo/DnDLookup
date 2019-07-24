using System.Xml.Serialization;

namespace DnDLookup.dto.fc5
{
    // ReSharper disable once InconsistentNaming
    public class FC5Reaction
    {
        [XmlElement("name")] public string Name { get; set; }
        [XmlElement("text")] public string[] Text { get; set; }
        [XmlElement("attack")] public string[] Attack { get; set; }
    }
}