using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PropertyManagement.Models
{
    public class ThumbnailBoxViewModel
    {
         
        public IEnumerable<ThumbnailModel> Thumbnails { get; set; }
        public IEnumerable<ThumbnailModel> Thumbnails1 { get; set; }

    }
}