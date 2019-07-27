using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using DnDLookup.Properties;

namespace DnDLookup.dto.fc5
{
    // ReSharper disable once InconsistentNaming
    public class FC5Spell : FC5Html
    {
        private static readonly Dictionary<string, string> spellSchools = new Dictionary<string, string>
        {
            {"A", "Abjuration"},
            {"C", "Conjuration"},
            {"D", "Divination"},
            {"EN", "Enchantment"},
            {"EV", "Evocation"},
            {"I", "Illusion"},
            {"N", "Necromancy"},
            {"T", "Transmutation"}
        };

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

        public override string ToHtml()
        {
            StringBuilder buf = new StringBuilder();

            buf.AppendLine("<div style=\"margin:10px\">");
            buf.AppendLine("<p>");
            buf.Append("<h2>").Append(Name).AppendLine("</h2>");

            string classLevel;

            if (Level == 0)
            {
                classLevel = spellSchools[School] + " cantrip";
            }
            else
            {
                classLevel = "" + Level;
                switch (Level)
                {
                    case 1:
                        classLevel += "st";
                        break;
                    case 2:
                        classLevel += "nd";
                        break;
                    case 3:
                        classLevel += "rd";
                        break;
                    default:
                        classLevel += "th";
                        break;
                }

                classLevel += "-level " + spellSchools[School].ToLower();
            }

            buf.Append("<span class=\"italic\">").Append(classLevel).AppendLine("</span></p>");
            buf.AppendLine("</p>");
            buf.AppendLine("<p>");

            if (!string.IsNullOrWhiteSpace(Time))
            {
                buf.AppendLine("<span class=\"bold\">Casting Time:</span> ").Append(Time).Append("<br/>");
            }

            if (!string.IsNullOrWhiteSpace(Range))
            {
                buf.AppendLine("<span class=\"bold\">Range:</span> ").Append(Range).Append("<br/>");
            }

            if (!string.IsNullOrWhiteSpace(Components))
            {
                buf.AppendLine("<span class=\"bold\">Components:</span> ").Append(Components).Append("<br/>");
            }

            if (!string.IsNullOrWhiteSpace(Duration))
            {
                buf.AppendLine("<span class=\"bold\">Duration:</span> ").Append(Duration).Append("<br/>");
            }

            buf.AppendLine("</p>");
            buf.AppendLine("<p>");

            bool first = true;
            foreach (string paragraph in Text)
            {
                if (first)
                {
                    first = false;
                }
                else
                {
                    buf.Append("&nbsp;&nbsp;");
                }

                if (paragraph.StartsWith("At Higher Levels", StringComparison.OrdinalIgnoreCase))
                {
                    buf.Append("<span class=\"bold\">").Append("At Higher Levels:").Append("</span>").AppendLine(paragraph.Substring(17));
                }
                else
                {
                    buf.AppendLine(paragraph);
                }

                buf.Append("<br />");
            }

            buf.AppendLine("</p>");
            buf.AppendLine("<br />");
            buf.AppendLine("</div>");

            string template = Resources.index;

            return template.Replace("{replace:title}", "Spell").Replace("{replace:body}", buf.ToString());
        }
    }
}