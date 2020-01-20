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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WordMaster
{
    /// <summary>
    /// Interaction logic for WordTestTypeUserControl.xaml
    /// </summary>
    public partial class WordTestTypeUserControl : UserControl
    {
        public WordTestTypeUserControl(string originalText)
        {
            InitializeComponent();
            origValue.Content = originalText;
        }

        public string GetTypedValue()
        {
            return textBox.Text;
        }
    }
}
