using System.Windows.Controls;
using CodeBuddies.Services.Interfaces;
using CodeBuddies.ViewModels;

namespace CodeBuddies.Views.UserControls
{
    public partial class NotificationsPanel : UserControl
    {
        public NotificationsPanel(INotificationService notificationService, ISessionService sessionService)
        {
            InitializeComponent();
            DataContext = new NotificationsPanelViewModel(notificationService, sessionService);
        }
    }
}
