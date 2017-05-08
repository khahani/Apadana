using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Apadana.Entities.StaticObjects
{
    public class InsuranceStatusType : ITypeObject
    {
        public const int GetMaximumId = 3;
        public const int GetMinimumId = 1;
        private static readonly InsuranceStatusType instance = new InsuranceStatusType();
        static InsuranceStatusType() { }
        private InsuranceStatusType()
        {
            if (GetMaximumId != Objects.Last().Id)
                throw new Exception(this.GetType().Name + " GetMaximumId is wrong");
            if (GetMinimumId != Objects.First().Id)
                throw new Exception(this.GetType().Name + " GetMinimumId is wrong");
        }
        public static InsuranceStatusType Instance { get { return instance; } }

        public TypeObject Get(int id)
        {
            return Instance.Objects.FirstOrDefault(m => m.Id == id);
        }

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