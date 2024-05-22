using System.Windows.Controls;
using CodeBuddies.Services.Interfaces;
using CodeBuddies.ViewModels;

namespace CodeBuddies.Views.UserControls
{
    public partial class BuddiesList : UserControl
    {
        public BuddiesList(IBuddyService buddyService, ISessionService sessionService)
        {
            InitializeComponent();
            DataContext = new BuddiesListViewModel(buddyService, sessionService);
        }
    }
}
