
using Captions.Attributes;

namespace Captions.RenderUtilities.RenderObjects
{
    /// <summary>
    /// Select2 object for rendering
    /// </summary>
    public class Select2
    {

        #region Implemented

        [Render]
        public bool allowClear { get; set; } = false;

        [Render]
        public bool closeOnSelect { get; set; } = true;

        [Render]
        public bool debug { get; set; }

        [Render]
        public bool disabled { get; set; }

        [Render]
        public bool dropdownAutoWidth { get; set; } = true;

        [Render]
        public int maximumInputLength { get; set; }

        [Render]
        public int maximumSelectionLength { get; set; }

        [Render]
        public int minimumInputLength { get; set; }

        [Render]
        public int minimumResultsForSearch { get; set; }

        [Render]
        public bool multiple { get; set; }

        [Render]
        public string placeholder { get; set; }

        [Render]
        public bool selectOnClose { get; set; } = true;

        [Render]
        public string theme { get; set; }

        /// <summary>
        /// Width of the select2
        /// 'element'	Uses the computed element width from any applicable CSS rules.
        /// 'style'	Width is determined from the select element's style attribute. If no style attribute is found, null is returned as the width.
        /// 'resolve'	Uses the style attribute value if available, falling back to the computed element width as necessary.
        /// '<value>'	Valid CSS values can be passed as a string (e.g.width: '80%').
        /// </summary>
        [Render]
        public string width { get; set; } = "resolve";

        /// <summary>
        /// To be used with tags to specify the seperators in the tags
        /// </summary>
        [Render]
        public string tokenSeparators { get; set; }

        #endregion

        #region Not Implemented

        public string tokenizer { get; set; }
        

        #endregion
    }
}