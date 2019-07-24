using System.Text;
using System.Xml.Serialization;

namespace DnDLookup.dto.fc5
{
    // ReSharper disable once InconsistentNaming
    public class FC5Spell : IFC5Html
    {
        [XmlElement("classes")] public string Classes { get; set; }
        [XmlElement("components")] public string Components { get; set; }
        [XmlElement("duration")] public string Duration { get; set; }
        [XmlElement("level")] public int Level { get; set; }
        [XmlElement("name")] public string Name { get; set; }
        [XmlElement("range")] public string Range { get; set; }
        [XmlElement("ritual")] public string Ritual { get; set; }
        [XmlElement("roll")] public string[] Roll { get; set; }
        [XmlElement("school")] public string School { get; set; }
        [XmlElement("text")] public string[] Text { get; set; }
        [XmlElement("time")] public string Time { get; set; }
        [XmlAttribute("PS")] public string Ps { get; set; }
        [XmlAttribute("UA")] public string Ua { get; set; }

        public string ToHtml()
        {
            StringBuilder buf = new StringBuilder();

            // TODO

            return buf.ToString();
        }
    }
}