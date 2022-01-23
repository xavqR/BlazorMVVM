using Infrastructure.MVVM;

namespace BlazorMVVM.Pages.Counter
{
    public class CounterModel : PropertyChangedNotifier
    {

        private int counter;

        public int Counter
        {
            get
            {
                return this.counter;
            }
            set
            {
                if (this.counter != value)
                {
                    this.counter = value;
                    this.OnPropertyChanged(nameof(this.Counter));
                }
            }
        }
    }
}
