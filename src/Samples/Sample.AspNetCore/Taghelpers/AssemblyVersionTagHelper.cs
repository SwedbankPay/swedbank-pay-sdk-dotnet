using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Sample.AspNetCore.TagHelpers
{
    [HtmlTargetElement("AssemblyVersion", TagStructure = TagStructure.NormalOrSelfClosing)]
    public class AssemblyVersionTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "";
            output.Content.Append(GetType().Assembly.GetName().Version.ToString());
        }
    }
    
}
