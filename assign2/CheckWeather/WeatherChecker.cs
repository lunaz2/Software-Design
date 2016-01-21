using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckWeather
{
    public class WeatherChecker
    {
        private IWeatherService weatherService;

        public List<WeatherCheckerData> getSortedWeatherData(List<WeatherCheckerData> weatherData)
        {
            return weatherData.OrderBy(data => data.City).ToList();            
        }

        public List<string> getMaxTemperature(List<WeatherCheckerData> weatherData)
        {
            if (weatherData.Where(data => data.Error == null).Count() == 0) return new List<string>();

            double maxTemperature = weatherData.Where(data => data.Error == null).Max(data => data.Temperature);
            return weatherData.Where(data => data.Temperature == maxTemperature).Select(data => data.City).ToList();
        }

        public List<string> getMinTemperature(List<WeatherCheckerData> weatherData)
        {
            if (weatherData.Where(data => data.Error == null).Count() == 0) return new List<string>();

            double maxTemperature = weatherData.Where(data => data.Error == null).Min(data => data.Temperature);
            return weatherData.Where(data => data.Temperature == maxTemperature).Select(data => data.City).ToList();
        }

        public void setWeatherService(IWeatherService theWeatherService)
        {
            weatherService = theWeatherService;
        }

        public Tuple<List<WeatherCheckerData>, List<string>, List<string>, List<WeatherCheckerData>> getWeatherData(List<string> citiesList)
        {
            List<WeatherCheckerData> weatherData = new List<WeatherCheckerData>();

            if (weatherService != null)
            {
                weatherData = citiesList.Select(city => weatherService.getCityData(city)).ToList();
                weatherData = getSortedWeatherData(weatherData);
            }
            else
                weatherData.Add(new WeatherCheckerData(new Exception("Error: No Service Found")));
            
            return new Tuple<List<WeatherCheckerData>, List<string>, List<string>, List<WeatherCheckerData>>(weatherData.Where(weather => weather.Error == null).ToList(),
                                        getMaxTemperature(weatherData), getMinTemperature(weatherData),
                                        weatherData.Where(weather => weather.Error != null).ToList());
        }

    }
}
