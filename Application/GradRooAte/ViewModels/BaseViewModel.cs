using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace AppWindows.ViewModels
{
    internal abstract class BaseViewModel: ReactiveObject
    {
        public static GridViewColumnCollection ListColumns { get; }
        public static Window DataWindow { get; }
    }
}
