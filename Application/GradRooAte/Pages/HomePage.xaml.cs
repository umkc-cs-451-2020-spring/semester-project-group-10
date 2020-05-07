using AppWindows.Controls;
using SchedulingLib.models;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AppWindows
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private void HomeNavButton_Click(object sender, MouseButtonEventArgs e)
        {
            var btn = sender as HomeNavButton;
            if (btn == null) throw new NullReferenceException();

            try
            {
                NavigationService.Navigate(new ModelList(btn.Tag as string));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Exception in navigation: {ex.Message}");
            }
        }
    }
}
