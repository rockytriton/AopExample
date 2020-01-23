using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dn {
    public interface IWeatherBac {
        WeatherForecast FetchForecast();

        IEnumerable<WeatherForecast> FetchAll();

        void InsertForecast(WeatherForecast fc);
    }
}
