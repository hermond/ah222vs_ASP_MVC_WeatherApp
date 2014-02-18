using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WeatherApp.Models
{
     [MetadataType(typeof(Weather_Metadata))]
    public partial class Weather
    {

        
     }

         public class Weather_Metadata
         {

            public string Period { get; set; }
            public string TimeFrom { get; set; }
            public string TimeTo { get; set; }
            public string TypeOfWeather { get; set; }
            public string WindDirection { get; set; }
            public string WindSpeed { get; set; }
            public string TypeOfWind { get; set; }
            public string CelciusTemperature { get; set; }


     
         
         }




}