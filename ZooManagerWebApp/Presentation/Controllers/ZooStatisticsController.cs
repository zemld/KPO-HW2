using Microsoft.AspNetCore.Mvc;
using ZooManagerWebApp.Application;
using ZooManagerWebApp.Domain.Interfaces;

namespace ZooManagerWebApp.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ZooStatisticsController : ControllerBase
{
    private readonly ZooStatisticsService _zooStatisticsService;

    public ZooStatisticsController(ZooStatisticsService zooStatisticsService)
    {
        _zooStatisticsService = zooStatisticsService;
    }

    [HttpGet("total-animals")]
    public IActionResult GetTotalAnimals()
    {
        var totalAnimals = _zooStatisticsService.GetAmountOfAnimals();
        return Ok(new { TotalAnimals = totalAnimals });
    }

    [HttpGet("total-enclosures")]
    public IActionResult GetTotalEnclosures()
    {
        var totalEnclosures = _zooStatisticsService.GetAmountOfEnclosures();
        return Ok(new { TotalEnclosures = totalEnclosures });
    }
    
    [HttpGet("free-enclosures")]
    public IActionResult GetFreeEnclosures()
    {
        var freeEnclosures = _zooStatisticsService.GetFreeEnclosureStatistics();
        return Ok(new { FreeEnclosures = freeEnclosures });
    }

    [HttpGet("feeding-schedule-statistics")]
    public IActionResult GetFeedingScheduleStatistics()
    {
        var feedingSchedules = _zooStatisticsService.GetFeedingScheduleStatistics();

        var result = feedingSchedules.Select(schedule => new
        {
            AnimalName = schedule.Animal.Name,
            FeedingTime = schedule.FeedingTime.Time,
            FoodType = schedule.FoodType.Type
        });

        return Ok(result);
    }
}