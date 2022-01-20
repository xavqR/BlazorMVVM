using BlazorMVVM.Pages.FetchData;
using Infrastructure.MVVM;
using Infrastructure.MVVM.Commands;

namespace BlazorMVVM.Pages.Counter
{
    public class FetchDataFactory : IFetchDataFactory
    {
        private readonly FetchDataVM fetchDataVM;
        private readonly IVMDataSource fetchDataVMDataSource;
        private readonly IVMInitializer fetchDataVMInitializer;
        //private readonly ICounterVMCommandManager counterVMCommandManager;

        public FetchDataFactory(FetchDataVM fetchDataVM, IVMDataSource fetchDataVMDataSource, IVMInitializer fetchDataVMInitializer)
        {
            ParameterChecker.IsNotNull(fetchDataVM, nameof(fetchDataVM));
            ParameterChecker.IsNotNull(fetchDataVMDataSource, nameof(fetchDataVMDataSource));
            ParameterChecker.IsNotNull(fetchDataVMInitializer, nameof(fetchDataVMInitializer));

            this.fetchDataVM = fetchDataVM;
            this.fetchDataVMDataSource = fetchDataVMDataSource;
            this.fetchDataVMInitializer = fetchDataVMInitializer;
        }

        public FetchDataInfrastructure Create()
        {
            //ICommand incrementCountCommand = new RelayCommand(this.counterVMCommandManager.IncrementCountExecute);
            //this.fetchDataVM.SetCommands(incrementCountCommand);

            this.fetchDataVMDataSource.Start();

            return new FetchDataInfrastructure(this.fetchDataVM, this.fetchDataVMDataSource, this.fetchDataVMInitializer);
        }
    }
}
