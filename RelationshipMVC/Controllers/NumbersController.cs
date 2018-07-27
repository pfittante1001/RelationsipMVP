using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RelationshipMVC;

namespace RelationshipMVC.Controllers
{
    public class NumbersController : Controller
    {
        private MotoristEntities db = new MotoristEntities();

        // GET: Numbers
        public ActionResult Index()
        {
            var numbers = db.Numbers.Include(n => n.Driver);
            return View(numbers.ToList());
        }

        // GET: Numbers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Number number = db.Numbers.Find(id);
            if (number == null)
            {
                return HttpNotFound();
            }
            return View(number);
        }

        // GET: Numbers/Create
        public ActionResult Create()
        {
            ViewBag.DriverID = new SelectList(db.Drivers, "DriverID", "DriverName");
            return View();
        }

        // POST: Numbers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LicenseNumberID,Number1,DriverID")] Number number)
        {
            if (ModelState.IsValid)
            {
                db.Numbers.Add(number);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DriverID = new SelectList(db.Drivers, "DriverID", "DriverName", number.DriverID);
            return View(number);
        }

        // GET: Numbers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Number number = db.Numbers.Find(id);
            if (number == null)
            {
                return HttpNotFound();
            }
            ViewBag.DriverID = new SelectList(db.Drivers, "DriverID", "DriverName", number.DriverID);
            return View(number);
        }

        // POST: Numbers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LicenseNumberID,Number1,DriverID")] Number number)
        {
            if (ModelState.IsValid)
            {
                db.Entry(number).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DriverID = new SelectList(db.Drivers, "DriverID", "DriverName", number.DriverID);
            return View(number);
        }

        // GET: Numbers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Number number = db.Numbers.Find(id);
            if (number == null)
            {
                return HttpNotFound();
            }
            return View(number);
        }

        // POST: Numbers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Number number = db.Numbers.Find(id);
            db.Numbers.Remove(number);
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
