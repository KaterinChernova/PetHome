namespace PetHome.Exceptions;

public class ValidationException(string code, string message): Exception(message)
{
    public string Code { get; } = code;
}