
namespace Infrastructure.MVVM
{
    public interface IVMInitializerAsync
    {
        Task InitializeAsync(CancellationToken token);
    }
}
