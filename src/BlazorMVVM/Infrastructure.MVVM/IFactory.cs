
namespace Infrastructure.MVVM
{
    public interface IFactory
    {
        bool IsCreated { get; }
        void Create();
    }
}
