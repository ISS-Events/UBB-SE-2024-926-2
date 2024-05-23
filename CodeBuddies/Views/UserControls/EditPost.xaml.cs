using System.Windows;
using System.Windows.Forms.Design;
using CodeBuddies.Models.Entities;
using CodeBuddies.Services;
using CodeBuddies.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CodeBuddies.Views.UserControls
{
    /// <summary>
    /// Interaction logic for EditPost.xaml
    /// </summary>
    public partial class EditPost : Window
    {
        private readonly IPost post;
        private readonly IQuestionFeedService iservice;
        public EditPost(IPost post)
        {
            this.post = post;
            iservice = ServiceLocator.ServiceProvider.GetService<IQuestionFeedService>()
                ?? throw new Exception("No implementation");
            InitializeComponent();
        }

        private void Submit_Button_Click(object sender, RoutedEventArgs e)
        {
            string text = Coolest_TextBox_Ever.Text;
            post.Content = text;
            post.DateOfLastEdit = DateTime.Now;
            // This is not fine leaving this here until someone fixes
            TextPost newPost = new (post.UserID, text);
            iservice.UpdatePost(post, newPost);
        }

        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
