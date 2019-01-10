using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnitTestSample.Core.Modal;
using Utilities.Interfaces;
using System.Net;
using System.IO;

namespace UnitTestSample.Core.Helper
{
    public class WebServiceHandler : IWebserviceHandler
    {
        public async Task<object> GetWeatherDetails(double latitude, double longitude)
        {
            var httpRequest = HttpWebRequest.Create($"http://api.openweathermap.org/data/2.5/forecast?lat={latitude}&lon={longitude}&AppId=<yourappid>");
            httpRequest.ContentType = "application/json";
            httpRequest.Method = "GET";
            HttpWebResponse response = await httpRequest.GetResponseAsync() as HttpWebResponse;
            if(response.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception("Error in API Call"); 
            }
            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
                var content = await reader.ReadToEndAsync();
                var returnObject= Newtonsoft.Json.JsonConvert.DeserializeObject<WeatherObject>(content);
                if (string.IsNullOrWhiteSpace(content))
                {
                    Console.Out.WriteLine("Response contained empty body...");
                }
                else
                {
                    Console.Out.WriteLine("Response Body: \r\n {0}", content);
                }
                return returnObject;
            }
        }
    }
}
