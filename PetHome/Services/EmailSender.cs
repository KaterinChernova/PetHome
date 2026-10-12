namespace PetHome.Services;

internal class EmailSender : INotificationSender
{
    private readonly ICounterService _counterService;

    public EmailSender(ICounterService counterService)
    {
        _counterService = counterService;
    }

    public void Send(string message)
    {
        _counterService.Counter++;
        Console.WriteLine($"EmailSenderService: {_counterService.Counter}");
        Console.WriteLine($"Send by email: {message}");
    }
}