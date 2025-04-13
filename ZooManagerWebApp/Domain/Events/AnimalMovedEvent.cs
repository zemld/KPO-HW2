using ZooManagerWebApp.Domain.ValueObjects.AnimalValueObjects;
using ZooManagerWebApp.Domain.ValueObjects.EnclosureValueObjects;

namespace ZooManagerWebApp.Domain.Events;

public class AnimalMovedEvent
{
    public AnimalId AnimalId { get; }
    public EnclosureId FromEnclosureId { get; }
    public EnclosureId ToEnclosureId { get; }
    public DateTime Timestamp { get; }

    public AnimalMovedEvent(AnimalId animalId, EnclosureId fromEnclosureId, EnclosureId toEnclosureId)
    {
        AnimalId = animalId;
        FromEnclosureId = fromEnclosureId;
        ToEnclosureId = toEnclosureId;
        Timestamp = DateTime.UtcNow;
    }
}