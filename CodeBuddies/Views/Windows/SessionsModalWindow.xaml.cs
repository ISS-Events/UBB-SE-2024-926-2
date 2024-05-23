using System.Windows;
using System.Windows.Input;
using CodeBuddies.Models.Entities;
using CodeBuddies.MVVM;
using CodeBuddies.Resources.Data;
using CodeBuddies.Services.Interfaces;
using CodeBuddies.ViewModels;

namespace CodeBuddies.Views.Windows
{
    public partial class SessionsModalWindow : Window
    {
        private readonly SessionsListViewModel viewModel;
        public SessionsModalWindow()
        {
            InitializeComponent();

            viewModel = new SessionsListViewModel();
            viewModel.FilterSessionOnlyOwner(Constants.CLIENT_BUDDY_ID);
            DataContext = viewModel;
        }
        public ICommand CloseCommand => new RelayCommand<Buddy>(_ => Close());
    }
}
