using ZooManagerWebApp.Domain.Entities;
using ZooManagerWebApp.Domain.Interfaces;
using ZooManagerWebApp.Domain.ValueObjects.FeedingScheduleValueObjects;

namespace ZooManagerWebApp.Infrastructure.Storages;

public class InMemoryFeedingScheduleStorage : IFeedingScheduleStorage
{
    public InMemoryFeedingScheduleStorage(Dictionary<FeedingScheduleId, FeedingSchedule> feedingSchedules)
    {
        FeedingSchedules = feedingSchedules;
    }

    public Dictionary<FeedingScheduleId, FeedingSchedule> FeedingSchedules { get; set; }
}