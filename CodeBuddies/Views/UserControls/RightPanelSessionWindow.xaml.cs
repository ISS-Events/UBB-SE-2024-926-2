﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
    /// Interaction logic for RightPanelSessionWindow.xaml
    /// </summary>
    public partial class RightPanelSessionWindow : UserControl
    {
        public RightPanelSessionWindow()
        {
            InitializeComponent();
        }

        private void ReviewCodeButton_Clicked(object sender, RoutedEventArgs e)
        {
            // Create a new instance of the CodeReview UserControl
            CodeReview codeReview = new ();

            // Show the CodeReview UserControl in a dialog window
            Window codeReviewWindow = new ()
            {
                Title = "Code Review",
                Content = codeReview,
                Width = 500,
                Height = 500,
                ResizeMode = ResizeMode.NoResize,
                WindowStartupLocation = WindowStartupLocation.CenterScreen,
                ShowInTaskbar = false
            };

            // Show the dialog window
            codeReviewWindow.ShowDialog();
        }

        private void ChatButton_Clicked(object sender, RoutedEventArgs e)
        {
        }
    }
}
