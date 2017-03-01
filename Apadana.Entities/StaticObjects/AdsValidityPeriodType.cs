using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Apadana.Entities.StaticObjects
{
    public sealed class AdsValidityPeriodType : ITypeObject
    {
        private static readonly AdsValidityPeriodType instance = new AdsValidityPeriodType();

        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static AdsValidityPeriodType()
        {
        }

        private AdsValidityPeriodType()
        {
        }

        public static AdsValidityPeriodType Instance
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
                    new SimpleTypeObject {Id = 1, Value = "روز 1" },
                    new SimpleTypeObject {Id = 2, Value = "روز 2" },
                    new SimpleTypeObject {Id = 3, Value = "روز 3" },
                    new SimpleTypeObject {Id = 4, Value = "روز 4" },
                    new SimpleTypeObject {Id = 5, Value = "روز 5" },
                    new SimpleTypeObject {Id = 6, Value = "روز 6" },
                    new SimpleTypeObject {Id = 7, Value = "روز 7" },
                    new SimpleTypeObject {Id = 7, Value = "روز 8" },
                    new SimpleTypeObject {Id = 7, Value = "روز 9" },
                    new SimpleTypeObject {Id = 6, Value = "روز 10" },
                    new SimpleTypeObject {Id = 7, Value = "روز 11" },
                    new SimpleTypeObject {Id = 7, Value = "روز 12" },
                    new SimpleTypeObject {Id = 7, Value = "روز 13" },
                    new SimpleTypeObject {Id = 6, Value = "روز 14" },
                    new SimpleTypeObject {Id = 7, Value = "روز 15" },
                    new SimpleTypeObject {Id = 7, Value = "روز 16" },
                    new SimpleTypeObject {Id = 7, Value = "روز 17" },
                    new SimpleTypeObject {Id = 6, Value = "روز 18" },
                    new SimpleTypeObject {Id = 7, Value = "روز 19" },
                    new SimpleTypeObject {Id = 7, Value = "روز 20" },
                    new SimpleTypeObject {Id = 7, Value = "روز 21" },
                    new SimpleTypeObject {Id = 6, Value = "روز 22" },
                    new SimpleTypeObject {Id = 7, Value = "روز 23" },
                    new SimpleTypeObject {Id = 7, Value = "روز 24" },
                    new SimpleTypeObject {Id = 7, Value = "روز 25" },
                    new SimpleTypeObject {Id = 6, Value = "روز 26" },
                    new SimpleTypeObject {Id = 7, Value = "روز 27" },
                    new SimpleTypeObject {Id = 7, Value = "روز 28" },
                    new SimpleTypeObject {Id = 7, Value = "روز 29" },
                    new SimpleTypeObject {Id = 7, Value = "روز 30" }
               };

                List<TypeObject> objects = new List<TypeObject>();

                objects.AddRange(list);

                return objects;
            }
        }
    }
}