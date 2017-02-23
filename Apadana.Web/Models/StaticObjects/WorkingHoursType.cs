using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Apadana.Web.Models.StaticObjects
{
    public class WorkingHoursType : ITypeObject
    {
        private static readonly WorkingHoursType instance = new WorkingHoursType();
        static WorkingHoursType() { }
        private WorkingHoursType() { }
        public static WorkingHoursType Instance
        {
            get { return instance; }
        }

        public List<TypeObject> Objects
        {
            get
            {
                SimpleTypeObject[] list = new SimpleTypeObject[]
                {
                    new SimpleTypeObject {Id = 1, Value = "8 ساعت" },
                    new SimpleTypeObject {Id = 2, Value = "12 ساعت" },
                    new SimpleTypeObject {Id = 3, Value = "شیفتی" },
                    new SimpleTypeObject {Id = 4, Value = "مهم نیست" }
                };

                List<TypeObject> objects = new List<TypeObject>();

                objects.AddRange(list);

                return objects;
            }
        }
    }
}