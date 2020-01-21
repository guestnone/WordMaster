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
    /// Interaction logic for WordTestWindow.xaml
    /// </summary>
    public partial class WordTestWindow : Window
    {
        private int currTaskControl = 0;
        public bool IsFinished = false;

        public TaskUserControl[] taskControls;

        public WordTestWindow(Test test)
        {
            InitializeComponent();
            taskControls = new TaskUserControl[10];
            for (int i = 0; i < 10; i++) {
                taskControls[i] = new TaskUserControl(test.Tasks[i]);
            }
            contentControl = taskControls[currTaskControl];
        }
        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            if (currTaskControl > 0)
                contentControl = taskControls[--currTaskControl];
        }

        private void forward_Click(object sender, RoutedEventArgs e)
        {
            if (currTaskControl < taskControls.Length-1)
                contentControl = taskControls[++currTaskControl];
        }
    }
}
