﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using DnDLookup.Properties;

namespace DnDLookup.dto.fc5
{
    // ReSharper disable InconsistentNaming
    public class FC5Monster : FC5Html
    {
        private static readonly Dictionary<string, string> monsterSizes = new Dictionary<string, string>
        {
            {"T", "Tiny"},
            {"S", "Small"},
            {"M", "Medium"},
            {"L", "Large"},
            {"H", "Huge"},
            {"G", "Gargantuan"}
        };

        private static readonly Dictionary<string, string> xpValues = new Dictionary<string, string>()
        {
            {"0", "0 or 10"},
            {"1/8", "25"},
            {"1/4", "50"},
            {"1/2", "100"},
            {"1", "200"},
            {"2", "450"},
            {"3", "700"},
            {"4", "1,100"},
            {"5", "1,800"},
            {"6", "2,300"},
            {"7", "2,900"},
            {"8", "3,900"},
            {"9", "5,000"},
            {"10", "5,900"},
            {"11", "7,200"},
            {"12", "8,400"},
            {"13", "10,000"},
            {"14", "11,500"},
            {"15", "13,000"},
            {"16", "15,000"},
            {"17", "18,000"},
            {"18", "20,000"},
            {"19", "22,000"},
            {"20", "25,000"},
            {"21", "33,000"},
            {"22", "41,000"},
            {"23", "50,000"},
            {"24", "62,000"},
            {"25", "75,000"},
            {"26", "90,000"},
            {"27", "105,000"},
            {"28", "120,000"},
            {"29", "135,000"},
            {"30", "155,000"}
        };

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
        [XmlElement("passive")] public int Passive { get; set; }
        [XmlElement("languages")] public string Languages { get; set; }
        [XmlElement("cr")] public string CR { get; set; }
        [XmlElement("trait")] public FC5Trait[] Traits { get; set; }
        [XmlElement("action")] public FC5Action[] Actions { get; set; }
        [XmlElement("legendary")] public FC5Legendary[] Legendaries { get; set; }
        [XmlElement("spells")] public string Spells { get; set; }
        [XmlElement("description")] public string Description { get; set; }
        [XmlElement("slots")] public string Slots { get; set; }
        [XmlElement("reaction")] public FC5Reaction Reaction { get; set; }

