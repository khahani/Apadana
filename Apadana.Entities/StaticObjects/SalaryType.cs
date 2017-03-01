using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Apadana.Entities.StaticObjects
{
    public class SalaryType : ITypeObject
    {
        private static readonly SalaryType instance = new SalaryType();
        static SalaryType() { }
        private SalaryType() { }
        public static SalaryType Instance { get { return instance; } }

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
                    new SimpleTypeObject { Id = 5, Value = "روزمزد" },
                    new SimpleTypeObject { Id = 5, Value = "توافقی" }
                };

                List<TypeObject> objects = new List<TypeObject>();

                objects.AddRange(list);

                return objects;
            }
        }
    }
}