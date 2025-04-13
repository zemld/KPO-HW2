using ZooManagerWebApp.Domain.Entities;
using ZooManagerWebApp.Domain.Interfaces;
using ZooManagerWebApp.Domain.ValueObjects.AnimalValueObjects;
using ZooManagerWebApp.Domain.ValueObjects.EnclosureValueObjects;

namespace ZooManagerWebApp.Application;

public class AnimalTransferService
{
    private readonly IAnimalStorage _animalStorage;
    private readonly IEnclosureStorage _enclosureStorage;
    
    public AnimalTransferService(IAnimalStorage animalStorage, IEnclosureStorage enclosureStorage)
    {
        _animalStorage = animalStorage;
        _enclosureStorage = enclosureStorage;
    }

    private void RemoveAnimalFromEnclosure(AnimalId animalId, EnclosureId enclosureId)
    {
        var enclosure = _enclosureStorage.GetEnclosureById(enclosureId);
        var animal = _animalStorage.GetAnimalById(animalId);
        enclosure.DeleteAnimal(animal);
    }

    private void AddAnimalToEnclosure(AnimalId animalId, EnclosureId enclosureId)
    {
        var enclosure = _enclosureStorage.GetEnclosureById(enclosureId);
        var animal = _animalStorage.GetAnimalById(animalId);
        enclosure.AddAnimal(animal);
    }
    
    public void AddAnimal(Animal animal)
    {
        _animalStorage.Animals.TryAdd(animal.Id, animal);
    }

    public void RemoveAnimal(AnimalId animalId)
    {
        _animalStorage.Animals.Remove(animalId);
        foreach (var enclosure in _enclosureStorage.Enclosures)
        {
            RemoveAnimalFromEnclosure(animalId, enclosure.Key);
        }
    }

    public void TransferAnimal(AnimalId animalId, EnclosureId sourceEnclosureId, EnclosureId targetEnclosureId)
    {
        RemoveAnimalFromEnclosure(animalId, sourceEnclosureId);
        AddAnimalToEnclosure(animalId, targetEnclosureId);
    }

    public void AddEnclosure(Enclosure enclosure)
    {
        _enclosureStorage.Enclosures.TryAdd(enclosure.Id, enclosure);
    }

    public void RemoveEnclosure(EnclosureId enclosureId)
    {
        var enclosure = _enclosureStorage.GetEnclosureById(enclosureId);
        _enclosureStorage.Enclosures.Remove(enclosureId);
        foreach (var animal in enclosure.Animals)
        {
            RemoveAnimalFromEnclosure(animal.Id, enclosureId);
        }
    }
}