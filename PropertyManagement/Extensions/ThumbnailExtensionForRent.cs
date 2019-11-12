using PropertyManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace PropertyManagement.Extensions
{
    public static class ThumbnailExtensionForRent
    {
        

        public static IEnumerable<ThumbnailModel> GetHouse1Thumbnail(this List<ThumbnailModel> thumbnails1, int? low, int? high, string property, ApplicationDbContext db = null, string search = null)
        {
            try
            {
                if (db == null) db = ApplicationDbContext.Create();

                thumbnails1 = (from b in db.Houses1
                              select new ThumbnailModel
                              {
                                  HouseId = b.Id,
                                  Address = b.Address,
                                  numberOfBedrooms=b.NumberOfBedrooms,
                                  RentalPrice= (int)b.RentalPrice,
                                  ImageUrl = b.ImageUrl,
                                  Link = "/HouseForRentDetail/Index/" + b.Id,
                              }).ToList();

                if (search != null)
                {
                    return thumbnails1.Where(t => t.Address.ToLower().Contains(search.ToLower())).OrderBy(t => t.RentalPrice);
                }
                if (low != null && high != null &&property!=null)
                {
                    if (property.ToLower().Equals("price"))
                    {
                        return thumbnails1.Where(x => x.RentalPrice > low && x.RentalPrice < high);
                    }
                    else if (property.ToLower().Equals("bedrooms"))
                    {
                        return thumbnails1.Where(x=>x.numberOfBedrooms>low&&x.numberOfBedrooms<high);
                    }
                }
            }
          
            catch
            {

            }
            return thumbnails1.OrderBy(t => t.RentalPrice);

        }
    }
}