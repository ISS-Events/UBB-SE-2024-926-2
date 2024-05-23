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
using CodeBuddies.Models.Entities;
using CodeBuddies.Services.Interfaces;

namespace CodeBuddies.Views.UserControls
{
    public partial class SearchQuestionPage : Page
    {
        public ObservableCollection<Question> Posts { get; set; }
        public ObservableCollection<Category> Categories { get; set; }
        private readonly IQuestionFeedService iservice;
        public SearchQuestionPage(IQuestionFeedService service)
        {
            InitializeComponent();
            this.iservice = service;
            Posts = new ObservableCollection<Question>(service.SortQuestionsByDateDescending());
            Categories = new ObservableCollection<Category>(service.GetAllCategories());
            DataContext = this; // Set DataContext to enable data binding
        }

        private void QuestionList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }
        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            List<Question> searchedQuestions = iservice.FindQuestionsByPartialStringInAnyField(SearchBox.Text);
            Posts.Clear();
            foreach (Question question in searchedQuestions)
            {
                Posts.Add(question);
            }
            DataContext = this;
        }

        private void CategorySelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // iservice.getQuestionsOfCategory()
            var selectedCategory = CategorySelector.SelectedItem as Category;
            List<Question> questionsOfCategory = iservice.GetQuestionsOfCategory(selectedCategory);
            // Posts = iservice.getQuestionsOfCategory(selectedCategory) as ObservableCollection<Posts>;
            Posts.Clear();
            foreach (Question question in questionsOfCategory)
            {
                Posts.Add(question);
            }
            DataContext = this;
        }

        private void NewestSortButton_Click(object sender, RoutedEventArgs e)
        {
            List<Question> questions = iservice.SortQuestionsByDateDescending();
            Posts.Clear();
            foreach (Question question in questions)
            {
                Posts.Add(question);
            }
            DataContext = this;
        }

        private void MostUpvotesSortButton_Click(object sender, RoutedEventArgs e)
        {
            List<Question> questions = iservice.GetQuestionsSortedByScoreDescending();
            Posts.Clear();
            foreach (Question question in questions)
            {
                Posts.Add(question);
            }
            DataContext = this;
        }

        private void MostAnswers_Click(object sender, RoutedEventArgs e)
        {
            List<Question> questions = iservice.SortQuestionsByNumberOfAnswersDescending();
            Posts.Clear();
            foreach (Question question in questions)
            {
                Posts.Add(question);
            }
            DataContext = this;
        }

        private void HideUnAnsweredCheckBox_Checked(object sender, RoutedEventArgs e)
        {
        }

        private void HideUnAnsweredCheckBox_Click(object sender, RoutedEventArgs e)
        {
            List<Question> questions;
            if (HideUnAnsweredCheckBox.IsChecked == true)
            {
                questions = iservice.GetQuestionsWithAtLeastOneAnswer();
            }
            else
            {
                questions = iservice.GetCurrentQuestions();
            }
            Posts.Clear();
            foreach (Question question in questions)
            {
                Posts.Add(question);
            }
            DataContext = this;
        }
        private void OnQuestion_Click(object sender, RoutedEventArgs e)
        {
            IQuestion myQuestion = (Question)((Button)sender).DataContext;
            // TODO
            // SearchFrame.Navigate(new ViewQuestionPage(iservice, myQuestion));
        }

        private void AskQuestion_Click(object sender, RoutedEventArgs e)
        {
            // TODO
            // SearchFrame.Navigate(new CreateQuestionPage(iservice));
        }

        private void StatisticsButton_Click(object sender, RoutedEventArgs e)
        {
            // TODO
            // StatisticsView statistics = new(iservice);
            // statistics.Show();
        }
    }
}
