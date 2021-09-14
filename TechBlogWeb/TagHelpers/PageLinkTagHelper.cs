using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Collections.Generic;
using TechBlogWeb.Models;

namespace TechBlogWeb.TagHelpers
{
    [HtmlTargetElement("ul", Attributes = "page-model")]
    public class PageLinkTagHelper : TagHelper
    {
        private readonly IUrlHelperFactory urlHelperFactory;

        public PageLinkTagHelper(IUrlHelperFactory urlHelperFactory)
        {
            this.urlHelperFactory = urlHelperFactory;
        }

        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }

        public PageInfo PageModel { get; set; }

        public string PageAction { get; set; }

        [HtmlAttributeNotBound]
        public Dictionary<string, object> PageUrlValues { get; set; }
            = new Dictionary<string, object>();

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var urlHelper = urlHelperFactory.GetUrlHelper(ViewContext);
            var result = new TagBuilder("ul");
            for (int i = 1; i <= PageModel.TotalPages; i++)
            {
                if (i > 10)
                    i = PageModel.TotalPages;

                var tag_li = new TagBuilder("li");
                tag_li.AddCssClass("page-item");

                var tag_a = new TagBuilder("a");
                PageUrlValues["articlePage"] = i;
                tag_a.Attributes["href"] = urlHelper.Action(PageAction, PageUrlValues);
                tag_a.AddCssClass("page-link");
                tag_a.InnerHtml.Append(i.ToString());

                tag_li.InnerHtml.AppendHtml(tag_a);
                result.InnerHtml.AppendHtml(tag_li);
            }

            output.Content.AppendHtml(result.InnerHtml);
        }
    }
}