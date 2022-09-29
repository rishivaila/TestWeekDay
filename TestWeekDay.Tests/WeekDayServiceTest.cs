using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using TestWeekDay.API.Controllers;
using TestWeekDay.API.Services;
using TestWeekDay.Models;

namespace TestWeekDay.Tests
{
    public class WeekDayServiceTest
    {
        WeekDayService _weekDayService;

        [SetUp]
        public void SetUp()
        {
            _weekDayService = new WeekDayService();
        }

        [Test]
        public void IsNotNull_WithNoInputs_ReturnTrue()
        {
            var result = _weekDayService.GetDays(new WeekDayServiceRequest { Dates = GetRandomDates() });

            Assert.IsNotNull(result);
        }
        [Test]
        public void TestDefaultData()
        {
            //Posted data from UI
            List<string> dates = new List<string>();
            dates.Add("10-09-2022");
            dates.Add("15-09-2022");
            dates.Add("20-09-2022");
            dates.Add("25-09-2022");
            dates.Add("30-09-2022");
            dates.Add("05-10-2022");
            dates.Add("17-10-2022");
            var result = _weekDayService.GetDays(new WeekDayServiceRequest { Dates = dates});

            Assert.IsNotNull(result);
            Assert.AreEqual("11-09-2022", result.Days.FirstOrDefault().CurrentTime1.Split(' ')[0]);
        }

        [Test]
        public void IsNotNull_WithNextDayFromArray_ReturnTrue()
        {
            //Posted data from UI
            List<string> dates = new List<string>();
            dates.Add("10-09-2022");
            dates.Add("15-09-2022");
            dates.Add("20-09-2022");
            dates.Add("25-09-2022");
            dates.Add("30-09-2022");
            dates.Add("05-10-2022");
            dates.Add("17-10-2022");

            var result = _weekDayService.GetDays(new WeekDayServiceRequest { Dates = dates });

            Assert.IsNotNull(result);
            Assert.AreEqual("11-09-2022", result.Days.FirstOrDefault().CurrentTime1.Split(' ')[0]);
        }

        public List<string> GetRandomDates()
        {
            var date = DateTime.Now;
            List<string> days = new List<string>();
            for (int i = 0; i < 7; i++)
            {
                days.Add(date.AddDays(i).ToShortDateString());
            }
            return days;
        }
    }
}