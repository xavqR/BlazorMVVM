namespace Infrastructure.MVVM
{
    public interface IResolver<T> where T : class
    {
        T Resolve(string key);
    }
}
