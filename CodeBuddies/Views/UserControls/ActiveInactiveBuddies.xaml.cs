using CodeBuddies.Services.Interfaces;
using CodeBuddies.ViewModels;
using System.Windows.Controls;

namespace CodeBuddies.Views.UserControls
{
    /// <summary>
    /// Interaction logic for ActiveInactiveBuddies.xaml
    /// </summary>
    public partial class ActiveInactiveBuddies : UserControl
    {
        public ActiveInactiveBuddies(IBuddyService buddyService)
        {
            InitializeComponent();
            DataContext = new ActiveInactiveBuddiesListViewModel(buddyService);
        }
    }
}
