using System.Xml.Serialization;

// ReSharper disable InconsistentNaming

namespace DnDLookup.dto.fc5
{
    [XmlRoot("compendium")]
    public class FC5Compendium
    {
        [XmlElement("background")] public FC5Background[] Backgrounds { get; set; }

        [XmlElement("class")] public FC5Class[] Classes { get; set; }

        [XmlElement("feat")] public FC5Feat[] Feats { get; set; }

        [XmlElement("item")] public FC5Item[] Items { get; set; }

        [XmlElement("monster")] public FC5Monster[] Monsters { get; set; }

        [XmlElement("race")] public FC5Race[] Races { get; set; }

        [XmlElement("spell")] public FC5Spell[] Spells { get; set; }

        [XmlElement("spellList")] public FC5SpellList[] SpellLists { get; set; }
    }
}