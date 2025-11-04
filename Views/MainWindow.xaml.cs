using QuanLyDaiLy.ViewModels;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Media;
using System;
using System.Collections.Generic;

namespace QuanLyDaiLy.Views
{
    public partial class MainWindow : Window
    {
        private readonly double collapsedWidth = 60;
        private readonly double expandedWidth = 200;
        private readonly IServiceProvider _serviceProvider;

        public MainWindow(MainWindowViewModel viewModel, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            DataContext = viewModel;

            // configure the window
            WindowState = WindowState.Maximized;
        }
            

        private void MainContent_ContentRendered(object sender, EventArgs e)
        {
            // Make sure navigation buttons reflect current page
            // This ensures sync if navigation happens programmatically
        }

        private IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T t)
                    {
                        yield return t;
                    }

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }
        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            // TODO: xử lý khi RadioButton được chọn
        }

        private void NavigationRail_MouseEnter(object sender, MouseEventArgs e)
        {
            // TODO: xử lý khi di chuột vào thanh Navigation
        }

        private void NavigationRail_MouseLeave(object sender, MouseEventArgs e)
        {
            // TODO: xử lý khi rời chuột khỏi thanh Navigation
        }

    }
}
