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
    public class OffersForSalesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: OffersForSales
        public ActionResult Index(string searchString)
        {
            // var offersForSales = db.OffersForSales.Include(o => o.user);

            var offers = from o in db.OffersForSales
                         select o;
            if (!String.IsNullOrEmpty(searchString))
            {
                offers = offers.Where(x => x.house.Address.Contains(searchString));

            }

            return View(offers.ToList());
        }

        // GET: OffersForSales/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OffersForSale offersForSale = db.OffersForSales.Find(id);
            if (offersForSale == null)
            {
                return HttpNotFound();
            }
            return View(offersForSale);
        }

        // GET: OffersForSales/Create
        public ActionResult Create()
        {
            ViewBag.OfferId = new SelectList(db.Users, "Id", "FirstName");
            return View();
        }

        // POST: OffersForSales/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OfferId,OfferAmount,Accepted")] OffersForSale offersForSale, int? id)
        {
            if (ModelState.IsValid)
            {
                
                var usr = db.Users.FirstOrDefault(u => u.Email == User.Identity.Name);
                offersForSale.userId = usr.Id;
                offersForSale.Id = id;
                //offersForSale.OfferId = usr.Id;
                db.OffersForSales.Add(offersForSale);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            ViewBag.OfferId = new SelectList(db.Users, "Id", "FirstName", offersForSale.OfferId);
            return View(offersForSale);
        }

        // GET: OffersForSales/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OffersForSale offersForSale = db.OffersForSales.Find(id);
            if (offersForSale == null)
            {
                return HttpNotFound();
            }
            ViewBag.OfferId = new SelectList(db.Users, "Id", "FirstName", "userId", offersForSale.OfferId);
            return View(offersForSale);
        }

        // POST: OffersForSales/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OfferId,OfferAmount,Accepted,userId")] OffersForSale offersForSale)
        {
            if (ModelState.IsValid)
            {
                db.Entry(offersForSale).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OfferId = new SelectList(db.Users, "Id", "FirstName", offersForSale.OfferId);
            return View(offersForSale);
        }

        // GET: OffersForSales/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OffersForSale offersForSale = db.OffersForSales.Find(id);
            if (offersForSale == null)
            {
                return HttpNotFound();
            }
            return View(offersForSale);
        }

        // POST: OffersForSales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OffersForSale offersForSale = db.OffersForSales.Find(id);
            db.OffersForSales.Remove(offersForSale);
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

        public ActionResult deleteSold()
        {
            var sold = from x in db.OffersForSales.Where(x => x.Accepted == true) select x;


            db.OffersForSales.RemoveRange(sold);
            db.SaveChanges();


            return RedirectToAction(nameof(Index));
        }
    }
}
