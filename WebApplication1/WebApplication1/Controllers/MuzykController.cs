using APBD_10.RequestModels;
using APBD_10.Services;
using Microsoft.AspNetCore.Mvc;

namespace APBD_10.Controllers;

[Route("api/muzyk")]
[ApiController]
public class MuzykController : ControllerBase
{
    private readonly IMuzykService _service;

    public MuzykController(IMuzykService service)
    {
        _service = service;
    }

    [HttpGet("{id}")]
    public IActionResult GetMuzyk(int id)
    {
        var muzyk = _service.GetMuzyk(id);
        if (muzyk == null)
        {
            return NotFound();
        }

        return Ok(muzyk);
    }

    [HttpPost]
    public IActionResult AddMuzyk(MuzykRequest request)
    {
        if (!_service.AddMuzyk(request))
        {
            return BadRequest("utwor nie istnieje");
        }

        return Ok();
    }
}
