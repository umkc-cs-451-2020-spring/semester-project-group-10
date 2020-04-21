using System.Windows.Controls;

namespace AppWindows.Controls
{
    /// <summary>
    /// Interaction logic for HomeNavButton.xaml
    /// </summary>
    public partial class HomeNavButton : UserControl
    {
        public string ButtonText { get; set; } = "Button";

        public HomeNavButton()
        {
            InitializeComponent();
        }
    }
}
