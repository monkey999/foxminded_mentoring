﻿using System.Windows;

namespace Task10
{
    public partial class MainWindow : Window
    {
        public MainWindow(object dataContext)
        {
            InitializeComponent();

            DataContext = dataContext;
        }
    }
}
