using System.Xml.Serialization;

namespace DnDLookup.dto.fc5
{
    // ReSharper disable once InconsistentNaming
    public class FC5Background
    {
        [XmlElement("name")] public string[] Name { get; set; }
        [XmlElement("proficiency")] public string[] Proficiency { get; set; }
        [XmlElement("trait")] public FC5Trait[] Traits { get; set; }
    }
}