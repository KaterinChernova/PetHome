namespace PetHome.Services;

internal interface INotificationSender
{
    void Send(string message);
}