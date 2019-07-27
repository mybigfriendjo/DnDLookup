using System;

namespace DnDLookup.dto
{
    public class SearchItem : IEquatable<SearchItem>
    {
        public string Name { get; }
        public ItemType Type { get; }

        public enum ItemType
        {
            Spell, Monster
        }

        public SearchItem(string name, ItemType type)
        {
            Name = name;
            Type = type;
        }

        public bool Equals(SearchItem other)
        {
            if (other == null)
            {
                return false;
            }

            if (Name == null)
            {
                if (other.Name != null)
                {
                    return false;
                }
            }
            else
            {
                if (!Name.Equals(other.Name))
                {
                    return false;
                }
            }

            if (Type != other.Type)
            {
                return false;
            }

            return true;
        }
    }
}