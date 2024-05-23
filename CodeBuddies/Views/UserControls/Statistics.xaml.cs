using System.Windows;
using CodeBuddies.Services;
using CodeBuddies.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CodeBuddies.Views.UserControls
{
    /// <summary>
    /// Interaction logic for Statistics.xaml
    /// </summary>
    public partial class Statistics : Window
    {
        private readonly IQuestionFeedService iservice;
        public Statistics()
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
