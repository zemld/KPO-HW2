namespace ZooManagerWebApp.Domain.ValueObjects.AnimalValueObjects;

public class AnimalName
{
    public string Name { get; }
    
    public AnimalName(string name)
    {
        Name = name;
    }
}