namespace PetHome.Services;

internal class SmsSender : INotificationSender
{
    private readonly ICounterService _counterService;
    public SmsSender(ICounterService counterService)
    {
        _counterService = counterService;
    }
    
    public void Send(string message)
    {
        _counterService.Counter++;
        Console.WriteLine($"SmsSenderService: {_counterService.Counter}");
        Console.WriteLine($"Send by sms: {message}");
    }
}