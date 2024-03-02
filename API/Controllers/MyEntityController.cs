using Microsoft.AspNetCore.Mvc;
using school_admin_api.Contracts.DTO;
using school_admin_api.Contracts.Services;

namespace school_admin_api.Controllers;

[ApiController]
[Route("api/myentity")]
public class MyEntityController : ControllerBase
{
    private readonly IMyEntityService _myEntityService;

    public MyEntityController(
        IMyEntityService myEntityService
        )
    {
        _myEntityService = myEntityService;
    }

    [HttpPost]
    public async Task<int> Create([FromBody] MyEntityForCreationDTO myEntityDTO)
    {
        return await _myEntityService.Create(myEntityDTO);
    }

    [HttpPut("{idMyEntity:int}")]
    public async Task Update(int idMyEntity, [FromBody] MyEntityForUpdateDTO myEntityDTO)
    {
        await _myEntityService.Update(idMyEntity, myEntityDTO);
    }

    [HttpDelete("{idMyEntity:int}")]
    public async Task Delete(int idMyEntity)
    {
        await _myEntityService.Delete(idMyEntity);
    }

    [HttpGet("{idMyEntity:int}")]
    public async Task<MyEntityDTO> Retrieve(int idMyEntity)
    {
        return await _myEntityService.Retrieve(idMyEntity);
    }

    [HttpGet]
    public async Task<List<MyEntityDTO>> RetrieveAll()
    {
        return await _myEntityService.RetrieveAll();
    }
}
