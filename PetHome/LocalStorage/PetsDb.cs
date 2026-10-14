using System.Collections.Concurrent;
using PetHome.Dto;
using PetHome.Entities;
using PetHome.Enums;

namespace PetHome.LocalStorage;

public static class PetsDb
{
    public static ConcurrentDictionary<Guid, PetEntity> Pets => new();
}