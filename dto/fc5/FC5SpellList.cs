using System.Xml.Serialization;

namespace DnDLookup.dto.fc5
{
    // ReSharper disable once InconsistentNaming
    public class FC5SpellList
    {
        [XmlAttribute("class")] public string Class { get; set; }

        [XmlElement("index")] public FC5SpellListIndex[] Indexes { get; set; }
    }
}