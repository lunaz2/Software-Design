using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckWeather;

namespace CheckWeatherConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            WeatherChecker weatherChecker = new WeatherChecker();
            IWeatherService weatherService = new WeatherService();
            weatherChecker.setWeatherService(weatherService);
            
            Console.WriteLine("Read Cities List from:" + args[0]);
            string text = System.IO.File.ReadAllText(args[0]);
            List<string> citiesList = text.Split('\n').ToList();

            citiesList = citiesList.Select(city => city.Trim()).Distinct().ToList();

            var result = weatherChecker.getWeatherData(citiesList);

            Console.WriteLine("\nCities List Data Sort by Ascending Order:");
            result.Item1.ForEach(data => Console.WriteLine(data.City + " " + data.Temperature + " " + data.Condition));

            Console.WriteLine("\nHottest Cities:");
            result.Item2.ForEach(data => Console.WriteLine(data));

            Console.WriteLine("\nColdest Cities:");
            result.Item3.ForEach(data => Console.WriteLine(data));

            Console.WriteLine("\nError Cities:");
            result.Item4.ForEach(data => Console.WriteLine(data.City + " " + data.Error.Message));
            
        }
    }
}
