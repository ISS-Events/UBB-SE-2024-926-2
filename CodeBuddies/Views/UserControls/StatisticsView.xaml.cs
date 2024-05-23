using System.Windows;
using CodeBuddies.Services;
using CodeBuddies.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CodeBuddies.Views.UserControls
{
    /// <summary>
    /// Interaction logic for StatisticsView.xaml
    /// </summary>
    public partial class StatisticsView : Window
    {
        private readonly IQuestionFeedService iservice;
        public StatisticsView()
        {
            iservice = ServiceLocator.ServiceProvider.GetService<IQuestionFeedService>()
                ?? throw new Exception("No implementation");
            InitializeComponent();
            ThisWeek.Text = iservice.CountQuestionsInLast7Days().ToString();
            ThisMonth.Text = iservice.FilterQuestionsAnsweredThisMonth().ToString();
            ThisYear.Text = iservice.FilterQuestionsAnsweredLastYear().ToString();
        }
    }
}
