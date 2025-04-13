using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using ZooManagerWebApp.Application;
using ZooManagerWebApp.Domain.Entities;
using ZooManagerWebApp.Domain.ValueObjects.AnimalValueObjects;
using ZooManagerWebApp.Domain.ValueObjects.EnclosureValueObjects;

namespace ZooManagerWebApp.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AnimalController : ControllerBase
{
    private readonly AnimalTransferService _animalTransferService;

    public AnimalController(AnimalTransferService animalTransferService)
    {
        _animalTransferService = animalTransferService;
    }

    [HttpPost("add-animal")]
    public IActionResult AddAnimal([FromBody] CreateAnimalRequest request)
    {
        var animal = new Animal(
            new AnimalType(request.Type),
            new AnimalName(request.Name),
            new AnimalBirthday(request.Birthday),
            request.Sex,
            new AnimalFavoriteFood(request.FavoriteFood),
            request.HealthState
        );

        _animalTransferService.AddAnimal(animal);
        return Ok("Animal added successfully.");
    }

    [HttpDelete("remove-animal/{animalId}")]
    public IActionResult RemoveAnimal(Guid animalId)
    {
        _animalTransferService.RemoveAnimal(new AnimalId(animalId));
        return Ok("Animal removed successfully.");
    }

    [HttpPost("transfer-animal")]
    public IActionResult TransferAnimal([FromBody] TransferAnimalRequest request)
    {
        _animalTransferService.TransferAnimal(
            new AnimalId(request.AnimalId),
            new EnclosureId(request.SourceEnclosureId),
            new EnclosureId(request.TargetEnclosureId)
        );
        return Ok("Animal transferred successfully.");
    }
}

public class CreateAnimalRequest
{
    public string Type { get; set; }
    public string Name { get; set; }
    public DateOnly Birthday { get; set; }
    public AnimalSex Sex { get; set; }
    public string FavoriteFood { get; set; }
    public AnimalHealthState HealthState { get; set; }
}

public class TransferAnimalRequest
{
    public Guid AnimalId { get; set; }
    public Guid SourceEnclosureId { get; set; }
    public Guid TargetEnclosureId { get; set; }
}