using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Apadana.Web.Models.StaticObjects
{
    public class ProvinceType : ITypeObject
    {
        private static readonly ProvinceType instance = new ProvinceType();

        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static ProvinceType()
        {
        }

        private ProvinceType()
        {
        }

        public static ProvinceType Instance
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
                    new SimpleTypeObject {Id = 1, Value = "آذربایجان شرقی" },
                    new SimpleTypeObject {Id = 2, Value = "آذربایجان غربی" },
                    new SimpleTypeObject {Id = 3, Value = "اردبیل" },
                    new SimpleTypeObject {Id = 4, Value = "اصفهان" },
                    new SimpleTypeObject {Id = 5, Value = "البرز" },
                    new SimpleTypeObject {Id = 6, Value = "ایلام" },
                    new SimpleTypeObject {Id = 7, Value = "بوشهر" },
                    new SimpleTypeObject {Id = 8, Value = "تهران" },
                    new SimpleTypeObject {Id = 9, Value = "چهارمحال و بختیاری" },
                    new SimpleTypeObject {Id = 10, Value = "خراسان جنوبی" },
                    new SimpleTypeObject {Id = 11, Value = "خراسان رضوی" },
                    new SimpleTypeObject {Id = 12, Value = "خراسان شمالی" },
                    new SimpleTypeObject {Id = 13, Value = "خوزستان" },
                    new SimpleTypeObject {Id = 14, Value = "زنجان" },
                    new SimpleTypeObject {Id = 15, Value = "سمنان" },
                    new SimpleTypeObject {Id = 16, Value = "سیستان و بلوچستان" },
                    new SimpleTypeObject {Id = 17, Value = "فارس" },
                    new SimpleTypeObject {Id = 18, Value = "قزوین" },
                    new SimpleTypeObject {Id = 19, Value = "قم" },
                    new SimpleTypeObject {Id = 20, Value = "کردستان" },
                    new SimpleTypeObject {Id = 21, Value = "کرمان" },
                    new SimpleTypeObject {Id = 22, Value = "کرمانشاه" },
                    new SimpleTypeObject {Id = 23, Value = "کهگیلویه و بویراحمد" },
                    new SimpleTypeObject {Id = 24, Value = "گلستان" },
                    new SimpleTypeObject {Id = 25, Value = "گیلان" },
                    new SimpleTypeObject {Id = 26, Value = "لرستان" },
                    new SimpleTypeObject {Id = 27, Value = "مازندران" },
                    new SimpleTypeObject {Id = 28, Value = "مرکزی" },
                    new SimpleTypeObject {Id = 29, Value = "هرمزگان" },
                    new SimpleTypeObject {Id = 30, Value = "همدان" },
                    new SimpleTypeObject {Id = 31, Value = "یزد" }
                };

                List<TypeObject> objects = new List<TypeObject>();

                objects.AddRange(list);

                return objects;
            }
        }
    }
}