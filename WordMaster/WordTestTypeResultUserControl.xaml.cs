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

    public enum ResultType
    {
        Correct,
        Incorrect
    }

    /// <summary>
    /// Interaction logic for WordTestTypeResultUserControl.xaml
    /// </summary>
    public partial class WordTestTypeResultUserControl : UserControl
    {
        public WordTestTypeResultUserControl(ResultType resultType, string properWord)
        {
            InitializeComponent();
            if (resultType == ResultType.Correct)
            {
                resultLabel.Content = "Correct";
                resultLabel.Background = Brushes.LightGreen;
            }
            else
            {
                resultLabel.Content = "Incorrect, the proper word is: " + properWord;
                resultLabel.Background = Brushes.Red;
            }
        }
    }
}
