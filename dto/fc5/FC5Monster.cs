using System.Text;
using System.Xml.Serialization;

namespace DnDLookup.dto.fc5
{
    // ReSharper disable InconsistentNaming
    public class FC5Monster : IFC5Html
    {
        [XmlElement("name")] public string Name { get; set; }
        [XmlElement("size")] public string Size { get; set; }
        [XmlElement("type")] public string Type { get; set; }
        [XmlElement("alignment")] public string Alignment { get; set; }
        [XmlElement("ac")] public string AC { get; set; }
        [XmlElement("hp")] public string HP { get; set; }
        [XmlElement("speed")] public string Speed { get; set; }
        [XmlElement("str")] public int Strengh { get; set; }
        [XmlElement("dex")] public int Dexterity { get; set; }
        [XmlElement("con")] public int Constitution { get; set; }
        [XmlElement("int")] public int Intelligence { get; set; }
        [XmlElement("wis")] public int Wisdom { get; set; }
        [XmlElement("cha")] public int Charisma { get; set; }
        [XmlElement("save")] public string Save { get; set; }
        [XmlElement("skill")] public string Skill { get; set; }
        [XmlElement("resist")] public string Resist { get; set; }
        [XmlElement("vulnerable")] public string Vulnerable { get; set; }
        [XmlElement("immune")] public string Immune { get; set; }
        [XmlElement("conditionImmune")] public string ConditionImmune { get; set; }
        [XmlElement("senses")] public string Senses { get; set; }
        [XmlElement("passive")] public string Passive { get; set; }
        [XmlElement("languages")] public string Languages { get; set; }
        [XmlElement("cr")] public string CR { get; set; }
        [XmlElement("trait")] public FC5Trait[] Traits { get; set; }
        [XmlElement("action")] public FC5Action[] Actions { get; set; }
        [XmlElement("legendary")] public FC5Legendary[] Legendaries { get; set; }
        [XmlElement("spells")] public string Spells { get; set; }
        [XmlElement("description")] public string Description { get; set; }
        [XmlElement("slots")] public string Slots { get; set; }
        [XmlElement("reaction")] public FC5Reaction Reaction { get; set; }

        public string ToHtml()
        {
            StringBuilder buf = new StringBuilder();

            // TODO

            return buf.ToString();
        }
    }
}