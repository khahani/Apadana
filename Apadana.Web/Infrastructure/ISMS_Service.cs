using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Apadana.Web.Infrastructure
{
    public interface ISMS_Service
    {
        Task<bool> SendAsync(string number, string messageFormat, params string[] parameters);
    }
}