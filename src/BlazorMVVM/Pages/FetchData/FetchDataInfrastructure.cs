using BlazorMVVM.Pages.FetchData;
using Infrastructure.MVVM;

namespace BlazorMVVM.Pages.Counter
{
    public class FetchDataInfrastructure
    {
        public readonly FetchDataVM FetchDataVM;
        public readonly IVMDataSource FetchDataVMDataSource;
        public readonly IVMInitializerAsync FetchDataVMInitializer;

        public FetchDataInfrastructure(FetchDataVM fetchDataVM, IVMDataSource fetchDataVMDataSource, IVMInitializerAsync fetchDataVMInitializer)
        {
            ParameterChecker.IsNotNull(fetchDataVM, nameof(fetchDataVM));
            ParameterChecker.IsNotNull(fetchDataVMDataSource, nameof(fetchDataVMDataSource));
            ParameterChecker.IsNotNull(fetchDataVMInitializer, nameof(fetchDataVMInitializer));

            this.FetchDataVM = fetchDataVM;
            this.FetchDataVMDataSource = fetchDataVMDataSource;
            this.FetchDataVMInitializer = fetchDataVMInitializer;
        }
    }
}
