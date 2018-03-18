using Captions.Attributes;
using Captions.RenderUtilities.RenderObjects;
using System;
using System.IO;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.WebPages;

namespace Captions.RenderUtilities
{
    /// <summary>
    /// HTML helper for Sweet Alert 2 rendering
    /// </summary>
    public static class SwalRender
    {
        /// <summary>
        /// Renders a simple sweet alert
        /// </summary>
        /// <param name="target"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        public static IHtmlString Swal2(this HtmlHelper htmlHelper, Swal2 swal2)
        {
            var swalString = BuildSwal(swal2);
            var urlHelper = new UrlHelper(htmlHelper.ViewContext.RequestContext);
            var script = new TagBuilder("script")
            {
                InnerHtml = swalString
            };
            return new HelperResult(writer =>
            {
                writer.Write(script.ToString(TagRenderMode.Normal));
            });
        }

        /// <summary>
        /// Builds the sweet alert from the supplied swal object
        /// </summary>
        /// <param name="swal"></param>
        /// <returns></returns>
        private static string BuildSwal(Swal2 swal)
        {
            // start and end tags for the sweet alert, this is necessary since it's a script function relying on swal
            var start = "$(function(){swal(";
            var end = ")});";

            var body = string.Empty;
            foreach (var prop in swal.GetType().GetProperties())
            {
                var val = prop.GetValue(swal, null);
                if (prop.GetCustomAttributes(typeof(RenderAttribute), false).Length > 0 && val != null)
                {
                    if (val.GetType() == typeof(bool))
                    {
                        // bools are uppercase first late strings, so for JS convert to lower case string
                        body += $"{prop.Name} = {val.ToString().ToLower()},";
                    }
                    else
                    {
                        body += $"{prop.Name} = '{val}',";
                    }
                }
            }

            // remove last comma from the body          
            return start + body.Substring(0, body.Length - 1) + end;
        }

    }
}