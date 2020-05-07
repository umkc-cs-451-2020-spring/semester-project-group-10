using DynamicData;
using ReactiveUI;
using SchedulingLib;
using SchedulingLib.models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace AppWindows.ViewModels.Instructors
{
    class InstructorListViewModel : BaseListViewModel
    {
        private static readonly List<GridViewColumn> dataColumns = new List<GridViewColumn>
        {
            new GridViewColumn {
                Header = "Name",
                DisplayMemberBinding = new MultiBinding { StringFormat = "{0} {1}", Bindings = { new Binding("FirstName"), new Binding("LastName") } }
            },
            new GridViewColumn {
                Header = "Availability",
                DisplayMemberBinding = new Binding("Availability")
            },
        };

        public InstructorListViewModel()
        {
            Columns = dataColumns;
        }

        public override async Task<IEnumerable<INotifyPropertyChanged>> Search(string term, CancellationToken token)
        {
            return await client.ListInstructors(term, token);
        }
    }
}
