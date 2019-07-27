using System.Xml.Serialization;

namespace DnDLookup.dto.fc5
{
    // ReSharper disable once InconsistentNaming
    public class FC5Modifier
    {
        [XmlAttribute("category")] public string Category { get; set; }
        [XmlText] public string Modifier { get; set; }
    }
}