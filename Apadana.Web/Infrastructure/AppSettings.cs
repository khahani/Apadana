using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Apadana.Web.Infrastructure
{
    public static class AppSettings
    {
        public static int PasswordLength
        {
            get
            {
                return int.Parse(System.Web.Configuration.WebConfigurationManager.AppSettings["PasswordLength"]);
            }
        }

        public static int NonAlphanumeric
        {
            get
            {
                return int.Parse(System.Web.Configuration.WebConfigurationManager.AppSettings["NonAlphanumeric"]);
            }

        }

        public static bool UserLockoutEnabledByDefault
        {
            get
            {
                return bool.Parse(System.Web.Configuration.WebConfigurationManager.AppSettings["UserLockoutEnabledByDefault"]);
            }
        }

        public static int MaxFailedAccessAttemptsBeforeLockout
        {
            get
            {
                return int.Parse(System.Web.Configuration.WebConfigurationManager.AppSettings["MaxFailedAccessAttemptsBeforeLockout"]);
            }
        }

        public static bool ContainNumber
        {
            get
            {
                return bool.Parse(System.Web.Configuration.WebConfigurationManager.AppSettings["ContainNumber"]);
            }
        }
        public static bool ContainAlphabet
        {
            get
            {
                return bool.Parse(System.Web.Configuration.WebConfigurationManager.AppSettings["ContainAlphabet"]);
            }
        }
        public static bool CaseSensitive
        {
            get
            {
                return bool.Parse(System.Web.Configuration.WebConfigurationManager.AppSettings["CaseSensitive"]);
            }
        }
    }
}