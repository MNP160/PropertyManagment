using PropertyManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace PropertyManagement.Extensions
{
    public static class ThumbnailExtensionForRent
    {
        

        public static IEnumerable<ThumbnailModel> GetHouse1Thumbnail(this List<ThumbnailModel> thumbnails1, ApplicationDbContext db = null, string search = null)
        {
            try
            {
                if (db == null) db = ApplicationDbContext.Create();

                thumbnails1 = (from b in db.Houses1
                              select new ThumbnailModel
                              {
                                  HouseId = b.Id,
                                  Address = b.Address,
                             
                                  RentalPrice=b.RentalPrice.ToString(),
                                  ImageUrl = b.ImageUrl,
                                  Link = "/HouseForRentDetail/Index/" + b.Id,
                              }).ToList();

                if (search != null)
                {
                    return thumbnails1.Where(t => t.RentalPrice.ToLower().Contains(search.ToLower())).OrderBy(t => t.RentalPrice);
                }
            }
            catch
            {

            }
            return thumbnails1.OrderBy(t => t.RentalPrice);

        }
    }
}