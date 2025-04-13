using ZooManagerWebApp.Domain.Entities;
using ZooManagerWebApp.Domain.ValueObjects.EnclosureValueObjects;

namespace ZooManagerWebApp.Domain.Interfaces;

public interface IEnclosureStorage
{
    public Dictionary<EnclosureId, Enclosure> Enclosures { get; set; }
    
    public Enclosure GetEnclosureById(EnclosureId id)
    {
        return Enclosures[id];
    }
}