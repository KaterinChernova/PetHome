using Microsoft.AspNetCore.Mvc;
using PetHome.Dto;
using PetHome.Services;

namespace PetHome.Controllers;
[ApiController]
[Route("[controller]")] // [Route("pets")]
public class PetsController : ControllerBase
{
    private readonly IPetService _petService;
    
    public PetsController(IPetService petService)
    {
      _petService = petService;
    }
    
    //POST /pets
    [HttpPost]
    public ActionResult AddPet([FromBody] AddPetRequest request)
    {
        _petService.CreatePet(request);
        
        return Ok();
    }
    
    [HttpGet("{id:guid}")]
    public ActionResult Get([FromRoute] Guid id)
    {
        var pet = _petService.GetPet(id);
        
        return Ok(pet);
    }
    
    [HttpGet]
    public ActionResult Get()
    {
        var pets = _petService.GetPets();
        
        return Ok(pets);
    }
}