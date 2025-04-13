using ZooManagerWebApp.Domain.ValueObjects.AnimalValueObjects;
using ZooManagerWebApp.Domain.ValueObjects.FeedingScheduleValueObjects;

namespace ZooManagerWebApp.Domain.Events;

public class FeedingTimeEvent
{
    public AnimalId AnimalId { get; }
    public DateTime ScheduledTime { get; }
    public FoodType FoodType { get; }

    public FeedingTimeEvent(AnimalId animalId, DateTime scheduledTime, FoodType foodType)
    {
        AnimalId = animalId;
        ScheduledTime = scheduledTime;
        FoodType = foodType;
    }
}