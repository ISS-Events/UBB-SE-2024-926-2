using System.Windows.Controls;
using CodeBuddies.Services.Interfaces;
using CodeBuddies.ViewModels;

namespace CodeBuddies.Views.UserControls
{
    /// <summary>
    /// Interaction logic for ActiveBuddies.xaml
    /// </summary>
    public partial class ActiveBuddies : UserControl
    {
        public ActiveBuddies(IBuddyService buddyService)
        {
            InitializeComponent();
            DataContext = new ActiveInactiveBuddiesListViewModel(buddyService);
        }
    }
}
