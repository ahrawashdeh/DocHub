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
    private readonly ILogger<DiLifetimesController> _logger;

    public DiLifetimesController(
        TransientLifetimeService transient,
        ScopedLifetimeService scoped,
        SingletonLifetimeService singleton,
        ILogger<DiLifetimesController> logger)
    {
        _transient = transient;
        _scoped = scoped;
        _singleton = singleton;
        _logger = logger;
    }

    [HttpGet]
    public ActionResult Get()
    {
        _logger.LogInformation(
            "Resolved DI lifetime instances: Transient {TransientInstanceId}, Scoped {ScopedInstanceId}, Singleton {SingletonInstanceId}",
            _transient.InstanceId,
            _scoped.InstanceId,
            _singleton.InstanceId);

        return Ok(new
        {
            transient = _transient.InstanceId,
            scoped = _scoped.InstanceId,
            singleton = _singleton.InstanceId
        });
    }
}
