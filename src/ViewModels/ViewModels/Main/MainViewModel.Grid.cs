using BAJIEPA.Senticode.Wpf.Collections;
using BAJIEPA.Senticode.Wpf.Interfaces;

namespace ViewModels.ViewModels
{
    public partial class MainViewModel
    {
        public IObservableRangeCollection<object> GridData { get; } = new ObservableRangeCollection<object>();
    }
}