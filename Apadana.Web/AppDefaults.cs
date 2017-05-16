using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Apadana.Web
{
    public static class AppDefaults
    {
        public const string ROLE_EMPLOYER = "کارفرما";
        public const string ROLE_ADMIN = "مدیر سایت";
        public const string ROLE_PERSONEL = "پرسنل";
        public const string ROLE_JOBSEEKER = "کارجو";
        public const string ROLE_COLLEAGUE = "کاریابی همکار";

        public const string AREA_ADMIN = "admin";
        public const string AREA_EMPLOYER = "employer";
        public const string AREA_PERSONEL = "personel";
        public const string AREA_JOBSEEKER = "jobseeker";
        public const string AREA_COLLEAGUE = "colleague";

        public const string SESSION_SELECTED_EMPLOYER = "SelectedEmployer";
    }
}