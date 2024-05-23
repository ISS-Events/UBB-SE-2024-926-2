using System.Windows.Controls;
using CodeBuddies.Services;
using CodeBuddies.Services.Interfaces;
using CodeBuddies.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace CodeBuddies.Views.UserControls
{
    /// <summary>
    /// Interaction logic for ActiveBuddies.xaml
    /// </summary>
    public partial class ActiveBuddies : UserControl
    {
        public ActiveBuddies()
        {
            InitializeComponent();
            DataContext = new ActiveInactiveBuddiesListViewModel();
        }
    }
}
