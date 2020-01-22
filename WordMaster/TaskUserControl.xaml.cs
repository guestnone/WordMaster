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
using WordMaster.Core;

namespace WordMaster
{
    /// <summary>
    /// Interaction logic for TaskUserControl.xaml
    /// </summary>
    public partial class TaskUserControl : UserControl
    {
        private bool IsLearning;
        private Task task;
        public TaskUserControl(Task task, bool isLearning)
        {
            InitializeComponent();
            IsLearning = isLearning;
            DataContext = task;
            this.task = task;
            if (isLearning)
                modeLabel.Content = "Mode: Learning";
            else
                modeLabel.Content = "Mode: Test";
            taskTextBlock.Text = "Given word: " + task.SearchedWord.Display;
            pointsTextBlock.Text = "Points: " + task.Points.ToString();
            diffTextBlock.Text = "Difficulty: " + Enum.ToObject(typeof(ProficiencyType), task.Difficulty).ToString();
            
        }

        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            if (!IsLearning)
                return;
            if (task.SelectedAnswer != null)
            {
                if (task.SelectedAnswer.Display == task.RightAnswer.Display)
                    notifyTextBlock.Text = "Good Answer!";
                else
                    notifyTextBlock.Text = "Wrong Answer! Right Answer is: " + task.RightAnswer.Display;
            }
            
        }
    }

}
