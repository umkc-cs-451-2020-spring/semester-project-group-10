using ReactiveUI;
using SchedulingLib;
using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AppWindows.ViewModels
{
    class ModelDataContext: ReactiveObject
    {
        private string _searchTerm;
        public string SearchTerm
        {
            get => _searchTerm;
            set => this.RaiseAndSetIfChanged(ref _searchTerm, value);
        }

        private readonly ObservableAsPropertyHelper<IEnumerable<BaseViewModel>> propResults;
        private readonly SchedulerClient client;

        public IEnumerable<BaseViewModel> SearchResults => propResults.Value;

        public ModelDataContext(SchedulerClient client)
        {
            this.client = client;

            propResults = this
            .WhenAnyValue(x => x.SearchTerm)
            .Throttle(TimeSpan.FromMilliseconds(800))
            .Select(term => term?.Trim())
            .DistinctUntilChanged()
            .Where(term => !string.IsNullOrWhiteSpace(term))
            .SelectMany(Search)
            .ObserveOn(RxApp.MainThreadScheduler)
            .ToProperty(this, x => x.SearchResults);

            // We subscribe to the "ThrownExceptions" property of our OAPH, where ReactiveUI 
            // marshals any exceptions that are thrown in SearchNuGetPackages method. 
            // See the "Error Handling" section for more information about this.
            propResults.ThrownExceptions.Subscribe(error => { /* Handle errors here */ });
        }

        private async Task<IEnumerable<BaseViewModel>> Search(string term, CancellationToken token)
        {
            throw new NotImplementedException();
            //return await client.ListInstructors();
        }
    }
}
