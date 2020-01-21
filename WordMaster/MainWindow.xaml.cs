using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
using NiceIO;
using Serilog;

namespace WordMaster
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ILogger logger;

        private void UpdateStats()
        {
            var userState = UserManager.GetInstance().GetUserState(true).GetData();
            nameLabel.Content = userState.mFirstName + " " + userState.mLastName;
            profLabel.Content = userState.mProficiencyType.ToString();
            correctLabel.Content = userState.mGoodAnswerCount;
            wrongLabel.Content = userState.mWrongAnswerCount;
        }

        public MainWindow()
        {
            InitializeComponent();
            logger = new LoggerConfiguration().WriteTo.Console().WriteTo.File("WordMaster.log").CreateLogger();
            UpdateStats();
        }

        private void userEditButton_Click(object sender, RoutedEventArgs e)
        {
            var userState = UserManager.GetInstance().GetUserState(true).GetData();
            var userEditWindow = new EditUserWindow(userState.mFirstName, userState.mLastName);
            userEditWindow.ShowDialog();
            if (((EditUserWindow)userEditWindow).IsChanged)
            {
                userState.mFirstName = ((EditUserWindow)userEditWindow).FirstName;
                userState.mLastName = ((EditUserWindow)userEditWindow).LastName;
                UserStateMemento memento = new UserStateMemento(userState);
                UserManager.GetInstance().OverwriteUserState(memento);
                UpdateStats();
            }
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "State File|*.json";
            if (sfd.ShowDialog() == true)
            {
                //SaveF.Instance.Save(new NPath(System.IO.Path.GetDirectoryName(sfd.FileName)), System.IO.Path.GetFileName(sfd.FileName), false);
                SaveLoadManager.SaveToDisk(new NPath(System.IO.Path.GetFullPath(sfd.FileName)),
                    UserManager.GetInstance().GetUserState(true),
                    WordStorageManager.GetInstance().GetStorageState(true));
            }
        }

        private void loadButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "State File|*.json";
            if (ofd.ShowDialog() == true)
            {
                UserStateMemento userStateMemento;
                WordStoreMemento wordStoreMemento;
                SaveLoadManager.LoadFromDisk(new NPath(System.IO.Path.GetFullPath(ofd.FileName)), out userStateMemento, out wordStoreMemento);
                UserManager.GetInstance().OverwriteUserState(userStateMemento);
                WordStorageManager.GetInstance().OverwriteStorageState(wordStoreMemento);
                UpdateStats();
            }
        }

        private void editButton_Click(object sender, RoutedEventArgs e)
        {
            var editWindow = new WordStorageEditWindow(WordStorageManager.GetInstance().GetStorageState(false).GetData());
            editWindow.ShowDialog();
            WordStorageManager.GetInstance().OverwriteStorageState(new WordStoreMemento(editWindow.EditedStore));

        }

        private void testButton_Click(object sender, RoutedEventArgs e)
        {
            var wordStoreMemento = WordStorageManager.GetInstance().GetStorageState(true);
            if (wordStoreMemento.GetData().mWordCollections.Count == 0)
            {
                MessageBox.Show("You don't have any added word collections.\nPlease add some.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }


        }
    }
}
