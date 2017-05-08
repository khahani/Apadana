using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Apadana.Entities.StaticObjects
{
    public class YesOrNoType : ITypeObject
    {
        public const int GetMaximumId = 2;
        public const int GetMinimumId = 1;
        private static readonly YesOrNoType instance = new YesOrNoType();

        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static YesOrNoType()
        {
        }

        private YesOrNoType()
        {
            if (GetMaximumId != Objects.Last().Id)
                throw new Exception(this.GetType().Name + " GetMaximumId is wrong");
            if (GetMinimumId != Objects.First().Id)
                throw new Exception(this.GetType().Name + " GetMinimumId is wrong");
        }

        public static YesOrNoType Instance
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
                    new SimpleTypeObject {Id = 1, Value = "بله" },
                    new SimpleTypeObject {Id = 2, Value = "خیر" }
                };

                List<TypeObject> objects = new List<TypeObject>();

                objects.AddRange(list);

                return objects;
            }
        }
    }
}