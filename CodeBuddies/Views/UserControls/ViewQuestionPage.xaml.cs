using CodeBuddies.Models.Entities;
using CodeBuddies.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Design;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
        private readonly IQuestion question;
        public ViewQuestionPage(IQuestionFeedService service, IQuestion question)
        {
            this.question = question;
            this.iservice = service;
            InitializeComponent();
            DataContext = this;
            Comments = new ObservableCollection<IPost>(service.GetRepliesOfPost(question.ID));
            Tags = new ObservableCollection<ITag>(service.GetTagsOfQuestion(question.ID));
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            ViewQuestionFrame.Navigate(new SearchQuestionPage(iservice));
            // ViewQuestionFrame.Visibility = Visibility.Collapsed;
        }

        private void ViewQuestionFrame_Navigated(object sender, NavigationEventArgs e)
        {
        }
    }
}