        public override string ToHtml()
        {
            StringBuilder buf = new StringBuilder();

            buf.AppendLine("<div style=\"margin:10px\">");
            buf.AppendLine("<p>");
            buf.Append("<h2>").Append(Name).AppendLine("</h2>");
            buf.Append("<span class=\"italic\">");
            buf.Append(monsterSizes[Size]).Append(" ").Append(Type).Append(", ").Append(Alignment);
            buf.AppendLine("</span>");
            buf.AppendLine("</p>");

            buf.AppendLine("<hr />");

            buf.AppendLine("<p style=\"color: #58180D\">");
            buf.Append("<span class=\"bold\">Armor Class</span> ").Append(AC).AppendLine("<br/>");
            buf.Append("<span class=\"bold\">Hit Points</span> ").Append(HP).AppendLine("<br/>");
            buf.Append("<span class=\"bold\">Speed</span> ").Append(Speed).AppendLine("");
            buf.AppendLine("</p>");

            buf.AppendLine("<hr />");

            buf.AppendLine("<p>");
            buf.AppendLine("<table width=\"100%\">");
            buf.AppendLine("<tr><th>STR</th><th>DEX</th><th>CON</th><th>INT</th><th>WIS</th><th>CHA</th></tr>");
            buf.Append("<tr>");

            buf.Append("<td>").Append(Strengh).Append(" (").Append(CalcMod(Strengh)).Append(")</td>");
            buf.Append("<td>").Append(Dexterity).Append(" (").Append(CalcMod(Dexterity)).Append(")</td>");
            buf.Append("<td>").Append(Constitution).Append(" (").Append(CalcMod(Constitution)).Append(")</td>");
            buf.Append("<td>").Append(Intelligence).Append(" (").Append(CalcMod(Intelligence)).Append(")</td>");
            buf.Append("<td>").Append(Wisdom).Append(" (").Append(CalcMod(Wisdom)).Append(")</td>");
            buf.Append("<td>").Append(Charisma).Append(" (").Append(CalcMod(Charisma)).Append(")</td>");
            buf.AppendLine("</tr>");
            buf.AppendLine("</table>");
            buf.AppendLine("</p>");

            buf.AppendLine("<hr />");

            buf.AppendLine("<p style=\"color: #58180D\">");
            if (!string.IsNullOrWhiteSpace(Save))
            {
                buf.Append("<span class=\"bold\">Saving Throws</span>").Append(" ").Append(Save).Append("<br />");
            }

            if (!string.IsNullOrWhiteSpace(Skill))
            {
                buf.Append("<span class=\"bold\">Skills</span>").Append(" ").Append(Skill).Append("<br />");
            }

            if (!string.IsNullOrWhiteSpace(Resist))
            {
                buf.Append("<span class=\"bold\">Damage Resistances</span>").Append(" ").Append(Resist).Append("<br />");
            }

            if (!string.IsNullOrWhiteSpace(Vulnerable))
            {
                buf.Append("<span class=\"bold\">Damage Vulnerabilities</span>").Append(" ").Append(Vulnerable).Append("<br />");
            }

            if (!string.IsNullOrWhiteSpace(Immune))
            {
                buf.Append("<span class=\"bold\">Damage Immunities</span>").Append(" ").Append(Immune).Append("<br />");
            }

            if (!string.IsNullOrWhiteSpace(ConditionImmune))
            {
                buf.Append("<span class=\"bold\">Condition Immunities</span>").Append(" ").Append(ConditionImmune).Append("<br />");
            }

            if (!string.IsNullOrWhiteSpace(Senses))
            {
                buf.Append("<span class=\"bold\">Senses</span>").Append(" ").Append(Senses).Append(", passive Perception ").Append(Passive)
                   .Append("<br />"); // passive
            }

            if (!string.IsNullOrWhiteSpace(Languages))
            {
                buf.Append("<span class=\"bold\">Languages</span>").Append(" ").Append(Languages).Append("<br />");
            }

            buf.Append("<span class=\"bold\">CR</span>").Append(" ").Append(CR).Append(" (").Append(xpValues[CR]).Append(" XP)<br />");
            buf.AppendLine("</p>");

            buf.AppendLine("<hr />");

            // traits

            if (Traits != null && Traits.Length > 0)
            {
                buf.Append("<p>");
                foreach (FC5Trait trait in Traits)
                {
                    buf.Append("<span class=\"bold\">").Append(trait.Name).Append("</span> ");
                    foreach (string text in trait.Texts)
                    {
                        buf.Append(text).Append("<br />");
                    }
                }

                buf.Append("</p>");
            }

            // actions

            if (Actions != null && Actions.Length > 0)
            {
                buf.Append("<p>");
                buf.AppendLine("<h3 style=\"border-bottom: 1px solid #58180D\">Actions</h3>");
                foreach (FC5Action action in Actions)
                {
                    buf.Append("<span class=\"bold\">").Append(action.Name).Append("</span> ");
                    foreach (string text in action.Texts)
                    {
                        buf.Append(text).Append("<br />");
                    }
                }

                buf.Append("</p>");
            }

            // legendary actions

            if (Legendaries != null && Legendaries.Length > 0)
            {
                buf.Append("<p>");
                buf.AppendLine("<h3 style=\"border-bottom: 1px solid #58180D\">Legendary Actions</h3>");
                foreach (FC5Legendary legendary in Legendaries)
                {
                    buf.Append("<span class=\"bold\">").Append(legendary.Name).Append("</span> ");
                    foreach (string text in legendary.Texts)
                    {
                        buf.Append(text).Append("<br />");
                    }
                }

                buf.Append("</p>");
            }

            buf.AppendLine("<br />");
            buf.AppendLine("</div>");

            string template = Resources.index;

            return template.Replace("{replace:title}", "Monster").Replace("{replace:body}", buf.ToString());
        }

        private string CalcMod(int value)
        {
            int tmpValue;
            if (value >= 10)
            {
                tmpValue = (int) Math.Floor((double) ((value - 10) / 2));
            }
            else
            {
                tmpValue = Math.Abs(value - 10) / 2;
                tmpValue = tmpValue + value % 2;
                tmpValue *= -1;
            }

            return (tmpValue > 0 ? "+" : "") + tmpValue;
        }
    }
}