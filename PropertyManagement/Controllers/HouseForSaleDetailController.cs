using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using PropertyManagement.Models;
using Microsoft.AspNet.Identity;
using PropertyManagement.Utility;


namespace PropertyManagement.Controllers
{
    public class HouseForSaleDetailController : Controller
    {

        private ApplicationDbContext db;

        public HouseForSaleDetailController()
        {
            db = ApplicationDbContext.Create();
        }
        // GET: HouseDetail
        public ActionResult Index(int id)
        {
            var userid = User.Identity.GetUserId();
            var user = db.Users.FirstOrDefault(u => u.Id == userid);

            var HouseForSaleModel = db.Houses.SingleOrDefault(b => b.Id == id);









            HouseSaleViewmodel model = new HouseSaleViewmodel
            {
                HouseId = HouseForSaleModel.Id,

                Avaibility = HouseForSaleModel.Avaibility,
                DateAdded = HouseForSaleModel.DateAdded,
                Description = HouseForSaleModel.Description,


                ImageUrl = HouseForSaleModel.ImageUrl,
                SalePrice= HouseForSaleModel.SalePrice,

                Address = HouseForSaleModel.Address,
                UserId = userid,
                
                NumberOfBathrooms = HouseForSaleModel.NumberOfBathrooms,
                NumberOfRooms = HouseForSaleModel.NumberOfRooms,
                NumberOfBedrooms = HouseForSaleModel.NumberOfBedrooms,
                ExtraInformation = HouseForSaleModel.ExtraInformation,





            };

            return View(model);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
        }
    }
}