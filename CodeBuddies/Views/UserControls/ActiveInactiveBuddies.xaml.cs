using System.Windows.Controls;
using CodeBuddies.Services;
using CodeBuddies.Services.Interfaces;
using CodeBuddies.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace CodeBuddies.Views.UserControls
{
    /// <summary>
    /// Interaction logic for ActiveInactiveBuddies.xaml
    /// </summary>
    public partial class ActiveInactiveBuddies : UserControl
    {
        public ActiveInactiveBuddies()
        {
            InitializeComponent();
            DataContext = new ActiveInactiveBuddiesListViewModel();
        }
    }
}
