using Microsoft.Win32;
using SchedulingLib;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace AppWindows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LandingWindow : Window
    {
        internal SchedulerClient client;

        public LandingWindow()
        {
            InitializeComponent();
        }


        private void NewProject(object sender, RoutedEventArgs e)
        {
            var saveDialog = new SaveFileDialog
            {
                Filter = "GradRooAte Project (*.grdb)|*.grdb",
                DefaultExt = "grdb",
                Title = "Save new project"
            };
            var ok = saveDialog.ShowDialog();
            if (!ok.GetValueOrDefault()) return;
            var path = saveDialog.FileName;
            try
            {
                client = LocalScheduler.Connect(path);
            }
            catch (Exception ex)
            {
                // TODO: Use well formatted errors
                MessageBox.Show($"Could not save database: {ex.Message}");
                return;
            }

            DialogResult = true;
            Close();
        }

        private void OpenProject(object sender, RoutedEventArgs e)
        {
            var openDialog = new OpenFileDialog
            {
                Filter = "GradRooAte Project (*.grdb)|*.grdb",
                DefaultExt = "grdb",
                Title = "Open project"
            };
            var ok = openDialog.ShowDialog();
            if (!ok.GetValueOrDefault()) return;
            var path = openDialog.FileName;
            try
            {
                client = LocalScheduler.Connect(path);
            }
            catch (Exception ex)
            {
                // TODO: Use well formatted errors
                MessageBox.Show($"Could not open database: {ex.Message}");
                return;
            }

            DialogResult = true;
            Close();
        }
    }
}
