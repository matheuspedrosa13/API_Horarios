// HorarioController.cs
using HorariosEntrevistas.Api.Service.DTO;
using HorariosEntrevistas.Api.Service.Interface;
using Microsoft.AspNetCore.Mvc;
namespace HorariosEntrevistas.Api.Controller;

[Route("api/[controller]")]
[ApiController]
public class HorarioController : ControllerBase
{
    private readonly IHorariosService _service;

    public HorarioController(IHorariosService service)
    {
        _service = service;
    }

    [HttpGet]
    public ActionResult<IEnumerable<HorarioDTO>> GetHorariosDisponiveis()
    {
        var horariosDisponiveis = _service.GetHorariosDisponiveis();
        return Ok(horariosDisponiveis);
    }

    [HttpPost]
    [Route("marcar")]
    public ActionResult MarcarHorario(string pmId, DateTime dataHora, bool ocupado)
    {
        _service.MarcarHorario(pmId, dataHora, ocupado);
        return Ok($"Horário marcado para o PM {pmId}.");
    }

    [HttpPut]
    [Route("atualizar")]
    public ActionResult AtualizarStatusHorario(string pmId, DateTime dataHora, bool ocupado)
    {
        _service.AtualizarStatusHorario(pmId, dataHora, ocupado);
        return Ok($"Status do horário {dataHora} atualizado para o PM {pmId}.");
    }
}
