using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Apadana.Web.Models.StaticObjects
{
    public class EducationType : ITypeObject
    {
        private static readonly EducationType instance = new EducationType();

        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static EducationType()
        {
        }

        private EducationType()
        {
        }

        public static EducationType Instance
        {
            get
            {
                return instance;
            }
        }
        public List<TypeObject> Objects
        {
            get
            {
                SimpleTypeObject[] list = new SimpleTypeObject[]
                {
                    new SimpleTypeObject {Id = 1, Value = "ابتدایی" },
                    new SimpleTypeObject {Id = 2, Value = "راهنمایی" },
                    new SimpleTypeObject {Id = 3, Value = "دیپلم" },
                    new SimpleTypeObject {Id = 4, Value = "کاردانی" },
                    new SimpleTypeObject {Id = 5, Value = "کارشناسی" },
                    new SimpleTypeObject {Id = 6, Value = "کارشناسی ارشد" },
                    new SimpleTypeObject {Id = 7, Value = "دکتری و بالاتر" }
                };

                List<TypeObject> objects = new List<TypeObject>();

                objects.AddRange(list);

                return objects;
            }
        }
    }
}