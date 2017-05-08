using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Apadana.Web.Infrastructure
{
    public class SMS_Service_Demo : ISMS_Service
    {
        public Task<bool> SendAsync(string number, string message)
        {
            string messages = message;
            try
            {
                //Send sms...
                return Task.FromResult(true);
            }
            catch (Exception ex)
            {
                return Task.FromResult(false);
            }
        }

        public async Task<bool> SendAsync(string number, string messageFormat, params string[] parameters)
        {
            string message = string.Format(messageFormat, parameters);
            try
            {
                //Send sms...
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}