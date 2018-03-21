using AutoMapper;
using Captions.Models;
using System.Collections.Generic;
using WebGrease.Css.Extensions;

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

        public CaptionListViewModel(ICollection<Caption> captions)
        {
            Captions = new List<CaptionViewModel>();
            captions.ForEach(x => Captions.Add(new CaptionViewModel(x)));
        }

        public ICollection<CaptionViewModel> Captions { get; set; }

    }
}