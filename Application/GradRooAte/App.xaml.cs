using SchedulingLib;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;

namespace AppWindows
{

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        internal SchedulerClient scheduler;

        public static App CurrentApp
        {
            get
            {
                return Current as App;
            }
        }
    }

}
