using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Serialization;

namespace Apadana.Web.Infrastructure
{
    public class Ghasedak_SMS_Service : ISMS_Service
    {
        public Task<bool> SendAsync(string number, string messageFormat, params string[] parameters)
        {
            try
            {
                var client = new RestClient(" http://api.smsapp.ir/v2/sms/send/simple ");
                var request = new RestRequest(Method.POST);
                request.AddHeader("apikey", "RAF8QVrvs0gJnouCpg6rTBBrUFMZDcqDn++IiZUlnu0");
                request.AddParameter("senddate", "unixtime");
                request.AddParameter("receptor", number);
                request.AddParameter("message", string.Format(messageFormat, parameters));
                request.AddParameter("sender", "30005006001071");
                request.AddParameter("output", "Json/xml");
                IRestResponse response = client.Execute(request);

                //JavaScriptSerializer json_serializer = new JavaScriptSerializer();
                //ServiceResult result =
                //       (ServiceResult)json_serializer.DeserializeObject(response.Content);

                ServiceResult result = JsonConvert.DeserializeObject<ServiceResult>(response.Content);
                return Task.FromResult(result.result == "success");
            }
            catch (Exception ex)
            {
                return Task.FromResult(false);
            }
        }

        public class ServiceResult
        {
            public string result { get; set; }
            public int messageids { get; set; }
        }
    }
}