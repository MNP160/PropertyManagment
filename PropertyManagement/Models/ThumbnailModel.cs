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
        public int SalePrice { get; set; }
        public int RentalPrice { get; set; }
        public string ImageUrl { get; set; }
        public string Link { get; set; }
        public int numberOfBedrooms { get; set; }
    }
}