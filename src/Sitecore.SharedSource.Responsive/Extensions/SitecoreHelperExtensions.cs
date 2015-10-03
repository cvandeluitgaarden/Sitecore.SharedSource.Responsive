namespace Sitecore.SharedSource.Responsive.Extensions
{
    using Mvc.Helpers;
    using System.Web;
    using System.Linq;
    using System.Collections.Generic;
    using System.Web.Mvc;

    public static class SitecoreHelperExtensions
    {
        public static HtmlString ResponsiveClasses(this SitecoreHelper sitecoreHelper)
        {
            return RenderingHelper.ResponsiveClasses(sitecoreHelper.CurrentRendering);
        }

        public static HtmlString EditorLabel(this SitecoreHelper sitecoreHelper, string name)
        {
            HtmlString label;
            if (Sitecore.Context.PageMode.IsPageEditor)
            {
                var tag = new TagBuilder("span");
                tag.AddCssClass("label");
                tag.SetInnerText(name);
                label = new HtmlString(tag.ToString());
            }
            else
            {
                label = new HtmlString(string.Empty);
            }

            return label;
        }

        public static HtmlString EditorLabel(this SitecoreHelper sitecoreHelper)
        {
            return sitecoreHelper.EditorLabel(sitecoreHelper.CurrentRendering.RenderingItem.DisplayName);
        }
    }
}