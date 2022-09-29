using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TestWeekDay.Models;

namespace WebApplication.MVC
{
    public class ApiHandler
    {
        public ApiResponse Get(ApiRequest request)
        {
            var response = new ApiResponse();

            using (HttpClient client = new HttpClient())
            {
                var apiResult = client.GetAsync(request.URL + "?param1=" + request.Param1).Result;
                string responseBody = apiResult.Content.ReadAsStringAsync().Result;
                var apiRes = JsonConvert.DeserializeObject<ApiResponse>(responseBody);
                response = apiRes;
            }
            return response;
        }
        public ApiResponse Post(ApiRequest request)
        {
            var response = new ApiResponse();
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    //Serilize to Json to Send
                    var jsonData = JsonConvert.SerializeObject(request.Dates);
                    HttpContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                    //DeSerilize Data (Json)
                    var apiResult = client.PostAsync(request.URL, content).Result;
                    string responseBody = apiResult.Content.ReadAsStringAsync().Result;

                    var apiRes = JsonConvert.DeserializeObject<ApiResponse>(responseBody);
                    response = apiRes;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }
    }
}
