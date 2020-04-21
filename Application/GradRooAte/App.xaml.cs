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
        public LocalScheduler scheduler;

        void Start(object Sender, StartupEventArgs args)
        {
            scheduler = new LocalScheduler();
            scheduler.NewInstructor(new SchedulingLib.models.Instructor { FirstName = "Foo", LastName = "Bar" }) ;
        }
    }
}
