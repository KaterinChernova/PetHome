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
    public async Task<ActionResult> AddPet([FromBody] AddPetRequest request)
    {
        await _petService.CreatePet(request);
        
        return Ok();
    }
    
    [HttpGet("{id:guid}")]
    public async Task<ActionResult> Get([FromRoute] Guid id)
    {
        var pet = await _petService.GetPet(id);
        
        return Ok(pet);
    }
    
    [HttpGet]
    public async Task<ActionResult> Get()
    {
        var pets = await _petService.GetPets();
        
        return Ok(pets);
    }
}