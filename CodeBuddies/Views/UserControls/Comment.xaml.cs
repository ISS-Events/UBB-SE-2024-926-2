using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CodeBuddies.Views.UserControls
{
    /// <summary>
    /// Interaction logic for Comment.xaml
    /// </summary>
    public partial class Comment : UserControl
    {
        public Comment()
        {
            InitializeComponent();
        }

        public static new readonly DependencyProperty ContentProperty =
            DependencyProperty.Register("Content", typeof(string), typeof(Comment), new PropertyMetadata(string.Empty));

        public new string Content
        {
            get => (string)GetValue(ContentProperty);
            set { SetValue(ContentProperty, value); }
        }

        public static readonly DependencyProperty DatePostedProperty =
            DependencyProperty.Register("DatePosted", typeof(string), typeof(Comment), new PropertyMetadata(string.Empty));

        public string DatePosted
        {
            get { return (string)GetValue(DatePostedProperty); }
            set { SetValue(DatePostedProperty, value); }
        }

        private void Settings_Button_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}
