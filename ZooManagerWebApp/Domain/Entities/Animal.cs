using ZooManagerWebApp.Domain.ValueObjects.AnimalValueObjects;

namespace ZooManagerWebApp.Domain.Entities;

public class Animal
{
    public AnimalId Id { get; }
    public AnimalType Type { get; }
    public AnimalName Name { get; }
    public AnimalBirthday Birthday { get; }
    public AnimalSex Sex { get; }
    public AnimalFavoriteFood FavoriteFood { get; }
    public AnimalHealthState Health { get; }

    public Animal(AnimalType type, AnimalName name, AnimalBirthday birthday, AnimalSex sex,
        AnimalFavoriteFood favoriteFood, AnimalHealthState healthState)
    {
        Id = new AnimalId();
        Type = type;
        Name = name;
        Birthday = birthday;
        Sex = sex;
        FavoriteFood = favoriteFood;
        Health = healthState;
    }

    public void Feed() {}
    
    public void Heal() {}

    public void ChangeEnclosure(Enclosure newEnclosure) {}
}