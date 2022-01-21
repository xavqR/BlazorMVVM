using BlazorMVVM.Pages.Counter;
using Infrastructure.MVVM;

namespace BlazorMVVM.Resolvers
{
    public class VMInitializerResolver : IResolver<IVMInitializer>
    {
        private readonly IServiceProvider serviceProvider;

        public VMInitializerResolver(IServiceProvider serviceProvider)
        {
            ParameterChecker.IsNotNull(serviceProvider, nameof(serviceProvider));

            this.serviceProvider = serviceProvider;
        }

        public IVMInitializer Resolve(string key)
        {
            switch (key)
            {
                case nameof(CounterVMInitializer):
                    return this.serviceProvider.GetService<CounterVMInitializer>();
                case nameof(FetchDataVMInitializer):
                    return this.serviceProvider.GetService<FetchDataVMInitializer>();
                default:
                    throw new KeyNotFoundException();
            }
        }
    }
}
