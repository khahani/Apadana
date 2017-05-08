﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Apadana.Entities.StaticObjects
{
    public class RelatedWorkExperienceType : ITypeObject
    {
        private static readonly RelatedWorkExperienceType instance = new RelatedWorkExperienceType();

        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static RelatedWorkExperienceType()
        {
        }

        private RelatedWorkExperienceType()
        {
        }

        public static RelatedWorkExperienceType Instance
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
                    new SimpleTypeObject {Id = 1, Value = "داشته باشد" },
                    new SimpleTypeObject {Id = 2, Value = "نداشته باشد" },
                    new SimpleTypeObject {Id = 3, Value = "مهم نیست" }
               };

                List<TypeObject> objects = new List<TypeObject>();

                objects.AddRange(list);

                return objects;
            }
        }
    }
}