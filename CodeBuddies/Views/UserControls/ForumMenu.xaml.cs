using System.Windows.Controls;
using CodeBuddies.Repositories;
using CodeBuddies.Services;
using CodeBuddies.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CodeBuddies.Views.UserControls
{
    public partial class ForumMenu : Page
    {
        public ForumMenu()
        {
            InitializeComponent();
            MainFrame.Navigate(new SearchQuestionPage());
        }
    }
}
