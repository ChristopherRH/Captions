using AutoMapper;
using Captions.Models;
using System.Collections.Generic;

namespace Captions.Viewmodels
{
    public class CaptionListViewModel
    {

        /// <summary>
        /// default constructor
        /// </summary>
        public CaptionListViewModel()
        {
            Captions = new List<CaptionViewModel>();
        }

        public ICollection<CaptionViewModel> Captions { get; set; }

    }
}