using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Apadana.Entities.StaticObjects
{
    public class GenderType : ITypeObject
    {
        private static readonly GenderType instance = new GenderType();

        static GenderType()
        {
        }

        private GenderType()
        {
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
    }
}