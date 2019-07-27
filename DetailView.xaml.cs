using System.Windows;
using DnDLookup.dto;

namespace DnDLookup
{
    /// <summary>
    ///     Interaction logic for Window1.xaml
    /// </summary>
    public partial class DetailView : Window
    {
        public SearchItem currentItem;

        public DetailView(SearchItem item)
        {
            InitializeComponent();

            currentItem = item;

            Title = item.Name;

            FC5Html htmlFc5 = null;
            switch (item.Type)
            {
                case SearchItem.ItemType.Spell:
                    htmlFc5 = DataStorage.GetSpell(item.Name);
                    break;
                case SearchItem.ItemType.Monster:
                    htmlFc5 = DataStorage.GetMonster(item.Name);
                    break;
            }

            webBrowser.NavigateToString(htmlFc5.ToHtml());
        }
    }
}