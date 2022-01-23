using BlazorMVVM.Pages.FetchData;
using Infrastructure.MVVM;

namespace BlazorMVVM.Pages.Counter
{
    public class FetchDataFactory : IFetchDataFactory
    {
        private readonly FetchDataVM fetchDataVM;
        private readonly IVMDataSource fetchDataVMDataSource;
        private readonly IVMInitializerAsync fetchDataVMInitializer;

        public FetchDataFactory(FetchDataVM fetchDataVM, IResolver<IVMDataSource> dataSourceResolver, IVMInitializerAsync initializerResolver)
        {
            ParameterChecker.IsNotNull(fetchDataVM, nameof(fetchDataVM));
            ParameterChecker.IsNotNull(dataSourceResolver, nameof(dataSourceResolver));
            ParameterChecker.IsNotNull(initializerResolver, nameof(initializerResolver));

            this.fetchDataVM = fetchDataVM;
            this.fetchDataVMDataSource = dataSourceResolver.Resolve(nameof(FetchDataVMDataSource));
            this.fetchDataVMInitializer = initializerResolver; 
        }

        public FetchDataInfrastructure Create()
        {
            this.fetchDataVMDataSource.Start();

            return new FetchDataInfrastructure(this.fetchDataVM, this.fetchDataVMDataSource, this.fetchDataVMInitializer);
        }
    }
}
