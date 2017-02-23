﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Apadana.Web.Models.StaticObjects
{
    public class YesOrNoType : ITypeObject
    {
        private static readonly YesOrNoType instance = new YesOrNoType();

        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static YesOrNoType()
        {
        }

        private YesOrNoType()
        {
        }

        public static YesOrNoType Instance
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