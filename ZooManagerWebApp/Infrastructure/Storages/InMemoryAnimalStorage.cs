using ZooManagerWebApp.Domain.Entities;
using ZooManagerWebApp.Domain.Interfaces;
using ZooManagerWebApp.Domain.ValueObjects.AnimalValueObjects;

namespace ZooManagerWebApp.Infrastructure.Storages;

public class InMemoryAnimalStorage : IAnimalStorage
{
    public InMemoryAnimalStorage(Dictionary<AnimalId, Animal> animals)
    {
        Animals = animals;
    }

    public Dictionary<AnimalId, Animal> Animals { get; set; }
}