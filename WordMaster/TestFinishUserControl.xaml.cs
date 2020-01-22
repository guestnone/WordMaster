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
    /// Interaction logic for TestFinishUserControl.xaml
    /// </summary>
    public partial class TestFinishUserControl : UserControl
    {
        private int pointsSum;
        private int pointsOverall;
        public TestFinishUserControl(Test test)
        {
            InitializeComponent();
            pointsOverall = 0;
            pointsSum = 0;
            foreach (Task task in test.Tasks) {
                pointsOverall += task.Points;
                if(task.SelectedAnswer != null)
                {
                    if (task.SelectedAnswer.Display == task.RightAnswer.Display)
                    {
                        pointsSum += task.Points;
                    }
                }
                
            }
            finishTestPoints.Text = pointsSum.ToString() + " / " + pointsOverall.ToString();
        }

        private void end_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Close();
        }
    }
}
