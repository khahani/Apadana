using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Apadana.Entities.StaticObjects
{
    public class GenderType : ITypeObject
    {
        public const int GetMaximumId = 3;
        public const int GetMinimumId = 1;
        private static readonly GenderType instance = new GenderType();

        static GenderType()
        {
        }

        private GenderType()
        {
            if (GetMaximumId != Objects.Last().Id)
                throw new Exception(this.GetType().Name + " GetMaximumId is wrong");
            if (GetMinimumId != Objects.First().Id)
                throw new Exception(this.GetType().Name + " GetMinimumId is wrong");
        }
        public static GenderType Instance
        {
            get { return instance; }
        }

        public List<TypeObject> Objects
        {
            get
            {
                SimpleTypeObject[] list = new SimpleTypeObject[]
                {
                    new SimpleTypeObject {Id = 1, Value = "آقا" },
                    new SimpleTypeObject {Id = 2, Value = "خانم" },
                    new SimpleTypeObject {Id = 3, Value = "مهم نیست" }
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