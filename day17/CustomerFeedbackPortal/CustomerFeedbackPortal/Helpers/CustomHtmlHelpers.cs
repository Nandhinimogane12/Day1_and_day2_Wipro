namespace CustomerFeedbackPortal.Helpers
{
    using Microsoft.AspNetCore.Html;
    using Microsoft.AspNetCore.Mvc.Rendering;

    public static class CustomHtmlHelpers
    {
        public static IHtmlContent StyledTextBox(this IHtmlHelper htmlHelper,
            string name, string placeholder, string cssClass = "form-control")
        {
            var tagBuilder = new TagBuilder("input");
            tagBuilder.Attributes.Add("name", name);
            tagBuilder.Attributes.Add("id", name);
            tagBuilder.Attributes.Add("type", "text");
            tagBuilder.Attributes.Add("placeholder", placeholder);
            tagBuilder.Attributes.Add("class", cssClass);
            return tagBuilder;
        }
    }
}