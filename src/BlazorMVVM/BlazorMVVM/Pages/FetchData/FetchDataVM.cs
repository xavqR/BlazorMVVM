using Infrastructure.MVVM;
using System.Collections.ObjectModel;

namespace BlazorMVVM.Pages.FetchData
{
    public class FetchDataVM : PropertyChangedNotifier
    {
        private readonly ObservableCollection<ForecastVM> forecastsVM;

        public ObservableCollection<ForecastVM> ForecastsVM 
        {
            get
            {
               return this.forecastsVM;
            }
        }

        public FetchDataVM()
        {
            forecastsVM = new ObservableCollection<ForecastVM>();
        }
    }
}
