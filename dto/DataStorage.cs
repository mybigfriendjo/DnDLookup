using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using DnDLookup.dto.fc5;
using DnDLookup.extension;

namespace DnDLookup.dto
{
    public class DataStorage
    {
        private static FC5Compendium compendium;

        public static bool LoadXmlFile(string fileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(FC5Compendium));
            compendium = (FC5Compendium) serializer.Deserialize(new StringReader(File.ReadAllText(fileName)));

            return true;
        }

        public static List<SearchItem> Filter(string searchValue)
        {
            if (compendium == null)
            {
                return new List<SearchItem>();
            }

            List<SearchItem> temp = new List<SearchItem>();

            IEnumerable<FC5Monster> monsters =
                compendium.Monsters.Where(item => item.Name.Contains(searchValue, StringComparison.OrdinalIgnoreCase));
            temp.AddRange(monsters.Select(monster => new SearchItem(monster.Name, SearchItem.ItemType.Monster)));

            IEnumerable<FC5Spell> spells =
                compendium.Spells.Where(item => item.Name.Contains(searchValue, StringComparison.OrdinalIgnoreCase));
            temp.AddRange(spells.Select(spell => new SearchItem(spell.Name, SearchItem.ItemType.Spell)));

            temp.Sort(Comparer<SearchItem>.Create((o1, o2) => o1.Name.CompareTo(o2.Name)));

            return temp;
        }

        public static FC5Spell GetSpell(string spellName) { return compendium?.Spells.FirstOrDefault(item => item.Name.Equals(spellName)); }

        public static FC5Monster GetMonster(string monsterName)
        {
            return compendium?.Monsters.FirstOrDefault(item => item.Name.Equals(monsterName));
        }
    }
}