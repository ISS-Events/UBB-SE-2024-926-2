using System.Windows;
using System.Windows.Input;
using System.Windows.Navigation;
using CodeBuddies.Views.UserControls;

namespace CodeBuddies
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void DrawingBoard_Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationWindow navigationWindow = new NavigationWindow();
            navigationWindow.Source = new System.Uri("Views/UserControls/DrawingBoardMenu.xaml", System.UriKind.Relative);
            navigationWindow.Show();
            this.Close();
        }
    }
}