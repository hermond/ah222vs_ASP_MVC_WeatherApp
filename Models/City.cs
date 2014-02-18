using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WeatherApp.Models
{
    [MetadataType(typeof(City_Metadata))]
    public partial class City
    {

    }
    public class City_Metadata
    {
        public string Name { get; set; }
        public string State { get; set; }


    }

}