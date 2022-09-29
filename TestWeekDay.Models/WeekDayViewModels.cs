using System;
using System.Collections.Generic;

namespace TestWeekDay.Models
{
    //API Models
    public class ApiRequest 
    {
        public string URL { get; set; }
        public string Param1 { get; set; }
        public List<string> Dates { get; set; }
    }
    public class ApiResponse 
    {
        public bool IsValid { get; set; }
        public List<string> Errors { get; set; }
        public List<WeekDay> Result { get; set; }
    }



    //ServiceModels
    public class WeekDayServiceRequest
    {
        public string Param1 { get; set; }
        public List<string> Dates {get;set;}
    }
    public class WeekDayServiceResponse
    {
        public List<WeekDay> Days { get; set; }
    }
    public class WeekDay
    {
        public int Index { get; set; }
        public string SummaryText { get; set; }
        public string CurrentDate { get; set; }
        public string CurrentTime { get; set; }
        public string CurrentTime1 { get; set; }
        public string CurrentTime2 { get; set; }
        public string CurrentTime3 { get; set; }
        public string CurrentTime4 { get; set; }
        public string CurrentTime5 { get; set; }
        public string CurrentTime6 { get; set; }
    }
}
