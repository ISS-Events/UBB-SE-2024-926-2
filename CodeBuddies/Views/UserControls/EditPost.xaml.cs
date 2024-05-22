using CodeBuddies.Models.Entities;
using CodeBuddies.Services.Interfaces;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace CodeBuddies.Views.UserControls
{
    /// <summary>
    /// Interaction logic for EditPost.xaml
    /// </summary>
    public partial class EditPost : Window
    {
        private readonly IPost post;
        private readonly IQuestionFeedService iservice;
        public EditPost(IQuestionFeedService service, IPost post)
        {
            this.iservice = service;
            this.post = post;
            InitializeComponent();
        }

        private void Submit_Button_Click(object sender, RoutedEventArgs e)
        {
            string text = Coolest_TextBox_Ever.Text;
            post.Content = text;
            post.DateOfLastEdit = DateTime.Now;
            // This is not fine leaving this here until someone fixes
            TextPost newPost = new(post.UserID, text);
            iservice.UpdatePost(post, newPost);
        }

        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
