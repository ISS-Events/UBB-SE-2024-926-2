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
    /// Interaction logic for Statistics.xaml
    /// </summary>
    public partial class Statistics : Window
    {
        private readonly IQuestionFeedService iservice;
        public Statistics(IQuestionFeedService service)
        {
            InitializeComponent();
            iservice = service;
            ThisWeek.Text = service.FilterQuestionsByLast7Days().ToString();
            ThisMonth.Text = service.FilterQuestionsAnsweredThisMonth().ToString();
            ThisYear.Text = service.FilterQuestionsAnsweredLastYear().ToString();
        }
    }
}
