namespace ZooManagerWebApp.Domain.ValueObjects.AnimalValueObjects;

public class AnimalId
{
    public Guid Id { get;}

    public AnimalId()
    {
        Id = new Guid();
    }

    public AnimalId(Guid animalId)
    {
        Id = animalId;
    }
}