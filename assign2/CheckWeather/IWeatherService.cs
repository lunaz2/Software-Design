using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CheckWeather
{
    public interface IWeatherService
    {
        WeatherCheckerData getCityData(string city);
    }
}
