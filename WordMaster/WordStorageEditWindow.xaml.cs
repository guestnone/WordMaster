using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    /// Interaction logic for WordStorageEditWindow.xaml
    /// </summary>
    public partial class WordStorageEditWindow : Window
    {
        public WordStore EditedStore;

        public WordStorageEditWindow(WordStore store)
        {
            InitializeComponent();
            EditedStore = store;
            Resources["Collections"] = EditedStore.mWordCollections;
        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            comboBox.SelectedIndex = -1;
            comboBox.ItemsSource = ((KeyValuePair<string, WordCollection>) collectionListBox.SelectedItem).Value
                .mWordSets.Keys;
            this.langLabel.Content = ((KeyValuePair<string, WordCollection>) collectionListBox.SelectedItem).Value
                .mDefaultLanguage.ToString();
            comboBox.Items.Refresh();
        }

        private void RefreshCollections()
        {
            Resources["Collections"] = EditedStore.mWordCollections;
            collectionListBox.Items.Refresh();
        }

        private void addCollectionButton_Click(object sender, RoutedEventArgs e)
        {
            var addWindow = new AddCollectionWindow();
            addWindow.ShowDialog();
            if (addWindow.IsCreate)
            {
                WordCollectionFactory wordCollectionFactory = new DefaultWordCollectionFactory();
                WordSetFactory wordSetFactory = new DefaultWordSetFactory();

                var newCollection = wordCollectionFactory.create(addWindow.projectNameTextBox.Text,
                    (Language) addWindow.defaultLanguageComboBox.SelectionBoxItem);
                newCollection.mWordSets.Add(newCollection.mDefaultLanguage,
                    wordSetFactory.Create(newCollection.mDefaultLanguage));

                EditedStore.mWordCollections.Add(newCollection.mName, newCollection);
                RefreshCollections();
            }

            addWindow.Close();
        }

        private void RefreshWords()
        {
            Resources["Words"] =
                ((KeyValuePair<string, WordCollection>) collectionListBox.SelectedItem).Value.mWordSets[
                    (Language) comboBox.SelectedItem].mWords;
            wordsListBox.Items.Refresh();
        }

        private void ComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBox.SelectedIndex != -1)
            {
                RefreshWords();
            }
            else
            {
                wordsListBox.SelectedIndex = -1;
                Resources["Words"] = null;
                wordsListBox.Items.Refresh();
            }
        }

        private void addWordButton_Click(object sender, RoutedEventArgs e)
        {
            if (comboBox.SelectedIndex == -1 || collectionListBox.SelectedIndex == -1)
            {
                MessageBox.Show("Please select the Collection and Language.", "Warning", MessageBoxButton.OK,
                    MessageBoxImage.Warning);
                return;
            }

            var window = new AddWordWindow();
            window.ShowDialog();
            if (window.IsAdding)
            {
                var defaultLang = ((KeyValuePair<string, WordCollection>) collectionListBox.SelectedItem).Value
                    .mDefaultLanguage;
                ((KeyValuePair<string, WordCollection>) collectionListBox.SelectedItem).Value
                    .mWordSets[defaultLang].mWords.Add(window.textBox.Text, window.textBox.Text);

                foreach (var wordset in ((KeyValuePair<string, WordCollection>) collectionListBox.SelectedItem).Value
                    .mWordSets)
                {
                    if (wordset.Key != defaultLang)
                        wordset.Value.mWords.Add(window.textBox.Text, "");
                }

                RefreshWords();
            }

            window.Close();
        }

        private void addLangbutton_Click(object sender, RoutedEventArgs e)
        {
            if (collectionListBox.SelectedIndex == -1)
            {
                MessageBox.Show("Please select the Collection.", "Warning", MessageBoxButton.OK,
                    MessageBoxImage.Warning);
                return;
            }

            var window = new AddLanguageWindow();
            window.ShowDialog();
            if (window.IsCreate)
            {
                var defaultLang = ((KeyValuePair<string, WordCollection>) collectionListBox.SelectedItem).Value
                    .mDefaultLanguage;
                WordSetFactory wordSetFactory = new DefaultWordSetFactory();
                var newSet = wordSetFactory.CreateFromCopy((Language) window.languageComboBox.SelectedItem,
                    ((KeyValuePair<string, WordCollection>) collectionListBox.SelectedItem).Value
                    .mWordSets[defaultLang]);
                ((KeyValuePair<string, WordCollection>) collectionListBox.SelectedItem).Value.mWordSets.Add(
                    newSet.mLanguage, newSet);
                comboBox.Items.Refresh();
            }

            window.Close();
        }

        private void wordsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (wordsListBox.SelectedIndex != -1)
            {
                valueLabel.Content = ((KeyValuePair<string, string>)wordsListBox.SelectedItem).Key;
                textBlock.Text = ((KeyValuePair<string, string>)wordsListBox.SelectedItem).Value;
            }
            else
            {
                valueLabel.Content = "Unknown";
                textBlock.Text = "";
            }
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            if (wordsListBox.SelectedIndex != -1)
            {
                EditedStore.mWordCollections[((KeyValuePair<string, WordCollection>) collectionListBox.SelectedItem)
                        .Key].mWordSets[(Language) comboBox.SelectedItem]
                    .mWords[((KeyValuePair<string, string>) wordsListBox.SelectedItem).Key] = textBlock.Text;

                this.wordsListBox.Items.Refresh();
            }
            else
            {
                MessageBox.Show("Please select the Word.", "Warning", MessageBoxButton.OK,
                    MessageBoxImage.Warning);
            }
        }
    }
}
