using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using CodeBuddies.Models.Entities;
using CodeBuddies.Models.Entities.Interfaces;
using CodeBuddies.Services;
using CodeBuddies.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CodeBuddies.Views.UserControls
{
    /// <summary>
    /// Interaction logic for CreateQuestionPage.xaml
    /// </summary>
    public partial class CreateQuestionPage : Page
    {
        private readonly IQuestionFeedService iservice;
        public ObservableCollection<ICategory> Categories { get; set; }

        public CreateQuestionPage()
        {
            IQuestionFeedService service = ServiceLocator.ServiceProvider.GetService<IQuestionFeedService>()
                ?? throw new Exception("No implementation");
            InitializeComponent();
            iservice = service;
            Categories = new ObservableCollection<ICategory>(service.GetAllCategories());
            DataContext = this;
        }

        private void CoolTextBox_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void PostBtn_Click(object sender, RoutedEventArgs e)
        {
            string title = TitleBox.Text;
            string content = ContentBox.GetText();
            Category category = (Category)CategoryBox1.SelectedItem;

            iservice.AddQuestion(title, content, category);
            CreateQuestionFrame.Navigate(new SearchQuestionPage());
            DataContext = this;
        }

        private void CategoryBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }
    }
}
