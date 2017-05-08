using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Apadana.Entities.StaticObjects
{
    public class MaximumAgeType : ITypeObject
    {
        public const int GetMaximumId = 5;
        public const int GetMinimumId = 1;
        private static readonly MaximumAgeType instance = new MaximumAgeType();

        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static MaximumAgeType()
        {
        }

        private MaximumAgeType()
        {
            if (GetMaximumId != Objects.Last().Id)
                throw new Exception(this.GetType().Name + " GetMaximumId is wrong");
            if (GetMinimumId != Objects.First().Id)
                throw new Exception(this.GetType().Name + " GetMinimumId is wrong");
        }

        public static MaximumAgeType Instance
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
                    new SimpleTypeObject {Id = 1, Value = "بین 20 تا 25" },
                    new SimpleTypeObject {Id = 2, Value = "بین 25 تا 30" },
                    new SimpleTypeObject {Id = 3, Value = "بین 30 تا 35" },
                    new SimpleTypeObject { Id= 4 , Value = "بین 35 تا 40" },
                    new SimpleTypeObject { Id= 5 , Value = "مهم نیست" }
               };

                List<TypeObject> objects = new List<TypeObject>();

                objects.AddRange(list);

                return objects;
            }
        }
    }
}