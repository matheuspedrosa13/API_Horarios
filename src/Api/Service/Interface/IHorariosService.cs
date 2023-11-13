using HorariosEntrevistas.Api.Service.DTO;

namespace HorariosEntrevistas.Api.Service.Interface;

public interface IHorariosService
{
    IEnumerable<HorarioDTO> GetHorariosDisponiveis();
    void MarcarHorario(string pmId, DateTime dataHora, bool ocupado);
    void AtualizarStatusHorario(string pmId, DateTime dataHora, bool ocupado);
}