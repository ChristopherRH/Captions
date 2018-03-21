using Captions.Attributes;
using Captions.RenderUtilities.RenderObjects;
using Captions.Viewmodels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;

namespace Captions.RenderUtilities
{
    public static class NanogalleryRender
    {
        /// <summary>
        /// Render a nanogallery from a list of images
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="list"></param>
        /// <param name="ng"></param>
        /// <param name="albumId"></param>
        /// <returns></returns>
        public static IHtmlString Nanogallery(this HtmlHelper htmlHelper, IEnumerable list, Nanogallery ng = null, string albumId = null)
        {
            var urlHelper = new UrlHelper(htmlHelper.ViewContext.RequestContext);
            var div = new TagBuilder("div");
            div.Attributes.Add("data-nanogallery2", BuildNg2Div(ng ?? new Nanogallery()));
            div.Attributes.Add("id", "nanogallery" + $"-{albumId}");
            var refs = BuildListGallery(urlHelper, list);
            foreach(var aref in refs)
            {
                div.InnerHtml += aref.ToString(TagRenderMode.Normal);
            }
            var writer =  new HelperResult(x =>
            {
                // it's encoded here, so need to decode...
                x.Write(div.ToString().Replace("&#39;", "\'"));
            });

            return writer;
        }

        /// <summary>
        /// Build the gallery string
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        private static List<TagBuilder> BuildListGallery(UrlHelper urlHelper, IEnumerable list)
        {
            var tagList = new List<TagBuilder>();
            foreach(var item in list)
            {
                var url = urlHelper.Action("GetImage", new { id = ((ViewModel)item).ID });
                var aTag = new TagBuilder("a");
                aTag.Attributes.Add("href", url);
                aTag.Attributes.Add("data-ngthumb", url);


                tagList.Add(aTag);
            }

            return tagList;
        }

        /// <summary>
        /// Build the ng string for the div data element
        /// </summary>
        /// <param name="ng"></param>
        /// <returns></returns>
        private static string BuildNg2Div(Nanogallery ng)
        {
            var start = $"{{ ";
            var end = $"}}";
            var body = $"";
            foreach(var prop in ng.GetType().GetProperties())
            {
                var val = prop.GetValue(ng, null);
                if (prop.GetCustomAttributes(typeof(RenderAttribute), false).Length > 0 && val != null)
                {
                    if (val.GetType() == typeof(bool))
                    {
                        // bools are uppercase first late strings, so for JS convert to lower case string
                        body += $"\"{GetDescription(prop)}\": \"{val.ToString().ToLower()}\",";
                    }
                    else if(val.GetType() == typeof(int))
                    {
                        body += $"\"{GetDescription(prop)}\": {val},";
                    }
                    else
                    {
                        if (Int32.TryParse((string)val, out var num))
                        {
                            body += $"\"{GetDescription(prop)}\": {val},";
                        }
                        else
                        {
                            body += $"\"{GetDescription(prop)}\": \"{val}\",";
                        }
                    }
                }

            }
            var str = (start + body.Substring(0, body.Length - 1) + end);
            return str;
        }
        
        /// <summary>
        /// Get the description attribute string for the property name of the data element
        /// </summary>
        /// <param name="pi"></param>
        /// <returns></returns>
        private static string GetDescription(PropertyInfo pi)
        {
            return ((DescriptionAttribute)pi.GetCustomAttributes(typeof(DescriptionAttribute), true)[0])?.Description;
        }
    }
}