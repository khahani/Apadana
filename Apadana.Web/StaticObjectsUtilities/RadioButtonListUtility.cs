using Apadana.Entities.StaticObjects;
using System.Text;
using System.Web.Mvc;

namespace Apadana.Web.StaticObjectsUtilities
{
    public static class RadioButtonListUtility
    {
        public static MvcHtmlString RadioButtonListVerticalForStaticTypes(this HtmlHelper helper, string groupName, ITypeObject theType, object selectedValue)
        {
       
            StringBuilder radioButtonList = new StringBuilder();

            foreach (var item in theType.Objects)
            {
                radioButtonList.Append("<div class=\"radio\">");
                radioButtonList.Append("<label>");
                radioButtonList.Append(string.Format(" <input type=\"radio\"", groupName, item.Id));
                radioButtonList.Append(string.Format(" name=\"{0}\"", groupName));
                radioButtonList.Append(string.Format(" id=\"{0}\"", groupName + "-" + item.Id));
                radioButtonList.Append(string.Format(" value=\"{0}\"", item.Id));
                radioButtonList.Append(item.Id.ToString() == selectedValue.ToString() ? " checked=\"checked\"" : string.Empty);
                radioButtonList.Append(" >");
                radioButtonList.Append(" " + item.Value);
                radioButtonList.Append("</label>");
                radioButtonList.Append("</div>");
            }
            
            MvcHtmlString result = new MvcHtmlString(radioButtonList.ToString());

            return result;
        }

        public static MvcHtmlString RadioButtonListHorizontalForStaticTypes(this HtmlHelper helper, string groupName, ITypeObject theType, object selectedValue)
        {

            StringBuilder radioButtonList = new StringBuilder();

            foreach (var item in theType.Objects)
            {
                radioButtonList.Append("<label class=\"radio-inline\">");
                radioButtonList.Append(string.Format(" <input type=\"radio\"", groupName, item.Id));
                radioButtonList.Append(string.Format(" name=\"{0}\"", groupName));
                radioButtonList.Append(string.Format(" id=\"{0}\"", groupName + "-" + item.Id));
                radioButtonList.Append(string.Format(" value=\"{0}\"", item.Id));
                radioButtonList.Append(item.Id.ToString() == selectedValue.ToString() ? " checked=\"checked\"" : string.Empty);
                radioButtonList.Append(" >");
                radioButtonList.Append(" " + item.Value);
                radioButtonList.Append("</label>");
            }

            MvcHtmlString result = new MvcHtmlString(radioButtonList.ToString());

            return result;
        }
    }
}