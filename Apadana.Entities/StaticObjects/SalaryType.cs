using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Apadana.Entities.StaticObjects
{
    public class SalaryType : ITypeObject
    {
        public const int GetMaximumId = 7;
        public const int GetMinimumId = 1;
        private static readonly SalaryType instance = new SalaryType();
        static SalaryType() { }
        private SalaryType()
        {
            if (GetMaximumId != Objects.Last().Id)
                throw new Exception(this.GetType().Name + " GetMaximumId is wrong");
            if (GetMinimumId != Objects.First().Id)
                throw new Exception(this.GetType().Name + " GetMinimumId is wrong");
        }
        public static SalaryType Instance { get { return instance; } }


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
                    new SimpleTypeObject {Id = 1, Value = "کمتر از قانون کار" },
                    new SimpleTypeObject {Id = 2, Value = "پایه قانون کار" },
                    new SimpleTypeObject {Id = 3, Value = "قانون کار با مزایا" },
                    new SimpleTypeObject { Id = 4, Value = "پروژه ای" },
                    new SimpleTypeObject { Id = 5, Value = "ساعتی" },
                    new SimpleTypeObject { Id = 6, Value = "روزمزد" },
                    new SimpleTypeObject { Id = 7, Value = "توافقی" }
                };

                List<TypeObject> objects = new List<TypeObject>();

                objects.AddRange(list);

                return objects;
            }
        }
    }
}