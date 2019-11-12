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
    public class HouseForRentDetailController : Controller
    {
      
            private ApplicationDbContext db;

            public HouseForRentDetailController()
            {
                db = ApplicationDbContext.Create();
            }
            // GET: HouseDetail
            public ActionResult Index(int id)
            {
            var userid = User.Identity.GetUserId();
            var user = db.Users.FirstOrDefault(u => u.Id == userid);

            var HouseForRentModel = db.Houses1.SingleOrDefault(b => b.Id == id);

                


          
                                 
                  
                

                HouseRentalViewmodel model = new HouseRentalViewmodel
                {
                    HouseId = HouseForRentModel.Id,
                   
                    Avaibility = HouseForRentModel.Avaibility,
                    DateAdded = HouseForRentModel.DateAdded,
                    Description = HouseForRentModel.Description,
               
                   
                    ImageUrl = HouseForRentModel.ImageUrl,
                  
                    
                    Address = HouseForRentModel.Address,
                    UserId =userid,
                    RentalPrice =HouseForRentModel.RentalPrice,
                    NumberOfBathrooms=HouseForRentModel.NumberOfBathrooms,
                    NumberOfRooms= HouseForRentModel.NumberOfRooms,
                    NumberOfBedrooms= HouseForRentModel.NumberOfBedrooms,
                    ExtraInformation= HouseForRentModel.ExtraInformation,
                    
                    
               


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