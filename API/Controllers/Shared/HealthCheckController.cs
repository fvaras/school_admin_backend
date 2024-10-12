using Microsoft.AspNetCore.Mvc;

namespace school_admin_api.Controllers.Shared;

[ApiController]
[Route("api/healthcheck")]
public class HealthCheckController : ControllerBase
{
    public HealthCheckController()
    {
    }

    [HttpGet("")]
    public string Retrieve()
    {
        return "OK";
    }
}
