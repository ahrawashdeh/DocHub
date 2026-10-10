using DocumentPlatform.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace DocumentPlatform.Api.Controllers;

[ApiController]
[Route("api/di-lifetimes")]
public class DiLifetimesController : ControllerBase
{
    private readonly TransientLifetimeService _transient;
    private readonly ScopedLifetimeService _scoped;
    private readonly SingletonLifetimeService _singleton;

    public DiLifetimesController(
        TransientLifetimeService transient,
        ScopedLifetimeService scoped,
        SingletonLifetimeService singleton)
    {
        _transient = transient;
        _scoped = scoped;
        _singleton = singleton;
    }

    [HttpGet]
    public ActionResult Get()
    {
        return Ok(new
        {
            transient = _transient.InstanceId,
            scoped = _scoped.InstanceId,
            singleton = _singleton.InstanceId
        });
    }
}
