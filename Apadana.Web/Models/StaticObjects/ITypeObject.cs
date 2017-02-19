using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Apadana.Web.Models.StaticObjects
{
    public interface ITypeObject
    {
        List<TypeObject> Objects { get; set; }
    }
}