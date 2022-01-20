namespace BlazorMVVM.Pages.Counter
{
    public interface ICounterFactory
    {
        CounterInfrastructure Create();
    }
}
