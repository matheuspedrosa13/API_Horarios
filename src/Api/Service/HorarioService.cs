// HorarioService.cs
using HorariosEntrevistas.Api.Repository.Interface;
using HorariosEntrevistas.Api.Service.DTO;
using HorariosEntrevistas.Api.Service.Interface;

public class HorarioService : IHorariosService
{
    private readonly IHorariosRepository _repository;

    public HorarioService(IHorariosRepository repository)
    {
        _repository = repository;
    }

    public IEnumerable<HorarioDTO> GetHorariosDisponiveis()
    {
        return _repository.GetHorariosDisponiveis();
    }

    public void MarcarHorario(string pmId, DateTime dataHora, bool ocupado)
    {
        _repository.MarcarHorario(pmId, dataHora, ocupado);
    }

    public void AtualizarStatusHorario(string pmId, DateTime dataHora, bool ocupado)
    {
        _repository.AtualizarStatusHorario(pmId, dataHora, ocupado);
    }

    IEnumerable<HorarioDTO> IHorariosService.GetHorariosDisponiveis()
    {
        throw new NotImplementedException();
    }
}
