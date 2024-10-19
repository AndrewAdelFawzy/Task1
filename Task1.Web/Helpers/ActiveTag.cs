using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Task1.Web.Helpers
{
    [HtmlTargetElement("a", Attributes = "active-when")]
    public class ActiveTag : TagHelper
    {
        public string? ActiveWhen { get; set; }

        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext? ViewContextData { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (string.IsNullOrEmpty(ActiveWhen) || ViewContextData == null)
                return;

            // Retrieve the current page's full path including folders
            var currentPage = ViewContextData.RouteData.Values["page"]?.ToString() ?? string.Empty;

            // Check if current page starts with ActiveWhen (for folder matching)
            if (currentPage.StartsWith(ActiveWhen, StringComparison.OrdinalIgnoreCase))
            {
                if (output.Attributes.ContainsName("class"))
                {
                    // Append 'active' class if other classes exist
                    output.Attributes.SetAttribute("class", $"{output.Attributes["class"].Value} active");
                }
                else
                {
                    // Set 'active' class if no other class exists
                    output.Attributes.SetAttribute("class", "active");
                }
            }
        }
    }
}

