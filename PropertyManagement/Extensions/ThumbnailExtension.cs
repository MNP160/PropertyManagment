using PropertyManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PropertyManagement.Extensions
{
    public static class ThumbnailExtensions
    {
        public static IEnumerable<ThumbnailModel> GetHouseThumbnail(this List<ThumbnailModel> thumbnails, int? low, int? high, string property, ApplicationDbContext db = null,  string search = null)
        {
            try
            {
                if (db == null) db = ApplicationDbContext.Create();

                thumbnails = (from b in db.Houses
                              select new ThumbnailModel
                              {
                                  HouseId = b.Id,
                                  Address=b.Address,
                                  numberOfBedrooms=b.NumberOfBedrooms,
                                  SalePrice =  (int)b.SalePrice,
                                  
                                  ImageUrl = b.ImageUrl,
                                  Link = "/HouseForSaleDetail/Index/" + b.Id,
                              }).ToList();

                if (search != null)
                {
                    return thumbnails.Where(t => t.Address.ToLower().Contains(search.ToLower())).OrderBy(t => t.SalePrice);
                }
                if(low!=null && high !=null &&property!=null)
                {
                    if (property.ToLower().Equals("price"))
                    {
                        return thumbnails.Where(x => x.SalePrice >= low && x.SalePrice <= high);
                    }
                    else if (property.ToLower().Equals("bedrooms"))
                    {
                        return thumbnails.Where(x=>x.numberOfBedrooms>=low&&x.numberOfBedrooms<=high);
                    }
                }
            }
            catch 
            {

            }
            return thumbnails.OrderBy(t => t.SalePrice);

        }
    }
}