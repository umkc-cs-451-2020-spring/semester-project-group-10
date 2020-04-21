using SchedulingLib;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace AppWindows
{

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static SchedulerClient scheduler;

        void Start(object Sender, StartupEventArgs args)
        {
            scheduler = LocalScheduler.Connect("./default.grdb");
            scheduler.NewInstructor(new SchedulingLib.models.Instructor { FirstName = "Foo", LastName = "Bar" }) ;
        }
    }
}
