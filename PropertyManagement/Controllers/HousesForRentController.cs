using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PropertyManagement.Models;

namespace PropertyManagement.Controllers
{
    public class HousesForRentController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: HouseForRent
        public ActionResult Index(int? low, int? high)
        {
            ViewData["high"] = high;
            ViewData["low"] = low;

            var houses = from house in db.Houses1 select house;
            if (low != null && high != null)
            {
                houses = db.Houses1.Where(x => x.RentalPrice > low && x.RentalPrice < high);

            }

            return View(houses.AsNoTracking().AsEnumerable());
        }

        // GET: HouseForRent/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            House1 house1 = db.Houses1.Find(id);
            if (house1 == null)
            {
                return HttpNotFound();
            }
            return View(house1);
        }

        // GET: HouseForRent/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HouseForRent/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Description,NumberOfRooms,NumberOfBathrooms,NumberOfBedrooms,ImageUrl,Avaibility,RentalPrice,DateAdded,ExtraInformation,Address")] House1 house1)
        {
            if (ModelState.IsValid)
            {
                db.Houses1.Add(house1);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(house1);
        }

        // GET: HouseForRent/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            House1 house1 = db.Houses1.Find(id);
            if (house1 == null)
            {
                return HttpNotFound();
            }
            return View(house1);
        }

        // POST: HouseForRent/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Description,NumberOfRooms,NumberOfBathrooms,NumberOfBedrooms,ImageUrl,Avaibility,RentalPrice,DateAdded,ExtraInformation,Address,Rented")] House1 house1)
        {
            if (ModelState.IsValid)
            {
                db.Entry(house1).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(house1);
        }

        // GET: HouseForRent/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            House1 house1 = db.Houses1.Find(id);
            if (house1 == null)
            {
                return HttpNotFound();
            }
            return View(house1);
        }

        // POST: HouseForRent/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            House1 house1 = db.Houses1.Find(id);
            db.Houses1.Remove(house1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


      


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult deleteRented()
        {
            var rented = from x in db.Houses1.Where(x => x.Rented == true) select x;


            db.Houses1.RemoveRange(rented);
            db.SaveChanges();


            return RedirectToAction(nameof(Index));
        }
    }
}
