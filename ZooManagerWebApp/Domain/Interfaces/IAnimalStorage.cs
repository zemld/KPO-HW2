using ZooManagerWebApp.Domain.Entities;
using ZooManagerWebApp.Domain.ValueObjects.AnimalValueObjects;

namespace ZooManagerWebApp.Domain.Interfaces;

public interface IAnimalStorage
{
    public Dictionary<AnimalId, Animal> Animals { get; set; }

    public Animal GetAnimalById(AnimalId id)
    {
        return Animals[id];
    }
}