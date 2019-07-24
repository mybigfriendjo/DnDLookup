using System.Xml.Serialization;

namespace DnDLookup.dto.fc5
{
    // ReSharper disable InconsistentNaming
    public class FC5Feature
    {
        [XmlAttribute("UA")] public string UA { get; set; }
        [XmlAttribute("optional")] public string Optional { get; set; }
        [XmlElement("name")] public string Name { get; set; }
        [XmlElement("text")] public string[] Text { get; set; }
        [XmlElement("proficiency")] public string[] Proficiency { get; set; }
        [XmlElement("modifier")] public FC5Modifier[] Modifiers { get; set; }
    }
}