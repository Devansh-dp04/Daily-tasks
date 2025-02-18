using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Weather.NET;
using Weather.NET.Enums;
using Weather.NET.Models.WeatherModel;
namespace DOTNET_Day1.Controllers
{
    [Route("api/Weather/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        [HttpPost("PostRequest/{city}")]
        public IActionResult PostWeather( string city) {
            try
            {
                string API_KEY = "74990608688c51e27475591536971ec4";
                WeatherClient weather = new WeatherClient(API_KEY);
                var CurrWeather = weather.GetCurrentWeather(city);
                var temprature = CurrWeather.Main.Temperature;
                var atmpressure = CurrWeather.Main.AtmosphericPressure;
                var humidity = CurrWeather.Main.HumidityPercentage;
                return Ok(new { temprature, atmpressure, humidity });
            }
            catch (Exception)
            {
                return StatusCode(500, "Data cannot be obtained.");
            } 
        }

    }
}
