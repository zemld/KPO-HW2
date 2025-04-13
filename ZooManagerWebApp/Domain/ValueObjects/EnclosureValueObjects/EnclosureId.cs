namespace ZooManagerWebApp.Domain.ValueObjects.EnclosureValueObjects;

public class EnclosureId
{
    public Guid Id { get; }

    public EnclosureId()
    {
        Id = new Guid();
    }

    public EnclosureId(Guid enclosureId)
    {
        Id = enclosureId;
    }
}