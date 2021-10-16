using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using tes_extramile.api.Models;
using tes_extramile.api.Helper;

namespace tes_extramile.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherApiController : ControllerBase
    {
        [HttpGet("{idCity}")]
        public async Task<Weathermodel> GetAsync(float idCity)
        {
            string keyApi = "d3f584537f9ed5ea0389116277f34900";
            HelperApi _api = new HelperApi();
            var url = "/data/2.5/weather?id=" + idCity + "&appid=" + keyApi;

            HttpResponseMessage response = new HttpResponseMessage();
            try
            {
                HttpClient client = _api.Initial();
                response = await client.GetAsync(url);
                Console.WriteLine("status response : " + response.IsSuccessStatusCode);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
            var results = response.Content.ReadAsStringAsync().Result;

            dynamic obj = JsonConvert.DeserializeObject<dynamic>(results);

            Weathermodel _apiWeather = new Weathermodel()
            {
                lon = obj["coord"]["lon"],

                 lat = obj["coord"]["lat"],

                waktu = obj["timezone"],

                windSp = obj["wind"]["speed"],
                visibility = obj["visibility"],
                skyCon = obj["weather"][0]["description"],
                tempCel = obj["main"]["temp"],
                tempFah = obj["main"]["temp"],
                dew = obj["clouds"]["all"],
                humid = obj["main"]["humidity"],
                press = obj["main"]["pressure"],
                    
            };
            _apiWeather.tempCel=_apiWeather.SetFahrenheitToCelsius(_apiWeather.tempFah);
            //var _api = JsonConvert.DeserializeObject<string>(results);

            //TODO: log error, throw exception or do other stuffs for failed requests here.
            Console.WriteLine(obj["coord"]["lon"]);

            return _apiWeather;
        }
    }
}