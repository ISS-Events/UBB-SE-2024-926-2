using System.Windows;
using System.Windows.Controls;
using CodeBuddies.Services.Interfaces;

namespace CodeBuddies.Views.UserControls
{
    /// <summary>
    /// Interaction logic for MainMenuBar.xaml
    /// </summary>
    public partial class MainMenuBar : UserControl
    {
        private ISessionService sessionService;
        public MainMenuBar(ISessionService sessionService)
        {
            InitializeComponent();
            this.sessionService = sessionService;
        }

        private void NewSessionButtonClicked(object sender, RoutedEventArgs e)
        {
            CreateNewSessionPopUp createNewSessionPopUp = new CreateNewSessionPopUp(sessionService);
            createNewSessionPopUp.ShowDialog();
        }
    }
}
