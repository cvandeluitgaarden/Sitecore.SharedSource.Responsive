namespace Sitecore.SharedSource.Responsive.Extensions
{
    using Mvc.Helpers;
    using Data.Fields;
    using System.Web;
    using Mvc.Presentation;
    using System.Linq;
    using System;
    using System.Collections.Generic;

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

        private static IEnumerable<string> GetRenderingResponsiveFieldNames(Rendering currentRendering)
        {
            IEnumerable<string> fields = null;
            ReferenceField parameterTemplateField = currentRendering.Item.Fields[AppConstants.ParameterTemplateName];
            if (parameterTemplateField != null && parameterTemplateField.TargetItem != null)
            {
                var templateItem = Context.Database.GetTemplate(parameterTemplateField.TargetID);
                var sections = templateItem.GetSections()
                    .Where(section => AppConstants.ResponsiveSectionNames
                    .Contains(section.Name, StringComparer.OrdinalIgnoreCase));

                fields = sections.SelectMany(section => section.GetFields().Select(field => field.Name));
            }

            return fields;
        }
    }
}