using PropertyManagement.Extensions;
using PropertyManagement.Models;
using System.Collections.Generic;
using System.Linq;

using System.Web.Mvc;




namespace PropertyManagement.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string search = null)
        {
            /*var thumbnails1 = new List<ThumbnailModel>().GetHouse1Thumbnail(ApplicationDbContext.Create(), search);
            var thumbnails = new List<ThumbnailModel>().GetHouseThumbnail(ApplicationDbContext.Create(), search);
            var count = thumbnails.Count() / 4;
            
            var model = new List<ThumbnailBoxViewModel>();

            for (int i = 0; i <= count; i++)
            {
                model.Add(new ThumbnailBoxViewModel
                {
                    Thumbnails1 = thumbnails1.Skip(i * 4).Take(4),
                    Thumbnails = thumbnails.Skip(i * 4).Take(4)
                });
            }


            return View(model);
            */
            return View();
        }
        public ActionResult ForSale(string search = null)
        {

            var thumbnails1 = new List<ThumbnailModel>().GetHouse1Thumbnail(ApplicationDbContext.Create(), search);
            var thumbnails = new List<ThumbnailModel>().GetHouseThumbnail(ApplicationDbContext.Create(), search);
            var count = thumbnails.Count() / 4;

            var model = new List<ThumbnailBoxViewModel>();

            for (int i = 0; i <= count; i++)
            {
                model.Add(new ThumbnailBoxViewModel
                {
                    Thumbnails1 = thumbnails1.Skip(i * 4).Take(4),
                    Thumbnails = thumbnails.Skip(i * 4).Take(4)
                });
            }


            return View(model);

        }
        public ActionResult ForRent(string search = null)
        {

            var thumbnails1 = new List<ThumbnailModel>().GetHouse1Thumbnail(ApplicationDbContext.Create(), search);
            var thumbnails = new List<ThumbnailModel>().GetHouseThumbnail(ApplicationDbContext.Create(), search);
            var count = thumbnails.Count() / 4;

            var model = new List<ThumbnailBoxViewModel>();

            for (int i = 0; i <= count; i++)
            {
                model.Add(new ThumbnailBoxViewModel
                {
                    Thumbnails1 = thumbnails1.Skip(i * 4).Take(4),
                    Thumbnails = thumbnails.Skip(i * 4).Take(4)
                });
            }


            return View(model);
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}