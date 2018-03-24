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
    public static class IntercoolerRender
    {

        /// <summary>
        /// Render a nanogallery from a list of images
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="list"></param>
        /// <param name="ng"></param>
        /// <param name="albumId"></param>
        /// <returns></returns>
        public static IHtmlString Intercooler(this HtmlHelper htmlHelper, Intercooler ic)
        {
            var options = BuildIntercooler(ic);
            var div = new TagBuilder("div");
            div.Attributes.Add("class", "intercooler-loader");
            foreach (var item in options)
            {
                div.Attributes.Add(item.IcVerb, item.IcValue);
            }

            var spinner = new TagBuilder("i");
            spinner.Attributes.Add("class", "fa fa-spinner fa-spin fa-5x");
            spinner.Attributes.Add("id", "indicator");
            spinner.Attributes.Add("style", "display:none");

            var indicator = new TagBuilder("center")
            {
                InnerHtml = spinner.ToString()
            };


            var writer = new HelperResult(x =>
            {
                x.Write(div.ToString(TagRenderMode.Normal).Replace("&#39;", "\'"));
                x.Write(indicator.ToString(TagRenderMode.Normal).Replace("&#39;", "\'"));
            });

            return writer;
        }

        /// <summary>
        /// Build the generic indicator
        /// </summary>
        /// <returns></returns>
        private static string BuildIndicator()
        {
            return "<center><i class=\"fa fa-spinner fa-spin fa-5x\" id=\"indicator\" style=\"display: none\"></i></center>";
        }


        /// <summary>
        /// Build the ng string for the div data element
        /// </summary>
        /// <param name="ng"></param>
        /// <returns></returns>
        private static List<IcData> BuildIntercooler(Intercooler ic)
        {
            var list = new List<IcData>();
            foreach (var prop in ic.GetType().GetProperties())
            {
                if (prop.Name == "onbeforeTrigger")
                {
                    var x = 1;
                }
                var val = prop.GetValue(ic, null);
                if (val != null)
                {
                    list.Add(new IcData(GetDescription(prop), (string)val));
                }

            }

            return list;
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

        /// <summary>
        /// Store the intercooler config in a struct
        /// </summary>
        public struct IcData
        {
            public IcData(string verb, string val)
            {
                IcVerb = verb;
                IcValue = val;
            }

            public string IcVerb { get; private set; }
            public string IcValue { get; private set; }
        }
    }
}