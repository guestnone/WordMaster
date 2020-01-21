using System;
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
    /// Interaction logic for AddCollectionWindow.xaml
    /// </summary>
    public partial class AddCollectionWindow : Window
    {
        private bool isCreate = false;
        public bool IsCreate => isCreate;

        public AddCollectionWindow()
        {
            InitializeComponent();
            defaultLanguageComboBox.ItemsSource = Enum.GetValues(typeof(Language)).Cast<Language>();
            defaultLanguageComboBox.SelectedIndex = 0;
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            isCreate = true;
            this.Hide();
        }
    }
}
