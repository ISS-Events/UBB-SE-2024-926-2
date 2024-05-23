using System.Windows;
using CodeBuddies.Services;
using CodeBuddies.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CodeBuddies.Views.UserControls
{
    /// <summary>
    /// Interaction logic for StatisticsView.xaml
    /// </summary>
    public partial class Statistics : Window
    {
        private readonly IQuestionFeedService iservice;
        public Statistics()
        {
            iservice = ServiceLocator.ServiceProvider.GetService<IQuestionFeedService>()
                ?? throw new Exception("No implementation");
            InitializeComponent();
            iservice = service;
            ThisWeek.Text = service.CountQuestionsInLast7Days().ToString();
            ThisMonth.Text = service.FilterQuestionsAnsweredThisMonth().ToString();
            ThisYear.Text = service.FilterQuestionsAnsweredLastYear().ToString();
        }
    }
}
