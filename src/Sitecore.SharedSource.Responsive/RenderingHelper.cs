namespace Sitecore.SharedSource.Responsive
{
    using Sitecore.Data.Fields;
    using Web.UI.WebControls;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.UI;
    using Data;
    using System.Web;

    public static class RenderingHelper
    {
        public static string ResponsiveClasses(Control control)
        {
            var sublayout = control.Parent as Sublayout;
            var renderings = Sitecore.Context.Item.Visualization.GetRenderings(Sitecore.Context.Device, true);
            var rendering = renderings.FirstOrDefault(r => r.RenderingItem.InnerItem["Path"] == sublayout.Path);
            return ResponsiveClasses(sublayout.ParametersDictionary, rendering.RenderingID);
        }

        public static HtmlString ResponsiveClasses(Sitecore.Mvc.Presentation.Rendering rendering)
        {
            var config = new Configuration();

            return new HtmlString(ResponsiveClasses(rendering.Parameters, rendering.RenderingItem.ID));
        }

        public static string ResponsiveClasses(IEnumerable<KeyValuePair<string,string>> parameters, ID renderingId)
        {
            List<string> classes = new List<string>();
            foreach (string parameterKey in GetRenderingResponsiveFieldNames(renderingId))
            {
                string value = parameters.Where(parameter => parameter.Key.Equals(parameterKey))
                    .Select(parameter => parameter.Value).FirstOrDefault();

                if (!string.IsNullOrWhiteSpace(value))
                {
                    classes.Add(value);
                }
            }

            return string.Join(" ", classes);
        }

        public static IEnumerable<string> GetRenderingResponsiveFieldNames(ID renderingId)
        {
            var renderingItem = Context.Database.GetItem(renderingId);
            ReferenceField renderingParameterTemplate = renderingItem.Fields[AppConstants.ParametersTemplateFieldName];
            if(renderingParameterTemplate == null || renderingParameterTemplate.TargetItem == null)
            {
                return new string[] { };
            }

            var config = new Configuration();
            var templateItem = Context.Database.GetTemplate(renderingParameterTemplate.TargetID);
            return templateItem.Fields
                .Where(field => config.Fields.Contains(field.ID))
                .Select(field => field.Name);
        }
    }
}