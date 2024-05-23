using System.Windows.Controls;
using CodeBuddies.Services;
using CodeBuddies.Services.Interfaces;
using CodeBuddies.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace CodeBuddies.Views.UserControls
{
    public partial class BuddiesList : UserControl
    {
        public BuddiesList()
        {
            InitializeComponent();

            DataContext = new BuddiesListViewModel();
        }
    }
}
