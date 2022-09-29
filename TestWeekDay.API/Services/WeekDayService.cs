using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestWeekDay.Models;

namespace TestWeekDay.API.Services
{
    public interface IWeekDayService
    {
        WeekDayServiceResponse GetDays(WeekDayServiceRequest request);
    }
    public class WeekDayService : IWeekDayService
    {
        public WeekDayServiceResponse GetDays(WeekDayServiceRequest request)
        {
            var resp = new WeekDayServiceResponse();
            var weekDays = new List<WeekDay>();
            var lst = new List<string>();

            int index = 0;
            foreach (var item in request.Dates)
            {
                var time = DateTime.Now.TimeOfDay;
                var newDate = Convert.ToDateTime($"{item} {time}");
                weekDays.Add(new WeekDay { 
                    Index = index,
                    SummaryText = $"{index++}. {newDate.DayOfWeek}",
                    CurrentDate = newDate.ToShortDateString(),
                    CurrentTime = newDate.ToString(),
                    CurrentTime1 = newDate.AddDays(1).ToString(),
                    CurrentTime2 = newDate.AddDays(2).ToString(),
                    CurrentTime3 = newDate.AddDays(3).ToString(),
                    CurrentTime4 = newDate.AddDays(4).ToString(),
                    CurrentTime5 = newDate.AddDays(5).ToString(),
                    CurrentTime6 = newDate.AddDays(6).ToString(),
                });
            }

            //var daysInWeek = Enum.GetValues(typeof(DayOfWeek));
            //foreach (int index in daysInWeek)
            //{
            //    weekDays.Add(new WeekDay
            //    {
            //        IsParameterPassed = false,
            //        WeekDaySummary = $"{Enum.GetName(typeof(DayOfWeek), index)}[{index}]",
            //        CurrentTime = DateTime.Now.ToString(),
            //        CurrentTime1 = DateTime.Now.AddDays(1).ToString(),
            //        CurrentTime2 = DateTime.Now.AddDays(2).ToString(),
            //        Property = DateTime.Now
            //    });
            //}
            resp.Days = weekDays;
            return resp;
        }
    
    
    }
}
