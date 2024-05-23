using System.Windows;
using CodeBuddies.Models.Entities;
using CodeBuddies.Services.Interfaces;

namespace CodeBuddies.Views.UserControls
{
    /// <summary>
    /// Interaction logic for EditPost.xaml
    /// </summary>
    public partial class EditPost : Window
    {
        private readonly IPost ipost;
        private readonly IQuestionFeedService iservice;
        public EditPost(IQuestionFeedService service, IPost post)
        {
            iservice = service;
            ipost = post;
            InitializeComponent();
        }

        private void Submit_Button_Click(object sender, RoutedEventArgs e)
        {
            string text = Coolest_TextBox_Ever.Text;
            ipost.Content = text;
            ipost.DateOfLastEdit = DateTime.Now;
            // This is not fine leaving this here until someone fixes
            TextPost newPost = new (ipost.UserID, text);
            iservice.UpdatePost(ipost, newPost);
        }

        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
