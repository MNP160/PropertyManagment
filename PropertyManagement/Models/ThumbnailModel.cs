using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PropertyManagement.Models
{
    public class ThumbnailModel
    {
        public int HouseId { get; set; }
        public string Address { get; set; }
        public string SalePrice { get; set; }
        public string RentalPrice { get; set; }
        public string ImageUrl { get; set; }
        public string Link { get; set; }
    }
}