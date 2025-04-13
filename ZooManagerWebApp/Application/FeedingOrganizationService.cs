using ZooManagerWebApp.Domain.Entities;
using ZooManagerWebApp.Domain.Interfaces;
using ZooManagerWebApp.Domain.ValueObjects.AnimalValueObjects;
using ZooManagerWebApp.Domain.ValueObjects.FeedingScheduleValueObjects;

namespace ZooManagerWebApp.Application;

public class FeedingOrganizationService
{
    private readonly IFeedingScheduleStorage _feedingScheduleStorage;

    public FeedingOrganizationService(IFeedingScheduleStorage feedingScheduleStorage)
    {
        _feedingScheduleStorage = feedingScheduleStorage;
    }

    public FeedingSchedule GetFeedingSchedule(FeedingScheduleId feedingScheduleId)
    {
        return _feedingScheduleStorage.FeedingSchedules[feedingScheduleId];
    }

    public void AddFeedingSchedule(FeedingScheduleId feedingScheduleId)
    {
        var feedingSchedule = _feedingScheduleStorage.GetFeedingScheduleById(feedingScheduleId);
        _feedingScheduleStorage.FeedingSchedules.Add(feedingScheduleId, feedingSchedule);
    }
}