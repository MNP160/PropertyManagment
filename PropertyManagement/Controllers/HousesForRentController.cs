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

        // GET: HousesForRent
        public ActionResult Index()
        {
            return View(db.Houses1.ToList());
        }

        // GET: HousesForRent/Details/5
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

        // GET: HousesForRent/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HousesForRent/Create
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

        // GET: HousesForRent/Edit/5
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

        // POST: HousesForRent/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Description,NumberOfRooms,NumberOfBathrooms,NumberOfBedrooms,ImageUrl,Avaibility,RentalPrice,DateAdded,ExtraInformation,Address")] House1 house1)
        {
            if (ModelState.IsValid)
            {
                db.Entry(house1).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(house1);
        }

        // GET: HousesForRent/Delete/5
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

        // POST: HousesForRent/Delete/5
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
    }
}
