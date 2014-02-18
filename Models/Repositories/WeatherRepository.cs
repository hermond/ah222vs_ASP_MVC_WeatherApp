using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeatherApp.Models.DataModels;

namespace WeatherApp.Models.Repositories
{
    public class WeatherRepository : IWeatherRepository
    {

        weatherEntities _entities = new weatherEntities();

        public void Add(City city)
        {
            _entities.Cities.Add(city);
        }

        public void Update(City city)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            _entities.SaveChanges();
        }


        public IList<City> SearchCities(string city)
        {
           return _entities.Cities.Where(u => u.Name == city).ToList();
        }

        private bool disposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _entities.Dispose();
                }
                
                disposed = true;
            }
        }
    }
}