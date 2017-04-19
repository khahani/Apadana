using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Apadana.Entities.StaticObjects
{
    public class MaritalStatusType : ITypeObject
    {
        public const int GetMaximumId = 3;
        public  const int GetMinimumId = 1;
        private static readonly MaritalStatusType instance = new MaritalStatusType();

        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static MaritalStatusType()
        {
        }

        private MaritalStatusType()
        {
            if (GetMaximumId != Objects.Last().Id)
                throw new Exception(this.GetType().Name + " GetMaximumId is wrong");
            if (GetMinimumId != Objects.First().Id)
                throw new Exception(this.GetType().Name + " GetMinimumId is wrong");
        }

        public static MaritalStatusType Instance
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
                    new SimpleTypeObject {Id = 1, Value = "مجرد" },
                    new SimpleTypeObject {Id = 2, Value = "متاهل" },
                    new SimpleTypeObject {Id = 3, Value = "مهم نیست" }
                };

                List<TypeObject> objects = new List<TypeObject>();

                objects.AddRange(list);

                return objects;
            }
        }
    }
}