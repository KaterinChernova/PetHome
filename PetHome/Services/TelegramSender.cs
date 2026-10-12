namespace PetHome.Services;

public class TelegramSender: INotificationSender
{
    private readonly ICounterService _counterService;

    public TelegramSender(ICounterService counterService)
    {
        _counterService = counterService;
    }

    public void Send(string message)
    {
        _counterService.Counter++;
        Console.WriteLine($"TGSenderService: {_counterService.Counter}");
        Console.WriteLine($"Send by tg: {message}");
    }
}