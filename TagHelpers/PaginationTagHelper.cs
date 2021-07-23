using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using WebShop.Models;

namespace WebShop.TagHelpers
{
    [HtmlTargetElement("div", Attributes = "current-page, total-pages, path-value")]
    public class PaginationTagHelper : TagHelper
    {
        public ModelExpression CurrentPage { get; set; }
        public ModelExpression TotalPages { get; set; }
        public object PathValue { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";

            TagBuilder navPag = new TagBuilder("nav");
            navPag.Attributes["aria-label"] = "...";

            TagBuilder list = new TagBuilder("ul");
            list.Attributes["class"] = "pagination pagination-sm";

            for(int i = 1; i <= (int)TotalPages.Model; i++)
            {
                TagBuilder listElement = new TagBuilder("li");

                TagBuilder anchor = new TagBuilder("a");
                anchor.Attributes["href"] = (PathValue as int?) <= -1
                                            ? $"/Page/{i}"
                                            : $"/Page/{i}/{PathValue}";
                anchor.Attributes["class"] = "page-link";
                anchor.InnerHtml.Append($"{i}");
                if((int)CurrentPage.Model == i)
                {
                    listElement.Attributes["class"] = "page-item active";
                    listElement.Attributes["aria-current"] = "page";
                }
                else
                {
                    listElement.Attributes["class"] = "page-item";
                }
                listElement.InnerHtml.AppendHtml(anchor);
                list.InnerHtml.AppendHtml(listElement);
            }
            navPag.InnerHtml.AppendHtml(list);
            output.Content.SetHtmlContent(navPag);
        }
    }
}
