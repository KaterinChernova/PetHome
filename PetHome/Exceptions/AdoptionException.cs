namespace PetHome.Exceptions;

public enum AdoptionError
{
    InvalidId,
    PetNotFound,
    ApplicantNotFound,
    PetNotAvailable,
    ActiveApplicationAlreadyExists
}

public sealed class AdoptionException(AdoptionError error, string message)
    : Exception(message)
{
    public AdoptionError Error { get; } = error;
}
