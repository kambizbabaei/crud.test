using Microsoft.AspNetCore.Mvc;

namespace crud.test.Api.Controller;

[ApiController]
[Route("api/[controller]")]
public abstract class BaseController : ControllerBase
{
    protected ActionResult<TResult> OkOrNotFound<TResult>(TResult result)
    {
        return result is null ? NotFound() : Ok(result);
    }
}