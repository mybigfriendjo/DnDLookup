namespace DnDLookup.dto
{
    public class SearchItem
    {
        public string Name { get; set; }
        public ItemType Type { get; set; }

        public enum ItemType
        {
            Spell, Monster
        }

        public SearchItem(string name, ItemType type)
        {
            Name = name;
            Type = type;
        }
    }
}