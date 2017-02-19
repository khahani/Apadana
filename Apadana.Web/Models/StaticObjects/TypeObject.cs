using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Apadana.Web.Models.StaticObjects
{
    public abstract class TypeObject
    {
        public int Id { get; set; }
        public string Value { get; set; }
    }
}