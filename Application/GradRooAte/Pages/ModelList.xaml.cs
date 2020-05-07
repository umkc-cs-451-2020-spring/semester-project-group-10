using AppWindows.ViewModels;
using DynamicData;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ReactiveUI;
using SchedulingLib;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Disposables;
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
    public partial class ModelList : Page, IViewFor<BaseListViewModel>
    {
        public ModelList(string model)
        {
            InitializeComponent();

            ViewModel = BaseListViewModel.For(model);

            this.WhenActivated(disposable =>
            {
                foreach (var col in ViewModel.Columns)
                {
                    col.Width = listView.ActualWidth / (ViewModel.Columns.Count() + 1);
                }
                gridView.Columns.Add(ViewModel.Columns);

                this.Bind(ViewModel, x => x.SearchTerm, x => x.textBox.Text).DisposeWith(disposable);
                this.OneWayBind(ViewModel, x => x.SearchResults, x => x.listView.ItemsSource).DisposeWith(disposable);
            });
        }

        public static readonly DependencyProperty ViewModelProperty = DependencyProperty.Register(nameof(ViewModel), typeof(BaseListViewModel), typeof(ModelList));
        public BaseListViewModel ViewModel
        {
            get => GetValue(ViewModelProperty) as BaseListViewModel;
            set => SetValue(ViewModelProperty, value);
        }
        object IViewFor.ViewModel
        {
            get => ViewModel;
            set => ViewModel = value as BaseListViewModel;
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (textBoxPlaceholder.Visibility == Visibility.Visible && textBox.Text.Length > 0)
                textBoxPlaceholder.Visibility = Visibility.Hidden;
            else if (textBox.Text.Length == 0)
                textBoxPlaceholder.Visibility = Visibility.Visible;
        }
    }
}
