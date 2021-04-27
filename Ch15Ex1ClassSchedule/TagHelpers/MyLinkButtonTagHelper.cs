using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Routing;

namespace ClassSchedule.TagHelpers
{
    public class MyLinkButtonTagHelper : TagHelper
    {
        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewCtx { get; set; }

        private LinkGenerator linkBuilder;
        public MyLinkButtonTagHelper(LinkGenerator lg) => linkBuilder = lg;

        public string Action { get; set; }
        public string Controller { get; set; }
        public string Id { get; set; }
        public bool IsActive { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            string ctlr = Controller!=null ? Controller : ViewCtx.RouteData.Values["controller"].ToString(); 
            string action = Action!=null ? Action : ViewCtx.RouteData.Values["action"].ToString();
            var id = Id!=null ? new{Id} : null;
            string url = linkBuilder.GetPathByAction(action, ctlr, id);

            string linkClasses = IsActive ? "btn btn-dark" : "btn btn-outline-dark";

            output.BuildLink(url, linkClasses);
        }
    }
}
