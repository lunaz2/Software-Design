using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using CheckWeather;
using Rhino.Mocks;

namespace CheckWeatherTest
{
    class WeatherServiceTest
    {
        private WeatherService weatherService;

        [SetUp]
        public void SetUp()
        {
            weatherService = new WeatherService();
        }

        [Test]
        public void ParseWeatherJSONReturnCorrectOutput()
        {
            string jsonString = @"{""coord"":{""lon"":-95.37,""lat"":29.76},
                                ""sys"":{""message"":0.2941,""country"":""United States of America"",""sunrise"":1426077316,""sunset"":1426120047},
                                ""weather"":[{""id"":802,""main"":""Clouds"",""description"":""scattered clouds"",""icon"":""03n""}],
                                ""base"":""cmc stations"",""main"":{""temp"":53.06,""temp_min"":53.06,""temp_max"":53.06,""pressure"":1030.03,""sea_level"":1031.73,""grnd_level"":1030.03,""humidity"":94},
                                ""wind"":{""speed"":2.87,""deg"":349.502},""clouds"":{""all"":32},""dt"":1426056462,""id"":4699066,""name"":""Houston"",""cod"":200}";
            
            var expected = new WeatherCheckerData("Houston", "53.06", "Clouds");
            var actual = weatherService.parseWeatherJSON(jsonString, "Houston");

            Assert.AreEqual(expected.City, actual.City);
            Assert.AreEqual(expected.Temperature, actual.Temperature);
            Assert.AreEqual(expected.Condition, actual.Condition);
            Assert.AreEqual(expected.Error, actual.Error);
        }

        [Test]
        public void ParseWeatherJSONWithInvalidCity()
        {
            string jsonString = @"{""message"":""Error: Not found city"",""cod"":""404""}";

            var expected = new WeatherCheckerData( new Exception("Error: Not found city Houston"));
            var actual = weatherService.parseWeatherJSON(jsonString, "Houston");

            Assert.AreEqual(expected.Error.Message, actual.Error.Message);
        }

        [Test]
        public void getDataFromWeatherServiceReturnJSON()
        {
            string actual = weatherService.getDataFromWeatherService("New York");
            Assert.AreEqual("New York", actual.Substring(actual.IndexOf("New York"),8));
        }

        [Test]
        public void getDataFromWeatherServiceWithInvalidCity()
        {
            Assert.AreEqual(@"{""message"":""Error: Not found city"",""cod"":""404""}", weatherService.getDataFromWeatherService("@#").Trim());
        }

        [Test]
        public void getDataFromWeatherServiceWhenNoService()
        {
            Assert.AreEqual(@"{""message"":""Error: Cannot connect to Service"",""cod"":""404""}", weatherService.getDataFromWeatherService("\n"));
        }

        [Test]
        public void getCityDataCalled2Methods()
        {
            var stub = MockRepository.GenerateStub<WeatherService>();
            
            stub.getCityData("");

            stub.AssertWasCalled(s => s.getDataFromWeatherService(Arg<string>.Is.Anything));
            stub.AssertWasCalled(s => s.parseWeatherJSON(Arg<string>.Is.Anything, Arg<string>.Is.Anything));
        }
    }
}
