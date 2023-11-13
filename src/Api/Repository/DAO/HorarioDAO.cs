using MongoDB.Driver;
using HorariosEntrevistas.Api.Repository.Interface;
using HorariosEntrevistas.Api.Models;
using HorariosEntrevistas.Api.Service.DTO;

namespace HorariosEntrevistas.Api.Repository.DAO;
public class HorarioRepository : IHorariosRepository
{
    private readonly IMongoCollection<Horario> _collection;

    public HorarioRepository(IMongoDatabase database)
    {
        _collection = database.GetCollection<Horario>("horarios");
    }

    public IEnumerable<HorarioDTO> GetHorariosDisponiveis()
    {
        var horariosDisponiveis = _collection.Find(x => !x.Ocupado).ToList();
        return horariosDisponiveis.Select(h => new HorarioDTO { PmId = h.PmId, DataHora = h.DataHora, Ocupado = h.Ocupado });
    }

    public void MarcarHorario(string pmId, DateTime dataHora, bool ocupado)
    {
        var horario = new Horario { PmId = pmId, DataHora = dataHora, Ocupado = ocupado };
        _collection.InsertOne(horario);
    }

    public void AtualizarStatusHorario(string pmId, DateTime dataHora, bool ocupado)
    {
        var filter = Builders<Horario>.Filter.Eq(h => h.PmId, pmId) & Builders<Horario>.Filter.Eq(h => h.DataHora, dataHora);
        var update = Builders<Horario>.Update.Set(h => h.Ocupado, ocupado);

        _collection.UpdateOne(filter, update);
    }

    IEnumerable<HorarioDTO> IHorariosRepository.GetHorariosDisponiveis()
    {
        throw new NotImplementedException();
    }
}
