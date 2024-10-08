using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using school_admin_api.ActionFilters;
using school_admin_api.Contracts.DTO;
using school_admin_api.Contracts.Services;

namespace school_admin_api.Controllers.Admin;

[ApiController]
[Authorize]
[Route("api/user")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public UserController(
        IUserService userService,
        IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<UserDTO> Create([FromBody] UserForCreationDTO userDTO)
    {
        return _mapper.Map<UserDTO>(await _userService.Create(userDTO));
    }

    [HttpPut("{id:Guid}")]
    public async Task<UserDTO> Update(Guid id, [FromBody] UserForUpdateDTO userDTO)
    {
        return _mapper.Map<UserDTO>(await _userService.Update(id, userDTO));
    }

    [HttpDelete("{id:Guid}")]
    public async Task Delete(Guid id)
    {
        await _userService.Delete(id);
    }

    [HttpGet("{id:Guid}")]
    public async Task<UserDTO> Retrieve(Guid id)
    {
        return await _userService.Retrieve(id);
    }

    [HttpGet]
    public async Task<List<UserDTO>> RetrieveAll()
    {
        return await _userService.RetrieveAll();
    }

    [HttpGet("byRut")]
    public async Task<UserDTO> RetrieveByRut(string rut)
    {
        return _mapper.Map<UserDTO>(await _userService.RetrieveByRut(rut, trackChanges: false));
    }
}
