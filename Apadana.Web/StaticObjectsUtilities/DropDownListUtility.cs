using Apadana.Entities.StaticObjects;
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
                SelectListItem selectListItem = new SelectListItem { Text = item.Value, Value = item.Id.ToString() };

                if (selectedValue != null)
                    selectListItem.Selected = item.Id.ToString() == selectedValue.ToString();

                result.Add(selectListItem);
            }

            return result;
        }
    }
}