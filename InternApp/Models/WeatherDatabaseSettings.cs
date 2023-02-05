﻿namespace InternApp.API.Models
{
    public class WeatherDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public string CollectionName { get; set; } = null!; 
    }
}
