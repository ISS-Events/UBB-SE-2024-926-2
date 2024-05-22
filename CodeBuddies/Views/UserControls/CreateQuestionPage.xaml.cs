using CodeBuddies.Models.Entities.Interfaces;
using CodeBuddies.Models.Entities;
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
using CodeBuddies.Services.Interfaces;

namespace CodeBuddies.Views.UserControls
{
    /// <summary>
    /// Interaction logic for CreateQuestionPage.xaml
    /// </summary>
    public partial class CreateQuestionPage : Page
    {
        private readonly IQuestionFeedService iservice;
        public ObservableCollection<ICategory> Categories { get; set; }

        public CreateQuestionPage(IQuestionFeedService service)
        {
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
            CreateQuestionFrame.Navigate(new SearchQuestionPage(iservice));
            DataContext = this;
        }

        private void CategoryBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }
    }
}
