using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeatherApp.Models.Repositories
{
    public interface IWeatherRepository : IDisposable
    {
        void Add(City city);
        void Update(City city);
        void Save();
        IList<City> SearchCities(string city);
        
        
    }
}