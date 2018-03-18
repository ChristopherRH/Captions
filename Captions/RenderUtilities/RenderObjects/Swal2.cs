
using Captions.Attributes;

namespace Captions.RenderUtilities.RenderObjects
{
    /// <summary>
    /// Swal2 object for rendering
    /// </summary>
    public class Swal2
    {
        /// <summary>
        /// constructor
        /// </summary>
        public Swal2()
        {

        }

        #region Implemented into renderer

        [Render]
        public string Title { get; set; }

        [Render]
        public string TitleText { get; set; }

        [Render]
        public string ConfirmButtonText { get; set; }

        [Render]
        public string ConfirmButtonColor { get; set; }

        [Render]
        public string ConfirmButtonClass { get; set; }

        [Render]
        public string CancelButtonText { get; set; }

        [Render]
        public string CancelButtonColor { get; set; }

        [Render]
        public string CancelButtonClass { get; set; }

        [Render]
        public bool ButtonsStyling { get; set; }

        [Render]
        public bool ReverseButtons { get; set; }

        #endregion


        #region Not Implemented Yet, not tested


        public string Text { get; set; }
        public string Html { get; set; }
        public string Footer { get; set; }
        public string Type => null;
        public bool Toast => false;
        public string CustomClass => string.Empty;
        public string Target => "body";
        public bool Backdrop => true;
        public bool Animation => true;
        public bool AllowOutsideClick => true;
        public bool AllowEscapeKey => true;
        public bool AllowEnterKey => true;
        public bool ShowConfirmButton => true;
        public bool ShowCancelButton => false;
        public string PreConfirm => null;
        public string ConfirmButtonAriaLabel => string.Empty;
        public string CancelButtonAriaLabel => string.Empty;
        public bool FocusConfirm => true;
        public bool FocusCancel => false;
        public bool ShowCloseButton => false;
        public string CloseButtonAriaLabel => "Close this dialog";
        public bool ShowLoaderOnConfirm => false;
        public string ImageUrl => null;
        public string ImageWidth => null;
        public string ImageHeight => null;
        public string ImageAlt => string.Empty;
        public string ImageClass => null;
        public string Timer => null;
        public string Width => null;
        public string Padding => null;
        public string Background => null;
        public string Input => null;
        public string InputPlaceholder => string.Empty;
        public string InputValue => string.Empty;
        public bool InputAutoTrim => true;
        public string InputClass => null;
        public string InputValidator => null;
        public bool Grow => false;
        public string Position => "Center";

        #endregion


    }
}