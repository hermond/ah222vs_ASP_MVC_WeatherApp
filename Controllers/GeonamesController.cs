using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WeatherApp.Models;
using WeatherApp.Models.Repositories;

namespace WeatherApp.Controllers
{
    public class GeonamesController : Controller
    {
        private IWeatherRepository _repository;
      
        private GeoNamesAPI geonamesApi;


        private YrNoAPI yrNoApi;


        private MainPageViewModel mainPageViewModel;
       
        public GeonamesController()
            : this(new WeatherRepository())
        {
            // emtpy
        }


        public GeonamesController(IWeatherRepository repo)
        {
            _repository = repo;
        }

   

        public ActionResult Index()
        {

            return View("Index", mainPageViewModel);
        }


        [HttpPost]
        public ActionResult Search([Bind(Include = "SearchString")] WeatherApp.Models.SearchViewModel search)
        {
            
            mainPageViewModel = new MainPageViewModel();
            geonamesApi = new GeoNamesAPI();


           if (ModelState.IsValid)
            {
            var cities = _repository.SearchCities(search.SearchString);

                if (cities.Count() == 0)
                {
                    cities = geonamesApi.getNames(search.SearchString);

                    if (cities.Count() == 0)
                    {
                        mainPageViewModel.NoCities = true;
 
                    }
                    int i = 0;
                    foreach (var city in cities)
                    {
                        city.CityID = i++;
                        _repository.Add(city);
                    }

                    _repository.Save();

                }
                if (cities.Count == 1)
                {
                    return getWeather(cities.First().Name, cities.First().State);
                }

                mainPageViewModel.Cities = cities;
            }
            return View("Index", mainPageViewModel);
        }

        public ActionResult getWeather(string city, string state)
        {
            //string city = Request["city"];
            //string state = Request["state"];
            mainPageViewModel = new MainPageViewModel();
            yrNoApi = new YrNoAPI();

            mainPageViewModel.City = city;
            mainPageViewModel.State = state;
            
            mainPageViewModel.FiveDaysOfWeather= yrNoApi.getWeatherFromYR(state, city);

            return View("Index", mainPageViewModel);

            
        }
        
    }
}
