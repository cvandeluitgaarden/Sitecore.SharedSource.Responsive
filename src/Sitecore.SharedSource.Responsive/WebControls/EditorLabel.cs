namespace Sitecore.SharedSource.Responsive.WebControls
{
    using Web.UI.WebControls;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public class EditorLabel : WebControl
    {
        public Control Control { get; set; }

        public string Value { get; set; }

        protected override void RenderContents(HtmlTextWriter writer)
        {
            if (this.Control == null || !string.IsNullOrWhiteSpace(this.Value))
            {
                writer.Write(this.Value);
            }
            else
            {
                var sublayout = this.Control.Parent as Sublayout;
                var rendering = RenderingHelper.GetRenderingItem(sublayout);
                writer.Write(rendering.RenderingItem.DisplayName);
            }

            base.RenderContents(writer);
        }

        public EditorLabel() : base(HtmlTextWriterTag.Span)
        {
        }

        protected override void AddAttributesToRender(HtmlTextWriter writer)
        {
            writer.AddAttribute(HtmlTextWriterAttribute.Class, "label");
            base.AddAttributesToRender(writer);
        }
    }
}