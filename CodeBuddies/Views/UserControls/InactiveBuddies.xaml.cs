using System.Windows.Controls;
using CodeBuddies.Services;
using CodeBuddies.Services.Interfaces;
using CodeBuddies.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace CodeBuddies.Views.UserControls
{
    /// <summary>
    /// Interaction logic for InactiveBuddies.xaml
    /// </summary>
    public partial class InactiveBuddies : UserControl
    {
        public InactiveBuddies()
        {
            InitializeComponent();
            DataContext = new ActiveInactiveBuddiesListViewModel();
        }
    }
}
