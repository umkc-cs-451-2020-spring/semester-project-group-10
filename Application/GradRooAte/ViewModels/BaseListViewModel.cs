using AppWindows.ViewModels.Instructors;
using ReactiveUI;
using SchedulingLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reactive.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace AppWindows.ViewModels
{
    public abstract class BaseListViewModel: ReactiveObject
    {
        private string _searchTerm;
        public string SearchTerm
        {
            get => _searchTerm;
            set => this.RaiseAndSetIfChanged(ref _searchTerm, value);
        }

        private readonly ObservableAsPropertyHelper<IEnumerable<INotifyPropertyChanged>> searchResults;

        public IEnumerable<INotifyPropertyChanged> SearchResults => searchResults.Value;
        public IEnumerable<GridViewColumn> Columns { get; protected set; }

        protected readonly SchedulerClient client = App.CurrentApp.scheduler;

        internal static BaseListViewModel For(string model)
        {
            return model switch
            {
                "Instructors" => new InstructorListViewModel(),
                _ => throw new NotImplementedException()
            };
        }

        public BaseListViewModel()
        {
            searchResults = this
                .WhenAnyValue(x => x.SearchTerm)
                .Throttle(TimeSpan.FromMilliseconds(800))
                .Select(term => term?.Trim())
                .DistinctUntilChanged()
                .SelectMany(Search)
                .ObserveOn(RxApp.MainThreadScheduler)
                .ToProperty(this, x => x.SearchResults);

            // We subscribe to the "ThrownExceptions" property of our OAPH, where ReactiveUI 
            // marshals any exceptions that are thrown in SearchNuGetPackages method. 
            // See the "Error Handling" section for more information about this.
            searchResults.ThrownExceptions.Subscribe(error => { /* Handle errors here */ });
        }

        public abstract Task<IEnumerable<INotifyPropertyChanged>> Search(string term, CancellationToken token);
    }
}
