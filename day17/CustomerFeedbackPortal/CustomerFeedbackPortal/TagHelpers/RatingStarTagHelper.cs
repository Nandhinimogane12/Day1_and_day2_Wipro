namespace CustomerFeedbackPortal.TagHelpers
{
    using Microsoft.AspNetCore.Razor.TagHelpers;

    [HtmlTargetElement("rating-star")]
    public class RatingStarTagHelper : TagHelper
    {
        public int Rating { get; set; }
        public int MaxRating { get; set; } = 5;

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.Attributes.SetAttribute("class", "rating-stars");

            var content = "";
            for (int i = 1; i <= MaxRating; i++)
            {
                content += i <= Rating
                   ? "<span class='star filled'>★</span>"
                    : "<span class='star'>☆</span>";
            }
            output.Content.SetHtmlContent(content);
        }
    }
}