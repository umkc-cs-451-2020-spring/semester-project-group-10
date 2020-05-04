using SchedulingLib;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AppWindows
{
    /// <summary>
    /// Interaction logic for Catalog.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static readonly Uri HomePageURI = new Uri("Pages/HomePage.xaml", UriKind.Relative);

        public MainWindow()
        {
            Hide();
            LandingWindow landing = new LandingWindow();
            var loaded = landing.ShowDialog();
            if (loaded.GetValueOrDefault(false) == false)
            {
                Close();
                return;
            }

            App.CurrentApp.scheduler = landing.client;

            Show();
            InitializeComponent();
        }

        private void Frame_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            if (e.Uri.Equals(HomePageURI))
            {
                navBar.IsEnabled = false;
                navBar.Visibility = Visibility.Collapsed;
            } else
            {
                navBar.IsEnabled = true;
                navBar.Visibility = Visibility.Visible;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                navFrame.Navigate(HomePageURI);
            } catch (Exception ex)
            {
                MessageBox.Show($"Exception in navigation: {ex.Message}");
            }
        }
    }
}
