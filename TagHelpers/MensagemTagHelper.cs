﻿using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Fiap.Aula03.Web.TagHelpers
{
    public class MensagemTagHelper : TagHelper
    {
        public string Class { get; set; }
        public string Texto { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (!string.IsNullOrEmpty(Texto))
            {
                output.TagName = "div";
                output.Attributes.SetAttribute("class",string.IsNullOrEmpty(Class) ? "alert alert-success" : Class);
                output.Content.SetContent(Texto);
            }
        }
    }
}
