using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apadana.Entities.StaticObjects
{
    public class UniversityType : ITypeObject
    {
        private static readonly UniversityType instance = new UniversityType();

        public const int GetMinimumId = 1;
        public const int GetMaximumId = 5;

        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static UniversityType()
        {
        }

        private UniversityType()
        {
            if (GetMaximumId != Objects.Last().Id)
                throw new Exception(this.GetType().Name + " GetMaximumId is wrong");
            if (GetMinimumId != Objects.First().Id)
                throw new Exception(this.GetType().Name + " GetMinimumId is wrong");
        }

        public static UniversityType Instance
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
                    new SimpleTypeObject {Id = 1, Value = "دولتی" },
                    new SimpleTypeObject {Id = 2, Value = "آزاد" },
                    new SimpleTypeObject {Id = 3, Value = "غیر انتفاعی" },
                    new SimpleTypeObject {Id = 4, Value = "علمی کاربردی" },
                    new SimpleTypeObject {Id = 5, Value = "بین المللی" }
                };

                List<TypeObject> objects = new List<TypeObject>();

                objects.AddRange(list);

                return objects;
            }
        }

        public TypeObject Get(int id)
        {
            return Instance.Objects.FirstOrDefault(m => m.Id == id);
        }
    }
}
