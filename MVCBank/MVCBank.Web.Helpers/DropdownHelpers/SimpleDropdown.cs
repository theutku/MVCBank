using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace MVCBank.Web.Helpers
{
    public static class SimpleDropdown
    {
        public static MvcHtmlString AccountTypesDropdown(this HtmlHelper html, string propertyName, IEnumerable<SelectListItem> items)
        {
            return html.DropDownList(propertyName, items, "Select Account", new { @class = "form-control" });
        }
    }
}
