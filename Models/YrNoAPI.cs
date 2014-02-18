using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Linq;

namespace WeatherApp.Models
{
    public class YrNoAPI
    {
        private List<Weather> _5daysOfWeather = new List<Weather>();
        private List<Weather> _newWeatherList = new List<Weather>();
        private List<string> _weathers = new List<string>();

        public List<Weather> NewWeatherList {

            get
            {
                return _newWeatherList;
            }
        }
        public IList<Weather> getWeatherFromYR(string state, string city)
        {

            var xmldoc = new XmlDocument();
                
             xmldoc.Load("http://www.yr.no/place/Sweden/"+ state+"/"+city+"/forecast.xml");

             var list = xmldoc.SelectNodes("/weatherdata/forecast/tabular/time");
             
             for (int i = 0; i < list.Count; i++)
             {
                 var timeFrom = list[i].Attributes["from"].Value;
                 var timeTo = list[i].Attributes["to"].Value;
                 var period = list[i].Attributes["period"].Value;
                 var typeOfWeather = list[i].SelectSingleNode("symbol").Attributes["name"].Value;
                 var windDirection = list[i].SelectSingleNode("windDirection").Attributes["name"].Value;
                 var windSpeed = list[i].SelectSingleNode("windSpeed").Attributes["mps"].Value;
                 var typeOfWind = list[i].SelectSingleNode("windSpeed").Attributes["name"].Value;
                 var celciusTemperature = list[i].SelectSingleNode("temperature").Attributes["value"].Value;

                 var weather = new Weather { Period = period, TimeFrom = DateTime.Parse(timeFrom), TimeTo = DateTime.Parse(timeTo),
                    TypeofWeather = typeOfWeather, WindDirection = windDirection, WindSpeed = windSpeed, 
                    TypeOfWind = typeOfWind, CelciusTemperature = celciusTemperature };
                 //var period = int.Parse(list[i].Attributes["period"].Value);
                 //if (period == 2)
                 //{
                 //    var periodname = xmldoc.SelectNodes("/weatherdata/forecast/tabular/time/symbol");
                 //   string periodnamestring = periodname[i].Attributes["name"].Value;
                 //   _weathers.Add(periodnamestring);
                 //}
                 //_weathers.Add(list[i].Attributes["from"].Value);
                 _5daysOfWeather.Add(weather);
                 
             }

             sortWeather(_5daysOfWeather);
             return _newWeatherList;

        }

        private void sortWeather(List<Weather> weatherList)
        {
            if (weatherList[0].Period == "2" || weatherList[0].Period == "3")
            {
                _newWeatherList.Add(weatherList[0]);
            }
            for (int i = 1; i < weatherList.Count; i++)
            {
                if (weatherList[i].Period == "2")
                {
                    _newWeatherList.Add(weatherList[i]);
                }
            }
            _newWeatherList = _newWeatherList.Take(5).ToList();
        }

     
    }
}