using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace HorariosEntrevistas.Api.Models;
public class Horario
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public ObjectId Id { get; set; }

    public string PmId { get; set; }

    public DateTime DataHora { get; set; }

    public bool Ocupado { get; set; }
}
