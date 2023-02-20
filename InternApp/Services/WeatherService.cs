using Hangfire;
using InternApp.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Diagnostics;

namespace InternApp.API.Services
{
    public class WeatherService
    {
        private readonly IMongoCollection<WeatherForecast> _weatherCollection;

        public class JobHandler
        {
            public void Execute(int index)
            {
                Thread.Sleep(200);
                Debug.WriteLine($@"Hangfire fire-and-forget task started ({index}) - [{Environment.CurrentManagedThreadId}]");
            }
        }

        public WeatherService(IOptions<WeatherDatabaseSettings> weatherDatabaseSettings)
        {
            IMongoClient mongoClient = new MongoClient(weatherDatabaseSettings.Value.ConnectionString);
            IMongoDatabase database = mongoClient.GetDatabase(weatherDatabaseSettings.Value.DatabaseName);

            _weatherCollection = database.GetCollection<WeatherForecast>(weatherDatabaseSettings.Value.CollectionName);
        }

        public List<WeatherForecast> Get()
        {
            try
            {
                var weathers = _weatherCollection.Find(_ => true).Skip((int)_weatherCollection.CountDocuments(_ => true) - 7).ToList();
                return weathers;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return new List<WeatherForecast>();
        }

        public void Recurring()
        {
            _weatherCollection.InsertMany(new List<WeatherForecast>() 
                { new WeatherForecast() { Description = "Foggy", Date = DateTime.Now.AddDays(1) } ,
                  new WeatherForecast() { Description = "Sunny", Date = DateTime.Now.AddDays(2) } ,
                  new WeatherForecast() { Description = "Cloudy", Date = DateTime.Now.AddDays(3) } ,
                  new WeatherForecast() { Description = "Partly Cloudy", Date = DateTime.Now.AddDays(4) } ,
                  new WeatherForecast() { Description = "Partly Sunny", Date = DateTime.Now.AddDays(5) } ,
                  new WeatherForecast() { Description = "Windy", Date = DateTime.Now.AddDays(6) } ,
                  new WeatherForecast() { Description = "Wet", Date = DateTime.Now.AddDays(7) }
                });
        }
    }
}
