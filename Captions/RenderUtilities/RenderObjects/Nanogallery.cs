// https://nanogallery2.nanostudio.org/documentation.html
// Go to Gallery Settings

using Captions.Attributes;
using System.ComponentModel;

namespace Captions.RenderUtilities.RenderObjects
{
    /// <summary>
    /// Nanogallery object for rendering the div data
    /// </summary>
    public class Nanogallery
    {
        #region thumbnail config
        
        [Render]
        [Description("thumbnailHeight")]
        public string ThumbnailHeight { get; set; }

        [Render]
        [Description("thumbnailWidth")]
        public string ThumbnailWidth { get; set; }

        [Render]
        [Description("thumbnailOpenImage")]
        public bool ThumbnailOpenImage { get; set; } = true;
        
        /// <summary>
        /// left, right, center, justified, fillwidth (default)
        /// </summary>
        [Render]
        [Description("thumbnailAlignment")]
        public string ThumbnailAlignment { get; set; }

        [Render]
        [Description("thumbnailBaseGridHeight")]
        public string ThumbnailBaseGridHeight { get; set; }

        [Render]
        [Description("thumbnailBorderHorizontal")]
        public string ThumbnailBorderHorizontal { get; set; }

        [Render]
        [Description("thumbnailBorderVertical ")]
        public string ThumbnailBorderVertical { get; set; }

        [Render]
        [Description("thumbnailGutterWidth")]
        public string ThumbnailGutterWidth { get; set; }

        [Render]
        [Description("thumbnailGutterHeight")]
        public string ThumbnailGutterHeight { get; set; }

        // none, slideUp, slideDown, scaleUp, scaleDown, fadeIn, randomScale, flipDown, flipUp, slideDown2, slideUp2, slideRight, slideLeft, custom. 
        [Render]
        [Description("thumbnailDisplayTransition")]
        public string ThumbnailDisplayTransition { get; set; }

        #endregion


        #region Gallery Config

        [Render]
        [Description("galleryDisplayMode")]
        public string GalleryDisplayMode { get; set; }

        [Render]
        [Description("galleryDisplayMoreStep")]
        public int GalleryDisplayMoreStep { get; set; }

        /// <summary>
        /// "rectangles", "dots", "numbers"
        /// </summary>
        [Render]
        [Description("galleryPaginationMode")]
        public string GalleryPaginationMode { get; set; }

        [Render]
        [Description("galleryMaxRows")]
        public int GalleryMaxRows { get; set; }


        [Render]
        [Description("paginationVisiblePages")]
        public int PaginationVisiblePages { get; set; }

        [Render]
        [Description("paginationSwipe")]
        public bool PaginationSwipe { get; set; } = true;

        /// <summary>
        ///  'titleAsc', 'titleDesc', 'reversed', 'random' (=shuffle).
        /// </summary>
        [Render]
        [Description("gallerySorting")]
        public string GallerySorting { get; set; }

        [Render]
        [Description("galleryMaxItems")]
        public int GalleryMaxItems { get; set; }

        [Render]
        [Description("galleryResizeAnimation")]
        public bool GalleryResizeAnimation { get; set; } = true;

        /// <summary>
        /// "dark", "light"
        /// </summary>
        [Render]
        [Description("galleryTheme")]
        public string GalleryTheme { get; set; }

        /// <summary>
        /// delay in rendering
        /// </summary>
        [Render]
        [Description("galleryRenderDelay")]
        public int GalleryRenderDelay { get; set; }


        /// <summary>
        ///  'none', 'rotateX', 'slideUp'
        /// </summary>
        [Render]
        [Description("galleryDisplayTransition")]
        public string GalleryDisplayTransition { get; set; } = "none";

        [Render]
        [Description("galleryDisplayTransitionDuration")]
        public int GalleryDisplayTransitionDuration { get; set; }

        #endregion

    }
}