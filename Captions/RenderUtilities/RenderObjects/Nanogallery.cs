// https://nanogallery2.nanostudio.org/documentation.html
// Go to Gallery Settings
// Not everything in here works, it's a surprise...

using Captions.Attributes;
using System.Collections.Generic;
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
        public int ThumbnailBorderHorizontal { get; set; }

        [Render]
        [Description("thumbnailBorderVertical ")]
        public int ThumbnailBorderVertical { get; set; }

        [Render]
        [Description("thumbnailGutterWidth")]
        public int ThumbnailGutterWidth { get; set; }

        [Render]
        [Description("thumbnailGutterHeight")]
        public int ThumbnailGutterHeight { get; set; }

        // none, slideUp, slideDown, scaleUp, scaleDown, fadeIn, randomScale, flipDown, flipUp, slideDown2, slideUp2, slideRight, slideLeft, custom. 
        [Render]
        [Description("thumbnailDisplayTransition")]
        public string ThumbnailDisplayTransition { get; set; }

        [Render]
        [Description("thumbnailDisplayTransitionDuration")]
        public int ThumbnailDisplayTransitionDuration { get; set; }

        [Render]
        [Description("thumbnailSliderDelay")]
        public int ThumbnailSliderDelay { get; set; } = 1000;

        [Render]
        [Description("position")]
        public string Position { get; set; }

        [Render]
        [Description("align")]
        public string Align { get; set; }

        [Render]
        [Description("display")]
        public bool Display { get; set; } = true;

        [Render]
        [Description("displayDescription")]
        public bool DisplayDescription { get; set; }

        [Render]
        [Description("hideIcons")]
        public bool HideIcons { get; set; } = true;


        [Render]
        [Description("displayBreadcrumb")]
        public bool DisplayBreadcrumb { get; set; }
        
        [Render]
        [Description("breadcrumbOnlyCurrentLevel")]
        public bool BreadcrumbOnlyCurrentLevel { get; set; }
        
        [Render]
        [Description("breadcrumbAutoHideTopLevel")]
        public bool BreadcrumbAutoHideTopLevel { get; set; }
        
        [Render]
        [Description("touchAnimation")]
        public bool TouchAnimation { get; set; } = true;

        #endregion


        #region Gallery Config

        /// <summary>
        /// thumbnailToolbarAlbum: { topLeft: 'select', topRight : 'counter' }
        /// </summary>
        [Render]
        [Description("thumbnailToolbarAlbum")]
        public string ThumbnailToolbarAlbum { get; set; } = "{}";

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

        /// <summary>
        /// "viewerToolbar":   {
        ///                     "standard":   "minimizeButton, label, shareButton, fullscreenButton",
        ///                     "minimized":  "minimizeButton, label, fullscreenButton, downloadButton, infoButton"
        ///                    },
        ///                    
        /// This will use special logic in the nanogallery render, none, standard, minimized
        /// for now, read only default
        /// </summary>
        [Render]
        [Description("viewerToolbar")]
        public string ViewerToolbar => "default";

        /// <summary>
        /// "viewerTools":    {
        ///                     "topLeft":   "label",
        ///                     "topRight":  "playPauseButton, zoomButton, fullscreenButton, closeButton" 
        ///                    }
        /// This will have special logic, but for now read only default
        /// </summary>
        [Render]
        [Description("viewerTools")]
        public string ViewerTools => "default";

        /// <summary>
        /// "icons":    {
        ///                     "thumbnailAlbum": "<i style='color:#e00;' class='fa fa-search-plus'></i>"
        ///                    }
        ///                    
        /// paginationNext:          
        /// paginationPrevious:
        /// galleryMoreButton:
        /// buttonClose:        
        /// viewerPrevious:     
        /// viewerNext:         
        /// viewerImgPrevious:  
        /// viewerImgNext:      
        /// viewerDownload:     
        /// viewerToolbarMin:   
        /// viewerToolbarStd:   
        /// viewerPlay:         
        /// viewerPause:        
        /// viewerFullscreenOn: 
        /// viewerFullscreenOff:
        /// viewerZoomIn:       
        /// viewerZoomOut:      
        /// viewerLinkOriginal: 
        /// viewerInfo:         
        /// viewerShare:        
        /// user:               
        /// location:           
        /// config:             
        /// This will have special logic, but for now read only default
        /// </summary>
        [Render]
        [Description("icons")]
        public string Icons => "default";

        #endregion

    }
}