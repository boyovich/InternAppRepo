using MongoDB.Bson.Serialization.Attributes;

namespace InternApp.API.Models
{
    public class WeatherForecast
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? Id { get; set; }
        public string Description { get; set; }

    }
}
