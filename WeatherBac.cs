using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dn {
    public class WeatherBac : IWeatherBac {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public WeatherForecast FetchForecast() {
            System.Console.WriteLine("OK FETCHING");
            
            return new WeatherForecast();
        }

        public IEnumerable<WeatherForecast> FetchAll() {
            Console.WriteLine("FETCHING ALL");
            var rng = new Random();
            return Enumerable.Range(1, 1).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        public void InsertForecast(WeatherForecast fc) {
            System.Console.WriteLine("OK INSERTING");
        }
    }
}
