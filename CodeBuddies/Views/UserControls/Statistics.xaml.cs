using System.Windows;
using CodeBuddies.Services.Interfaces;

namespace CodeBuddies.Views.UserControls
{
    /// <summary>
    /// Interaction logic for Statistics.xaml
    /// </summary>
    public partial class Statistics : Window
    {
        private readonly IQuestionFeedService iservice;
        public Statistics(IQuestionFeedService service)
        {
            InitializeComponent();
            iservice = service;
            ThisWeek.Text = service.CountQuestionsInLast7Days().ToString();
            ThisMonth.Text = service.FilterQuestionsAnsweredThisMonth().ToString();
            ThisYear.Text = service.FilterQuestionsAnsweredLastYear().ToString();
        }
    }
}
