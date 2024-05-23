using System.Windows.Controls;
using CodeBuddies.Services.Interfaces;
using CodeBuddies.ViewModels;

namespace CodeBuddies.Views.UserControls
{
    /// <summary>
    /// Interaction logic for SessionsPanel.xaml
    /// </summary>
    public partial class SessionsPanel : UserControl
    {
        public SessionsPanel(ISessionService sessionService)
        {
            InitializeComponent();
            DataContext = new SessionsListViewModel(sessionService);
        }
    }
}
