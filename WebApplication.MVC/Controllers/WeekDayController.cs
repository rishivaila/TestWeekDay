using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TestWeekDay.Models;

namespace WebApplication.MVC.Controllers
{
    public class WeekDayController : Controller
    {
        private static readonly string ApiUrl = "http://localhost:62733/api/Weekday";

        private readonly ILogger<WeekDayController> _logger;
        public WeekDayController(ILogger<WeekDayController> logger)
        {
            _logger = logger;
        }

        // GET: WeekDayController
        public ActionResult Index()
        {
            try
            {
                ApiHandler apiHandler = new ApiHandler();
                var apiHandlerResponse = apiHandler.Get(new ApiRequest { URL = ApiUrl, Param1 = "someValue" });
                return View(apiHandlerResponse);
            }
            catch (Exception e)
            {
                _logger.LogError("\nException :{0} ", e.Message);
            }
            return View();
        }

        [HttpPost]
        public ActionResult Index(List<string> dates)
        {          

            //Call API
            try
            {
                ApiHandler apiHandler = new ApiHandler();
                var apiHandlerResponse = apiHandler.Post(new ApiRequest { URL = ApiUrl, Dates = dates });
                return View(apiHandlerResponse);
            }
            catch (Exception ex)
            {
                throw;
            }
            return View();
        }
    }
}
