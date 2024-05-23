using System.Windows;
using System.Windows.Controls;

namespace CodeBuddies.Views.UserControls
{
    /// <summary>
    /// Interaction logic for MainMenuBar.xaml
    /// </summary>
    public partial class MainMenuBar : UserControl
    {
        public MainMenuBar()
        {
            InitializeComponent();
        }

        private void NewSessionButtonClicked(object sender, RoutedEventArgs e)
        {
            CreateNewSessionPopUp createNewSessionPopUp = new CreateNewSessionPopUp();
            createNewSessionPopUp.ShowDialog();
        }
    }
}
