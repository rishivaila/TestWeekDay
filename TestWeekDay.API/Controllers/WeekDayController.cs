using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestWeekDay.API.Services;
using TestWeekDay.Models;

namespace TestWeekDay.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeekDayController : ControllerBase
    {

        private readonly ILogger<WeekDayController> _logger;
        private readonly IWeekDayService _weekDayService;

        public WeekDayController(ILogger<WeekDayController> logger, IWeekDayService weekDayService)
        {
            _logger = logger;
            _weekDayService = weekDayService;
        }

        [HttpGet]
        public IActionResult Get(string param1)
        {
            var serviceResponse = _weekDayService.GetDays(new WeekDayServiceRequest { Dates = GetRandomDates() });
            var response = new ApiResponse { IsValid = true, Result = serviceResponse.Days };
            return Ok(response);
        }

        [HttpPost]
        public IActionResult Post(List<string> dates)
        {
            if (dates.Any(p=> string.IsNullOrEmpty(p)))
                dates = GetRandomDates();
            var serviceResponse = _weekDayService.GetDays(new WeekDayServiceRequest { Dates = dates });
            var response = new ApiResponse { IsValid = true, Result = serviceResponse.Days };
            return Ok(response);
        }

        [NonAction]
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
