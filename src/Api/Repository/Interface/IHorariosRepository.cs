using HorariosEntrevistas.Api.Service.DTO;

namespace HorariosEntrevistas.Api.Repository.Interface;

public interface IHorariosRepository
{
    IEnumerable<HorarioDTO> GetHorariosDisponiveis();
    void MarcarHorario(string pmId, DateTime dataHora, bool ocupado);
    void AtualizarStatusHorario(string pmId, DateTime dataHora, bool ocupado);
}
