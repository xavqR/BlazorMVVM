using BlazorMVVM.Pages.Counter;
using Infrastructure.MVVM;

namespace BlazorMVVM.Resolvers
{
    public class VMDataSourceResolver : IResolver<IVMDataSource>
    {
        private readonly IServiceProvider serviceProvider;

        public VMDataSourceResolver(IServiceProvider serviceProvider)
        {
            ParameterChecker.IsNotNull(serviceProvider, nameof(serviceProvider));

            this.serviceProvider = serviceProvider;
        }

        public IVMDataSource Resolve(string key)
        {
            switch (key)
            {
                case nameof(CounterVMDataSource):
                    return this.serviceProvider.GetService<CounterVMDataSource>();
                case nameof(FetchDataVMDataSource):
                    return this.serviceProvider.GetService<FetchDataVMDataSource>();
                default:
                    throw new KeyNotFoundException();
            }
        }
    }
}
