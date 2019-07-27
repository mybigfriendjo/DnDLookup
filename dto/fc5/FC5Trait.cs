using System.Xml.Serialization;

namespace DnDLookup.dto.fc5
{
    // ReSharper disable once InconsistentNaming
    public class FC5Trait
    {
        [XmlElement("name")] public string Name { get; set; }
        [XmlElement("text")] public string[] Texts { get; set; }
        [XmlElement("attack")] public string[] Attacks { get; set; }
    }
}