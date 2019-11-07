using PropertyManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PropertyManagement.Extensions
{
    public static class ThumbnailExtensions
    {
        public static IEnumerable<ThumbnailModel> GetHouseThumbnail(this List<ThumbnailModel> thumbnails, ApplicationDbContext db = null, string search = null)
        {
            try
            {
                if (db == null) db = ApplicationDbContext.Create();

                thumbnails = (from b in db.Houses
                              select new ThumbnailModel
                              {
                                  HouseId = b.Id,
                                  Address=b.Address,
                                  SalePrice = b.SalePrice.ToString(),
                                 
                                  ImageUrl = b.ImageUrl,
                                  Link = "/HouseDetail/Index/" + b.Id,
                              }).ToList();

                if (search != null)
                {
                    return thumbnails.Where(t => t.Address.ToLower().Contains(search.ToLower())).OrderBy(t => t.Address);
                }
            }
            catch 
            {

            }
            return thumbnails.OrderBy(t => t.Address);

        }
    }
}