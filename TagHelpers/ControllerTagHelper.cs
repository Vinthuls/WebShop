using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace WebShop.TagHelpers
{
    [HtmlTargetElement("th", Attributes = "For")]
    public class ControllerTagHelper : TagHelper
    {
        public ModelExpression For { get; set; }

        public override void Process(TagHelperContext context,
            TagHelperOutput output)
        {
            output.Content.SetHtmlContent($"{For.Name}"); 
        }
    }
}
