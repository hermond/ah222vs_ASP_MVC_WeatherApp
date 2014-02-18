using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WeatherApp.Models
{
    public class MainPageViewModel
    {
        
        public string City { get; set; }
        public string State { get; set; }
        public IList<City> Cities { get; set; }
        //public bool HasOneCity { get { return Cities != null && Cities.Count() == 1; } }
        public bool HasManyCities { get { return Cities != null && Cities.Count() > 1; } }
        public bool NoCities { get; set; }
        public IList<Weather> FiveDaysOfWeather { get; set; }
    }
}