using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace WeatherApp.Models
{
    public class GeoNamesAPI
    {
        private IList<City> _cities = new List<City>();

        public IList<City> Cities
        {
            get { return _cities; }
            set { _cities = value; }
        }

        private string fcode;

        public IList<City> getNames(string searchstring)
        {
            WebRequest request = WebRequest.Create("http://api.geonames.org/search?name=" + searchstring +"&country=SE&type=json&username=jensaronsson");

            WebResponse respons = request.GetResponse();

            Stream stream = respons.GetResponseStream();

            StreamReader reader = new StreamReader(stream);

            string responseFromServer = reader.ReadToEnd();

            JObject obj = JObject.Parse(responseFromServer);

            var geonames = obj["geonames"];

            foreach (var geoname in geonames)
            {
               fcode = (string)geoname["fcode"];

               if (fcode == "PPLA2" || fcode == "PPLC" || fcode == "PPLA" || fcode == "PPL")
               {
                   City city = new City{Name = (string)geoname["toponymName"], State = (string)geoname["adminName1"]};
                    _cities.Add(city);

               }
            }

            return _cities;
        }
    }
}