using InternApp.API.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace InternApp.API.Services
{
    public class WeatherService
    {
        private readonly IMongoCollection<WeatherForecast> _weatherCollection;

        public WeatherService(IOptions<WeatherDatabaseSettings> weatherDatabaseSettings)
        {
            IMongoClient mongoClient = new MongoClient(weatherDatabaseSettings.Value.ConnectionString);
            IMongoDatabase database = mongoClient.GetDatabase(weatherDatabaseSettings.Value.DatabaseName);

            _weatherCollection = database.GetCollection<WeatherForecast>(weatherDatabaseSettings.Value.CollectionName);
        }

        public List<WeatherForecast> Get()
        {
            return _weatherCollection.Find(_ => true).ToList();
        }
    }
}
