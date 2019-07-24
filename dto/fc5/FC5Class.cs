using System.Xml.Serialization;

namespace DnDLookup.dto.fc5
{
    // ReSharper disable once InconsistentNaming
    public class FC5Class
    {
        [XmlElement("name")] public string Name { get; set; }
        [XmlElement("hd")] public int HitDice { get; set; }
        [XmlElement("proficiency")] public string Proficiency { get; set; }
        [XmlElement("spellAbility")] public string SpellAbility { get; set; }
        [XmlElement("autolevel")] public FC5AutoLevel[] AutoLevels { get; set; }
    }
}