using System.Windows.Controls;
using CodeBuddies.Services.Interfaces;
using CodeBuddies.ViewModels;

namespace CodeBuddies.Views.UserControls
{
    /// <summary>
    /// Interaction logic for InactiveBuddies.xaml
    /// </summary>
    public partial class InactiveBuddies : UserControl
    {
        public InactiveBuddies(IBuddyService buddyService)
        {
            InitializeComponent();
            DataContext = new ActiveInactiveBuddiesListViewModel(buddyService);
        }
    }
}
