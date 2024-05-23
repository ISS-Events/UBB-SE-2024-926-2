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
    /// Interaction logic for SettingsPop_Up.xaml
    /// </summary>
    public partial class SettingsPop_Up : Window
    {
        private IQuestionFeedService iservice;
        private readonly long id;
        private readonly bool isQuestion;
        public SettingsPop_Up(IQuestionFeedService service, long question_id, bool isQuestion)
        {
            iservice = service;
            id = question_id;
            this.isQuestion = isQuestion;
            InitializeComponent();
        }

        private void Edit_Button_Click(object sender, RoutedEventArgs e)
        {
            IQuestion question = iservice.GetQuestion(id);
            EditPost window = new(iservice, question);
            Close();
            window.Show();
        }

        private void Delete_Button_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Rares o zis sa fac de la zero da deadlineu ii intr-o ora deci...
        }
    }
}
