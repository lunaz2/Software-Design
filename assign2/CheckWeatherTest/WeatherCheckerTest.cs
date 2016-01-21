using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Rhino.Mocks;
using CheckWeather;

namespace CheckWeatherTest
{
    [TestFixture]
    public class WeatherCheckerTest
    {
        private WeatherChecker checkWeather;
        private List<WeatherCheckerData> weatherData;
        private MockRepository mocks;
        private IWeatherService weatherServiceMock;

        WeatherCheckerData houston = new WeatherCheckerData("Houston", "39.5", "");
        WeatherCheckerData dallas = new WeatherCheckerData("Dallas", "50.44", "");
        WeatherCheckerData austin = new WeatherCheckerData("Austin", "40", "");
        WeatherCheckerData boston = new WeatherCheckerData("Boston", "32", "");
        WeatherCheckerData newyork = new WeatherCheckerData(new Exception("Error: Not found city"));
        [SetUp]
        public void SetUp()
        {
            checkWeather = new WeatherChecker();
            weatherData = new List<WeatherCheckerData> { houston, dallas, austin, boston };
            mocks = new MockRepository();
            weatherServiceMock = mocks.Stub<IWeatherService>();
            using (mocks.Record())
            {
                SetupResult.For(weatherServiceMock.getCityData("New York")).Return(newyork);
                SetupResult.For(weatherServiceMock.getCityData("Boston")).Return(boston);
                SetupResult.For(weatherServiceMock.getCityData("Houston")).Return(houston);
                SetupResult.For(weatherServiceMock.getCityData("Austin")).Return(austin);
                SetupResult.For(weatherServiceMock.getCityData("Dallas")).Return(dallas);
            }
        }

        [Test]
        public void getSortWeatherDataSortByCity()
        {
            List<WeatherCheckerData> expected = new List<WeatherCheckerData> { austin, boston, dallas, houston };
            Assert.AreEqual(expected, checkWeather.getSortedWeatherData(weatherData));
        }

        [Test]
        public void getSortedWeatherDataForEmptyData()
        {
            List<WeatherCheckerData> empty = new List<WeatherCheckerData>();
            List<WeatherCheckerData> expected = new List<WeatherCheckerData>();
            Assert.AreEqual(expected, checkWeather.getSortedWeatherData(empty));
        }

        [Test]
        public void getMaxTemperatureCities()
        {
            List<string> expected = new List<string> { "Dallas" };
            Assert.AreEqual(expected, checkWeather.getMaxTemperature(weatherData));
        }

        [Test]
        public void getMaxTemperatureCitiesForEmptyData()
        {
            List<WeatherCheckerData> empty = new List<WeatherCheckerData>();
            List<string> expected = new List<string>();
            Assert.AreEqual(expected, checkWeather.getMaxTemperature(empty));
        }

        [Test]
        public void getMaxTemperatureCitiesOnSameTemperatureCity()
        {
            WeatherCheckerData newyork = new WeatherCheckerData("New York", "50.44", "");
            weatherData.Add(newyork);

            List<string> expected = new List<string> { "Dallas",  "New York" };
            Assert.AreEqual(expected, checkWeather.getMaxTemperature(weatherData));
        }

        [Test]
        public void getMinTemperatureCities()
        {
            List<string> expected = new List<string> { "Boston" };
            Assert.AreEqual(expected, checkWeather.getMinTemperature(weatherData));
        }

        [Test]
        public void getMinTemperatureCitiesForEmptyData()
        {
            List<WeatherCheckerData> empty = new List<WeatherCheckerData>();
            List<string> expected = new List<string>();
            Assert.AreEqual(expected, checkWeather.getMinTemperature(empty));
        }

        [Test]
        public void getMinTemperatureCitiesOnSameTemperatureCity()
        {
            WeatherCheckerData newyork = new WeatherCheckerData("New York", "32", "");
            weatherData.Add(newyork);

            List<string> expected = new List<string> { "Boston", "New York" };
            Assert.AreEqual(expected, checkWeather.getMinTemperature(weatherData));
        }

