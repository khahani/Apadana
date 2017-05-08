using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Apadana.Entities.StaticObjects
{
    public class WorkingHoursType : ITypeObject
    {
        public const int GetMaximumId = 4;
        public const int GetMinimumId = 1;
        private static readonly WorkingHoursType instance = new WorkingHoursType();
        static WorkingHoursType() { }
        private WorkingHoursType()
        {
            if (GetMaximumId != Objects.Last().Id)
                throw new Exception(this.GetType().Name + " GetMaximumId is wrong");
            if (GetMinimumId != Objects.First().Id)
                throw new Exception(this.GetType().Name + " GetMinimumId is wrong");
        }
        public static WorkingHoursType Instance
        {
            get { return instance; }
        }

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