using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Apadana.Entities.StaticObjects
{
    public class MilitaryStatusType : ITypeObject
    {
        public const int GetMaximumId = 5;
        public  const int GetMinimumId = 1;
        private static readonly MilitaryStatusType instance = new MilitaryStatusType();

        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static MilitaryStatusType()
        {
        }

        private MilitaryStatusType()
        {
            if (GetMaximumId != Objects.Last().Id)
                throw new Exception(this.GetType().Name + " GetMaximumId is wrong");
            if (GetMinimumId != Objects.First().Id)
                throw new Exception(this.GetType().Name + " GetMinimumId is wrong");
        }

        public static MilitaryStatusType Instance
        {
            get
            {
                return instance;
            }
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
                    new SimpleTypeObject {Id = 1, Value = "پایان خدمت" },
                    new SimpleTypeObject {Id = 2, Value = "معافیت پزشکی" },
                    new SimpleTypeObject {Id = 3, Value = "معافیت کفالت" },
                    new SimpleTypeObject {Id = 4, Value = "معافیت خاص" },
                    new SimpleTypeObject {Id = 5, Value = "خدمت نکرده" }
                };

                List<TypeObject> objects = new List<TypeObject>();

                objects.AddRange(list);

                return objects;
            }
        }
    }
}