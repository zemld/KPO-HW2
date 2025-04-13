using ZooManagerWebApp.Domain.Entities;
using ZooManagerWebApp.Domain.Interfaces;
using ZooManagerWebApp.Domain.ValueObjects.EnclosureValueObjects;

namespace ZooManagerWebApp.Infrastructure.Storages;

public class InMemoryEnclosureStorage : IEnclosureStorage
{
    public InMemoryEnclosureStorage(Dictionary<EnclosureId, Enclosure> enclosures)
    {
        Enclosures = enclosures;
    }

    public Dictionary<EnclosureId, Enclosure> Enclosures { get; set; }
}