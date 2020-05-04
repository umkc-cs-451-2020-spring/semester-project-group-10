using AppWindows.ViewModels;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AppWindows
{
    public partial class ModelList : Page
    {
        private SchedulerClient client;
        private ModelDataContext context;
        public ModelList()
        {
            InitializeComponent();
            
            client = App.CurrentApp.scheduler;

            context = new ModelDataContext(client);
            DataContext = context;
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (textBoxPlaceholder.Visibility == Visibility.Visible && textBox.Text.Length > 0)
                textBoxPlaceholder.Visibility = Visibility.Hidden;
            else if (textBox.Text.Length == 0)
                textBoxPlaceholder.Visibility = Visibility.Visible;

            context.SearchTerm = textBox.Text;

        }
    }
}
