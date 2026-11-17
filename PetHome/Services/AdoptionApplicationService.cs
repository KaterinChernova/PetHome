using Microsoft.EntityFrameworkCore;
using PetHome.DataBase;
using PetHome.Dto;
using PetHome.Entities;
using PetHome.Enums;
using PetHome.Exceptions;

namespace PetHome.Services;

public class AdoptionApplicationService(PetHomeDbContext dbContext)
    : IAdoptionApplicationService
{
    public async Task<Guid> Add(
        AddAdoptionApplicationRequest request,
        CancellationToken cancellationToken = default)
    {
        if (request.PetId == Guid.Empty)
            throw new ValidationException(
                AdoptionError.InvalidId.ToString(), $"Некорретный PetId = {request.PetId}");
        
        if (request.ApplicantId == Guid.Empty)
            throw new ValidationException(
                AdoptionError.InvalidId.ToString(), $"Некорретный ApplicantId = {request.ApplicantId}");
            
        await using var transaction 
            = await dbContext.Database.BeginTransactionAsync(cancellationToken);
        
        var pets = await dbContext.Pets
            .FromSqlInterpolated($"SELECT * FROM pets WHERE \"Id\" = {request.PetId} FOR UPDATE")
            .AsTracking()
            .ToListAsync(cancellationToken);
        
        var pet = pets.FirstOrDefault();

        if (pet is null)
            throw new ValidationException(
                AdoptionError.PetNotFound.ToString(), $"Животное с ID={request.PetId} не найдено");
        
        if (pet.Status != PetStatus.Available)
            throw new ValidationException(
                AdoptionError.PetNotAvailable.ToString(), $"Животное с ID={request.PetId} не доступно для усыновления");

        var user = await dbContext.Users.FindAsync(request.ApplicantId, cancellationToken);
        if (user is null)
            throw new ValidationException(
                AdoptionError.ApplicantNotFound.ToString(), $"Пользователь с ID={request.ApplicantId} не найдено");

        var alreadyExists = dbContext.Applications
            .Any(a =>
                a.PetId == request.PetId
                && a.ApplicantId == request.ApplicantId
                && new[] { ApplicationStatus.Rejected, ApplicationStatus.Cancelled }.All(x => x != a.Status));
        if(alreadyExists)
            throw new ValidationException(
                AdoptionError.ActiveApplicationAlreadyExists.ToString(), $"Уже существует заявка этого пользователя на животное с ID={request.PetId} в активных статусах");

        var application = new AdoptionApplicationEntity()
        {
            Id = Guid.NewGuid(),
            PetId = request.PetId,
            ApplicantId = request.ApplicantId,
            ContactName = request.ContactName,
            ContactPhone = request.ContactPhone,
            ContactEmail = request.ContactEmail,
            Comment = request.Comment,
            CreatedAtUtc = DateTimeOffset.UtcNow,
            UpdatedAtUtc = DateTimeOffset.UtcNow,
            Status = ApplicationStatus.Created
        };

        dbContext.Applications.Add(application);
        
        await dbContext.SaveChangesAsync(cancellationToken);
        await transaction.CommitAsync(cancellationToken);
        
        return application.Id;
    }

    public async Task<IReadOnlyCollection<AdoptionApplicationDto>> GetCreatedApplications(CancellationToken cancellationToken)
    {
        return await dbContext.Applications
            .Where(a => a.Status == ApplicationStatus.Created)
            .Select(a => new AdoptionApplicationDto(
                Id: a.Id,
                PetId: a.PetId,
                PetName: a.Pet.Name,
                ApplicantId: a.ApplicantId,
                ApplicantDisplayName: a.Applicant.Name,
                ContactName: a.ContactName,
                Comment: a.Comment,
                Status: a.Status,
                CreatedAtUtc: a.CreatedAtUtc))
            .ToArrayAsync(cancellationToken);
    }
}