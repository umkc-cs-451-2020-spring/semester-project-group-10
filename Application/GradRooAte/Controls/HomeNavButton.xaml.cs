using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace AppWindows.Controls
{
    /// <summary>
    /// Interaction logic for HomeNavButton.xaml
    /// </summary>
    public partial class HomeNavButton : UserControl
    {
        public static readonly DependencyProperty ButtonTextProperty = DependencyProperty.Register(
            "ButtonText",
            typeof(string),
            typeof(HomeNavButton),
            new FrameworkPropertyMetadata(
                "Link",
                FrameworkPropertyMetadataOptions.AffectsRender
            )
        );
        public string ButtonText
        {
            get { return (string)GetValue(ButtonTextProperty); }
            set { SetValue(ButtonTextProperty, value); }
        }


        public static readonly DependencyProperty IconSourceProperty = DependencyProperty.Register(
            "IconSource",
            typeof(string),
            typeof(HomeNavButton),
            new FrameworkPropertyMetadata(
                "Icons/VSImageLibrary/OpenFolder.svg",
                FrameworkPropertyMetadataOptions.AffectsRender
            )
        );

        public string IconSource
        {
            get { return (string)GetValue(IconSourceProperty); }
            set { SetValue(IconSourceProperty, value); }
        }

        public HomeNavButton()
        {
            InitializeComponent();
            //buttonLabel.DataContext = this;
        }

        private bool clicking = false;
        public event MouseButtonEventHandler Click;

        private void navButton_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            buttonLabel.TextDecorations.Add(TextDecorations.Underline);
        }

        private void navButton_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            buttonLabel.TextDecorations.Remove(TextDecorations.Underline[0]);
            if (clicking) clicking = false;
        }

        private void navButton_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            clicking = true;
        }

        private void navButton_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (clicking && Click != null)
            {
                clicking = false;
                Click(this, e);
            }
        }
    }
}
