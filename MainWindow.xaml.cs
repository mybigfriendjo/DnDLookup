﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using DnDLookup.dto;
using Microsoft.Win32;

namespace DnDLookup
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string DEFAULT_FILENAME = "Full Compendium.xml";
        private readonly ObservableCollection<SearchItem> listResultItems = new ObservableCollection<SearchItem>();
        private readonly Dictionary<SearchItem, DetailView> openDetailViews = new Dictionary<SearchItem, DetailView>();

        public MainWindow()
        {
            InitializeComponent();
            listResults.Items.Clear();
            listResults.ItemsSource = listResultItems;

            if (File.Exists(DEFAULT_FILENAME))
            {
                try
                {
                    DataStorage.LoadXmlFile(DEFAULT_FILENAME);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        private void ListViewResultItem_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            ShowDetailView((SearchItem) ((ListViewItem) sender).Content);
        }

        private async void ShowDetailView(SearchItem item)
        {
            if (openDetailViews.ContainsKey(item))
            {
                await Task.Delay(100);
                openDetailViews[item].Activate();
                return;
            }

            DetailView view = new DetailView(item);
            openDetailViews.Add(item, view);
            view.Closing += (sender, args) => { openDetailViews.Remove(view.currentItem); };
            view.Show();
            await Task.Delay(100);
            view.Activate();
        }

        private void ListViewResultItem_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Enter)
            {
                return;
            }

            ShowDetailView((SearchItem) ((ListViewItem) sender).Content);
            e.Handled = true;
        }

        private void MenuImportXml_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog odf = new OpenFileDialog {Multiselect = false, Filter = "xml Files (*.xml)|*.xml"};
            if (odf.ShowDialog() != true)
            {
                return;
            }

            if (!DataStorage.LoadXmlFile(odf.FileName))
            {
                MessageBox.Show("XML-File Import was not successful!\r\nPlease make sure the XML-File has the correct Format.\r\n(Fight Club 5 XML-Format)",
                                "Import Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void MenuSettings_Click(object sender, RoutedEventArgs e)
        {
            // TODO open Settings window
        }

        private void MenuClose_Click(object sender, RoutedEventArgs e)
        {
            CleanExit();
            Close();
        }

        private void TxtSearch_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Up:
                    MoveListResultSelection(-1);
                    e.Handled = true;
                    break;
                case Key.Down:
                    MoveListResultSelection(1);
                    e.Handled = true;
                    break;
            }
        }

        private void TxtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtSearch.Text.Length > 2)
            {
                FilterResultList();
            }
            else
            {
                listResultItems.Clear();
            }
        }

        private void Window_Closing(object sender, CancelEventArgs e) { CleanExit(); }

        private void MoveListResultSelection(int direction)
        {
            if (listResults.Items.Count <= 0)
            {
                return;
            }

            listResults.Focus();
            int selectedIndex = listResults.SelectedIndex;

            if (selectedIndex < 0)
            {
                listResults.SelectedIndex = 0;
            }
            else if (selectedIndex + direction < 0)
            {
                listResults.SelectedIndex = 0;
            }
            else if (selectedIndex + direction > listResultItems.Count - 1)
            {
                listResults.SelectedIndex = listResultItems.Count - 1;
            }
            else
            {
                listResults.SelectedIndex = selectedIndex + direction;
            }
        }

        private void FilterResultList()
        {
            List<SearchItem> filteredItems = DataStorage.Filter(txtSearch.Text);
            listResultItems.Clear();
            foreach (SearchItem item in filteredItems)
            {
                listResultItems.Add(item);
            }
        }

        private void CleanExit()
        {
            foreach (DetailView detailView in openDetailViews.Values.ToList())
            {
                detailView.Close();
            }
        }
    }
}