        [Test]
        public void getWeatherDataWhenNoService()
        {
            List<string> citiesList = new List<string> { "Houston", "Boston", "Austin", "Dallas" };

            var expected = new Tuple<List<WeatherCheckerData>, List<string>, List<string>, List<WeatherCheckerData>>(new List<WeatherCheckerData>(), new List<string>(), new List<string>(), new List<WeatherCheckerData> { new WeatherCheckerData(new Exception("Error: No Service Found")) });
            
            Assert.AreEqual(expected.Item1, checkWeather.getWeatherData(citiesList).Item1);
            Assert.AreEqual(expected.Item2, checkWeather.getWeatherData(citiesList).Item2);
            Assert.AreEqual(expected.Item3, checkWeather.getWeatherData(citiesList).Item3);
            Assert.AreEqual(expected.Item4[0].Error.Message, checkWeather.getWeatherData(citiesList).Item4[0].Error.Message);
        }

        [Test]
        public void getWeatherDataReturnWeatherDataForCitiesList()
        {
            List<string> citiesList = new List<string> { "Houston", "Boston", "Austin", "Dallas" };
            checkWeather.setWeatherService(weatherServiceMock);

            var expected = new Tuple<List<WeatherCheckerData>, List<string>, List<string>, List<WeatherCheckerData>>(new List<WeatherCheckerData> { austin, boston, dallas, houston }, new List<string> { "Dallas" }, new List<string> { "Boston" }, new List<WeatherCheckerData>());
            Assert.AreEqual(expected.Item1, checkWeather.getWeatherData(citiesList).Item1);
            Assert.AreEqual(expected.Item2, checkWeather.getWeatherData(citiesList).Item2);
            Assert.AreEqual(expected.Item3, checkWeather.getWeatherData(citiesList).Item3);
            Assert.AreEqual(expected.Item4, checkWeather.getWeatherData(citiesList).Item4);
        }

        [Test]
        public void getWeatherDataReturnWeatherDataForEmptyCitiesList()
        {
            List<string> citiesList = new List<string>();
            checkWeather.setWeatherService(weatherServiceMock);

            var expected = new Tuple<List<WeatherCheckerData>, List<string>, List<string>, List<WeatherCheckerData>>(new List<WeatherCheckerData>(), new List<string>(), new List<string>(), new List<WeatherCheckerData>());
            Assert.AreEqual(expected.Item1, checkWeather.getWeatherData(citiesList).Item1);
            Assert.AreEqual(expected.Item2, checkWeather.getWeatherData(citiesList).Item2);
            Assert.AreEqual(expected.Item3, checkWeather.getWeatherData(citiesList).Item3);
            Assert.AreEqual(expected.Item4, checkWeather.getWeatherData(citiesList).Item4);
        }

        [Test]
        public void getWeatherDataWithErrorCityInList()

        {
            List<string> citiesList = new List<string> { "New York", "Boston", "Austin", "Dallas", "Houston" };
            checkWeather.setWeatherService(weatherServiceMock);

            var expected = new Tuple<List<WeatherCheckerData>, List<string>, List<string>, List<WeatherCheckerData>>(new List<WeatherCheckerData> { austin, boston, dallas, houston }, new List<string> { "Dallas" }, new List<string> { "Boston" }, new List<WeatherCheckerData> { newyork });
            Assert.AreEqual(expected.Item1, checkWeather.getWeatherData(citiesList).Item1);
            Assert.AreEqual(expected.Item2, checkWeather.getWeatherData(citiesList).Item2);
            Assert.AreEqual(expected.Item3, checkWeather.getWeatherData(citiesList).Item3);
            Assert.AreEqual(expected.Item4, checkWeather.getWeatherData(citiesList).Item4);
        }


    }

}
