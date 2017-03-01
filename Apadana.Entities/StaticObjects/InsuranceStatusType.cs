using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Apadana.Entities.StaticObjects
{
    public class InsuranceStatusType : ITypeObject
    {
        private static readonly InsuranceStatusType instance = new InsuranceStatusType();
        static InsuranceStatusType() { }
        private InsuranceStatusType() { }
        public static InsuranceStatusType Instance { get { return instance; } }

        public List<TypeObject> Objects
        {
            get
            {
                SimpleTypeObject[] list = new SimpleTypeObject[]
                {
                    new SimpleTypeObject {Id = 1, Value = "دارد" },
                    new SimpleTypeObject {Id = 2, Value = "ندارد" },
                    new SimpleTypeObject {Id = 3, Value = "پس از دوره آموزشی" }
                };

                List<TypeObject> objects = new List<TypeObject>();

                objects.AddRange(list);

                return objects;
            }
        }
    }
}