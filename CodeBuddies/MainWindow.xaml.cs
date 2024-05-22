﻿using System.Windows;
using CodeBuddies.Models.Entities;
using CodeBuddies.Repositories;

namespace CodeBuddies
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent(); // Arunca eroare pentru ca repositoruyurile potrivite nu sunt asociate in main :)
        }
    }
}