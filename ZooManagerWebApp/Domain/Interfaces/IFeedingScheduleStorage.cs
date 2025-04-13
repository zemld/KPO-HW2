using ZooManagerWebApp.Domain.Entities;
using ZooManagerWebApp.Domain.ValueObjects.FeedingScheduleValueObjects;

namespace ZooManagerWebApp.Domain.Interfaces;

public interface IFeedingScheduleStorage
{
    public Dictionary<FeedingScheduleId, FeedingSchedule> FeedingSchedules { get; set; }
    
    public FeedingSchedule GetFeedingScheduleById(FeedingScheduleId id)
    {
        return FeedingSchedules[id];
    }
}