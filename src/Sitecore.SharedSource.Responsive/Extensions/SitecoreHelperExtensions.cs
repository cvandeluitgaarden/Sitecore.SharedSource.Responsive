namespace Sitecore.SharedSource.Responsive.Extensions
{
    using Mvc.Helpers;
    using Data.Fields;
    using System.Web;
    using Mvc.Presentation;
    using System.Linq;
    using System;
    using System.Collections.Generic;
    using Data.Items;
    using System.Web.Mvc;

    public static class SitecoreHelperExtensions
    {
        public static HtmlString ResponsiveClasses(this SitecoreHelper sitecoreHelper)
        {
            List<string> classes = new List<string>();
            var renderingParameter = sitecoreHelper.CurrentRendering.Parameters;
            var fieldNames = GetRenderingResponsiveFieldNames(sitecoreHelper.CurrentRendering);

            foreach(var fieldName in fieldNames)
            {
                if(sitecoreHelper.CurrentRendering.Parameters.Contains(fieldName))
                {
                    classes.Add(sitecoreHelper.CurrentRendering.Parameters[fieldName]);
                }
            }

            return new HtmlString(string.Join(" ", classes.Where(c => !string.IsNullOrWhiteSpace(c))));
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

        private static IEnumerable<string> GetRenderingResponsiveFieldNames(Rendering currentRendering)
        {
            IEnumerable<string> fields = new string[] { };

            Item renderingItem = Sitecore.Context.Database.GetItem(currentRendering.RenderingItem.ID);

            ReferenceField parameterTemplateField = renderingItem.Fields[AppConstants.ParameterTemplateName];
            if (parameterTemplateField != null && parameterTemplateField.TargetItem != null)
            {
                var templateItem = Context.Database.GetTemplate(parameterTemplateField.TargetID);

                fields = templateItem.Fields.Where(field => AppConstants.ResponsiveSectionNames
                    .Contains(field.Section.Name, StringComparer.OrdinalIgnoreCase))
                    .Select(x => x.Name);
            }

            return fields;
        }
    }
}