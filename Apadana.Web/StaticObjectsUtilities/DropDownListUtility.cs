using Apadana.Web.Models.StaticObjects;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Apadana.Web.StaticObjectsUtilities
{
    public static class DropDownListUtility
    {
        public static IEnumerable<SelectListItem> GetStaticObjectDropDown(object selectedValue, ITypeObject objects)
        {
            var result = new List<SelectListItem>();

            foreach (var item in objects.Objects)
            {
                result.Add(new SelectListItem { Text = item.Value, Value = item.Id.ToString(), Selected = item.Id.ToString() == selectedValue.ToString() });
            }

            return result;
        }
    }
}