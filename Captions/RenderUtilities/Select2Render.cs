using Captions.Attributes;
using Captions.RenderUtilities.RenderObjects;
using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;

namespace Captions.RenderUtilities
{
    /// <summary>
    /// Select2 Rendering
    /// </summary>
    public static class Select2Render
    {
        /// <summary>
        /// Renders a select2 list
        /// the value of the option will be the valProp, default ID
        /// the display text of the option will be the textProp, default ID
        /// @Html.Select2(Model, new Select2{}, textProp: nameof(Caption.Title))
        /// </summary>
        /// <param name="list"></param>
        /// <param name="valProp"></param>
        /// /// <param name="textProp"></param>
        /// <returns></returns>
        public static IHtmlString Select2(this HtmlHelper htmlHelper, IEnumerable list, Select2 select2, string valProp = "ID", string textProp = "ID")
        {
            var urlHelper = new UrlHelper(htmlHelper.ViewContext.RequestContext);
            var selector = list.GetType().GUID.ToString();

            var select2Options = BuildSelect2Options(list, valProp, textProp);
            var select = new TagBuilder("select")
            {
                InnerHtml = select2Options
            };

            select.Attributes.Add("id", selector);
            select.Attributes.Add("name", "id");
            if (select2.multiple)
            {
                select.Attributes.Add("multiple", "multiple");
            }


            // build the select2 script
            var script = new TagBuilder("script")
            {
                InnerHtml = BuildSelect2(select2, selector)
            };
            return new HelperResult(writer =>
            {
                writer.Write(select.ToString(TagRenderMode.Normal));
                writer.Write(script.ToString(TagRenderMode.Normal));
            });
        }

        /// <summary>
        /// Build the options for the select2
        /// </summary>
        /// <param name="list"></param>
        /// <param name="valProp"></param>
        /// <param name="textProp"></param>
        /// <returns></returns>
        private static string BuildSelect2Options(IEnumerable list, string valProp, string textProp)
        {
            var options = string.Empty;
            foreach (var item in list)
            {
                var props = item.GetType().GetProperties();
                var valType = props.Where(x => x.Name == valProp).FirstOrDefault();
                var displayType = props.Where(x => x.Name == textProp).FirstOrDefault();

                if (displayType == null || valType == null)
                {
                    throw new Exception($"The property {valProp} pr {textProp} is not valid on object {item.GetType()})");
                }

                var val = valType.GetValue(item, null);
                var display = displayType.GetValue(item, null);
                var option = $"<option value='{val}'>{display}</option>";

                options += option;
            }

            return options;
        }

        /// <summary>
        /// Builds the object
        /// </summary>
        /// <param name="swal"></param>
        /// <returns></returns>
        private static string BuildSelect2(Select2 select2, string selector)
        {
            var start = "$(function(){";
            var end = "});});";
            var body = $"$('#{selector}').select2({{";

            foreach (var prop in select2.GetType().GetProperties())
            {
                var val = prop.GetValue(select2, null);
                if (prop.GetCustomAttributes(typeof(RenderAttribute), false).Length > 0 && val != null)
                {
                    if (val.GetType() == typeof(bool))
                    {
                        // bools are uppercase first late strings, so for JS convert to lower case string
                        body += $"{prop.Name}: {val.ToString().ToLower()},";
                    }
                    else
                    {
                        body += $"{prop.Name}: '{val}',";
                    }
                }
            }

            //// remove last comma from the body          
            return start + body.Substring(0, body.Length - 1) + end;
        }

    }
}