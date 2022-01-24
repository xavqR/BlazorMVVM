using Infrastructure.MVVM;
using Infrastructure.MVVM.Commands;

namespace BlazorMVVM.Pages.Counter
{
    public class CounterVM : PropertyChangedNotifier
    {
        private int currentCounter;
           
        public int CurrentCounter
        {
            get
            {
                return this.currentCounter;
            }
            set
            {
                if (this.currentCounter != value)
                {
                    this.currentCounter = value;
                    this.OnPropertyChanged(nameof(this.CurrentCounter));
                }
            }
        }

        public ICommand IncrementCountCommand { get; private set; }

        public void SetCommands(ICommand incrementCountCommand)
        {
            ParameterChecker.IsNotNull(incrementCountCommand, nameof(incrementCountCommand));

            this.IncrementCountCommand = incrementCountCommand;
        }
    }
}
