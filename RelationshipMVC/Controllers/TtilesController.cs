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
    public class TtilesController : Controller
    {
        private MotoristEntities db = new MotoristEntities();

        // GET: Ttiles
        public ActionResult Index()
        {
            var ttiles = db.Ttiles.Include(t => t.Driver).Include(t => t.Yehicle);
            return View(ttiles.ToList());
        }

        // GET: Ttiles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ttile ttile = db.Ttiles.Find(id);
            if (ttile == null)
            {
                return HttpNotFound();
            }
            return View(ttile);
        }

        // GET: Ttiles/Create
        public ActionResult Create()
        {
            ViewBag.DriverID = new SelectList(db.Drivers, "DriverID", "DriverName");
            ViewBag.VehicleID = new SelectList(db.Yehicles, "VehicleID", "Make");
            return View();
        }

        // POST: Ttiles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TitleID,VehicleID,DriverID,DateTitled")] Ttile ttile)
        {
            if (ModelState.IsValid)
            {
                db.Ttiles.Add(ttile);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DriverID = new SelectList(db.Drivers, "DriverID", "DriverName", ttile.DriverID);
            ViewBag.VehicleID = new SelectList(db.Yehicles, "VehicleID", "Make", ttile.VehicleID);
            return View(ttile);
        }

        // GET: Ttiles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ttile ttile = db.Ttiles.Find(id);
            if (ttile == null)
            {
                return HttpNotFound();
            }
            ViewBag.DriverID = new SelectList(db.Drivers, "DriverID", "DriverName", ttile.DriverID);
            ViewBag.VehicleID = new SelectList(db.Yehicles, "VehicleID", "Make", ttile.VehicleID);
            return View(ttile);
        }

        // POST: Ttiles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TitleID,VehicleID,DriverID,DateTitled")] Ttile ttile)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ttile).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DriverID = new SelectList(db.Drivers, "DriverID", "DriverName", ttile.DriverID);
            ViewBag.VehicleID = new SelectList(db.Yehicles, "VehicleID", "Make", ttile.VehicleID);
            return View(ttile);
        }

        // GET: Ttiles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ttile ttile = db.Ttiles.Find(id);
            if (ttile == null)
            {
                return HttpNotFound();
            }
            return View(ttile);
        }

        // POST: Ttiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ttile ttile = db.Ttiles.Find(id);
            db.Ttiles.Remove(ttile);
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
