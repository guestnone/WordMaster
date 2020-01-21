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

namespace WordMaster
{
    /// <summary>
    /// Interaction logic for EditUserWindow.xaml
    /// </summary>
    public partial class EditUserWindow : Window
    {
        public bool IsChanged = false;
        public string FirstName;
        public string LastName;

        public EditUserWindow(string first, string last)
        {
            InitializeComponent();
            firstNameTextBox.Text = first;
            lastNameTextBox.Text = last;
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            FirstName = firstNameTextBox.Text;
            LastName = lastNameTextBox.Text;
            IsChanged = true;
            this.Close();
        }
    }
}
