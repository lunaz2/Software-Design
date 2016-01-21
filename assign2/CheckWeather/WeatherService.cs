using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace CheckWeather
{
    public class WeatherService : IWeatherService
    {
        public WeatherCheckerData getCityData(string city)
        {
            string weatherJSON = getDataFromWeatherService(city);
            return parseWeatherJSON(weatherJSON, city);
        }

        public virtual WeatherCheckerData parseWeatherJSON(string weatherJSON, string city)
        {
            dynamic parsedJSON = JObject.Parse(weatherJSON);
            if (parsedJSON.message == null)
            {
                string condition = "";
                foreach (var weather in parsedJSON.weather)
                    condition += weather.main + " ";
                string temperature = parsedJSON.main.temp;
                string name = parsedJSON.name;

                return new WeatherCheckerData(name, temperature, condition.Trim());
            }
            else
            {
                string message = parsedJSON.message + " " + city;
                return new WeatherCheckerData(new Exception(message));
            }
        }

        public virtual string getDataFromWeatherService(string city)
        {
            WebClient client = new WebClient();
            try
            {
                return client.DownloadString("http://api.openweathermap.org/data/2.5/weather?q=" + city + ",us&units=imperial");
            }
            catch (Exception)
            {
                return @"{""message"":""Error: Cannot connect to Service"",""cod"":""404""}";
            }
        }

    }
}
