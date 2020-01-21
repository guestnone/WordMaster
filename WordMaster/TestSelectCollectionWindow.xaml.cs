﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WordMaster.Core;

namespace WordMaster
{
    /// <summary>
    /// Interaction logic for TestSelectCollectionWindow.xaml
    /// </summary>
    public partial class TestSelectCollectionWindow : Window
    {
        public KeyValuePair<Language, WordSet> SelectedSet;
        public string SelectedCollectionName;
        public bool IsSelected = false;
        public bool DefaultLangAsFromLanguage = false;
        private WordStore store;
        
        public TestSelectCollectionWindow(WordStore wordStore)
        {
            InitializeComponent();
            store = wordStore;
            this.collectionComboBox.SelectedValuePath = "Key";
            this.collectionComboBox.DisplayMemberPath = "Value";
            this.languageComboBox.SelectedValuePath = "Key";
            this.languageComboBox.DisplayMemberPath = "Value";

            collectionComboBox.ItemsSource = store.mWordCollections;

        }

        private void collectionComboBox_DropDownClosed(object sender, EventArgs e)
        {
        }

        private void collectionComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedCollectionName = ((KeyValuePair<string, WordCollection>)collectionComboBox.SelectedItem).Key;
            this.languageComboBox.ItemsSource = ((KeyValuePair<string, WordCollection>)collectionComboBox.SelectedItem).Value.mWordSets;
        }

        private void languageComboBox_DropDownClosed(object sender, EventArgs e)
        {
        }

        private void languageComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedSet = ((KeyValuePair<Language, WordSet>)languageComboBox.SelectedItem);
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            IsSelected = true;
            DefaultLangAsFromLanguage = (checkBox.IsChecked == true);
            this.Close();
        }
    }
}
