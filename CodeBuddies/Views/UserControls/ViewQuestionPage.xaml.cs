using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using CodeBuddies.Models.Entities;
using CodeBuddies.Services;
using CodeBuddies.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CodeBuddies.Views.UserControls
{
    /// <summary>
    /// Interaction logic for ViewQuestionPage.xaml
    /// </summary>
    public partial class ViewQuestionPage : Page
    {
        private readonly IQuestionFeedService iservice;
        public ObservableCollection<IPost> Comments { get; set; }
        public ObservableCollection<ITag> Tags { get; set; }
        public ViewQuestionPage(IQuestion question)
        {
            iservice = ServiceLocator.ServiceProvider.GetService<IQuestionFeedService>()
                ?? throw new Exception("No implementation");
            InitializeComponent();
            DataContext = this;
            Comments = new ObservableCollection<IPost>(iservice.GetRepliesOfPost(question.ID));
            Tags = new ObservableCollection<ITag>(iservice.GetTagsOfQuestion(question.ID));
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            ViewQuestionFrame.Navigate(new SearchQuestionPage());
            // ViewQuestionFrame.Visibility = Visibility.Collapsed;
        }

        private void ViewQuestionFrame_Navigated(object sender, NavigationEventArgs e)
        {
        }
    }
}
