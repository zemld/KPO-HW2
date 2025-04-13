using Microsoft.AspNetCore.Mvc;
using ZooManagerWebApp.Application;
using ZooManagerWebApp.Domain.Entities;
using ZooManagerWebApp.Domain.ValueObjects.EnclosureValueObjects;

namespace ZooManagerWebApp.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EnclosureController : ControllerBase
{
    private readonly AnimalTransferService _animalTransferService;

    public EnclosureController(AnimalTransferService animalTransferService)
    {
        _animalTransferService = animalTransferService;
    }

    [HttpPost("add-enclosure")]
    public IActionResult AddEnclosure([FromBody] CreateEnclosureRequest request)
    {
        var enclosure = new Enclosure(
            request.Type,
            new EnclosureSize(request.Length, request.Width, request.Height),
            new EnclosureCapacity(request.Capacity)
        );

        _animalTransferService.AddEnclosure(enclosure);
        return Ok("Enclosure added successfully.");
    }

    [HttpDelete("remove-enclosure/{enclosureId}")]
    public IActionResult RemoveEnclosure(Guid enclosureId)
    {
        _animalTransferService.RemoveEnclosure(new EnclosureId(enclosureId));
        return Ok("Enclosure removed successfully.");
    }
}

public class CreateEnclosureRequest
{
    public EnclosureType Type { get; set; }
    public double Length { get; set; }
    public double Width { get; set; }
    public double Height { get; set; }
    public int Capacity { get; set; }
}