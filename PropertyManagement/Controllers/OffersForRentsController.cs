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
    public class OffersForRentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: OffersForRents
        public ActionResult Index(string searchString)
        {
            var offers = from o in db.OffersForRents
                           select o;
            if (!String.IsNullOrEmpty(searchString))
            {
                offers = offers.Where(x => x.house.Address.Contains(searchString));

            }
            //var offersForRents = db.OffersForRents.Include(o => o.user);
            return View(offers.ToList());
        }

        // GET: OffersForRents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OffersForRent offersForRent = db.OffersForRents.Find(id);
            if (offersForRent == null)
            {
                return HttpNotFound();
            }
            return View(offersForRent);
        }

        // GET: OffersForRents/Create
        public ActionResult Create()
        {
            ViewBag.OfferId = new SelectList(db.Users, "Id", "FirstName");
            return View();
        }

        // POST: OffersForRents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OfferId,OfferAmount,Accepted")] OffersForRent offersForRent, int? id)
        {
            if (ModelState.IsValid)
            {
              //  var house = db.Houses1.FirstOrDefault(x=>x.Id==id);
                var usr = db.Users.FirstOrDefault(u => u.Email == User.Identity.Name);
                offersForRent.userId = usr.Id;
             
                offersForRent.Id = id;
                db.OffersForRents.Add(offersForRent);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            ViewBag.OfferId = new SelectList(db.Users, "Id", "FirstName", offersForRent.OfferId);
            return View(offersForRent);
        }

        // GET: OffersForRents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OffersForRent offersForRent = db.OffersForRents.Find(id);
            if (offersForRent == null)
            {
                return HttpNotFound();
            }
            ViewBag.OfferId = new SelectList(db.Users, "Id", "FirstName", "userId",  offersForRent.OfferId);
            return View(offersForRent);
        }

        // POST: OffersForRents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OfferId,OfferAmount,Accepted,userId")] OffersForRent offersForRent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(offersForRent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OfferId = new SelectList(db.Users, "Id", "FirstName", offersForRent.OfferId);
            return View(offersForRent);
        }

        // GET: OffersForRents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OffersForRent offersForRent = db.OffersForRents.Find(id);
            if (offersForRent == null)
            {
                return HttpNotFound();
            }
            return View(offersForRent);
        }

        // POST: OffersForRents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            OffersForRent offersForRent = db.OffersForRents.Find(id);
            db.OffersForRents.Remove(offersForRent);
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
            var rented = from x in db.OffersForRents.Where(x => x.Accepted == true) select x;


            db.OffersForRents.RemoveRange(rented);
            db.SaveChanges();
          

            return RedirectToAction(nameof(Index));
        }


    }
}
