using System;
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
    /// Interaction logic for WordStorageEditWindow.xaml
    /// </summary>
    public partial class WordStorageEditWindow : Window
    {
        public WordStore EditedStore;

        public WordStorageEditWindow(WordStore store)
        {
            InitializeComponent();
            EditedStore = store;
        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
