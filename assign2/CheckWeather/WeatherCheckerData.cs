using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckWeather
{
    public class WeatherCheckerData
    {
        public string City { get; private set; }
        public double Temperature { get; private set; }
        public string Condition { get; private set; }
        public Exception Error { get; set; }
        public WeatherCheckerData(string city, string temperature, string condition)
        {
            City = city;
            Temperature = Convert.ToDouble(temperature);
            Condition = condition;
        }
        public WeatherCheckerData(Exception error)
        {
            Error = error;
        }
    }
}
