using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Apadana.Web.Models.StaticObjects
{
    public class Education : ITypeObject
    {
        private List<TypeObject> _Objects;
        public List<TypeObject> Objects
        {
            get
            {
                return _Objects;
            }

            set
            {
                _Objects = value;
            }
        }

        public Education()
        {
            SimpleTypeObject[] list = new SimpleTypeObject[]
            {
                new SimpleTypeObject {Id = 1, Value = "بی سواد" },
                new SimpleTypeObject {Id = 1, Value = "بی سواد" }
            };

            Objects = new List<TypeObject>();
            Objects.AddRange(list);
        }
    }
}