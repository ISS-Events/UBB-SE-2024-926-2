using System.Windows;
using CodeBuddies.Services.Interfaces;

namespace CodeBuddies.Views.UserControls
{
    /// <summary>
    /// Interaction logic for StatisticsView.xaml
    /// </summary>
    public partial class StatisticsView : Window
    {
        private readonly IQuestionFeedService iservice;
        public StatisticsView(IQuestionFeedService service)
        {
            InitializeComponent();
            iservice = service;
            ThisWeek.Text = service.CountQuestionsInLast7Days().ToString();
            ThisMonth.Text = service.FilterQuestionsAnsweredThisMonth().ToString();
            ThisYear.Text = service.FilterQuestionsAnsweredLastYear().ToString();
        }
    }
}
