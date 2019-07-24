using System;
using System.Windows;
using DnDLookup.dto;
using DnDLookup.dto.fc5;

namespace DnDLookup
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class DetailView : Window
    {
        public DetailView(SearchItem item)
        {
            InitializeComponent();

            IFC5Html htmlFc5 = null;
            switch (item.Type)
            {
                case SearchItem.ItemType.Spell:
                    htmlFc5 =  DataStorage.GetSpell(item.Name);
                    break;
                case SearchItem.ItemType.Monster:
                    htmlFc5 =  DataStorage.GetMonster(item.Name);
                    break;
            }
            webBrowser.NavigateToString(htmlFc5.ToHtml());
        }
    }
}