namespace PetHome.Services;

public interface ICounterService
{
    int Counter { get; set; }
}

public class CounterService : ICounterService
{
    public int Counter { get; set; }
}