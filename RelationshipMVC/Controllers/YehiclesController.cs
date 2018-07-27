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
    public class YehiclesController : Controller
    {
        private MotoristEntities db = new MotoristEntities();

        // GET: Yehicles
        public ActionResult Index()
        {
            return View(db.Yehicles.ToList());
        }

        // GET: Yehicles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Yehicle yehicle = db.Yehicles.Find(id);
            if (yehicle == null)
            {
                return HttpNotFound();
            }
            return View(yehicle);
        }

        // GET: Yehicles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Yehicles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VehicleID,Make,Model,Year")] Yehicle yehicle)
        {
            if (ModelState.IsValid)
            {
                db.Yehicles.Add(yehicle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(yehicle);
        }

        // GET: Yehicles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Yehicle yehicle = db.Yehicles.Find(id);
            if (yehicle == null)
            {
                return HttpNotFound();
            }
            return View(yehicle);
        }

        // POST: Yehicles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VehicleID,Make,Model,Year")] Yehicle yehicle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(yehicle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(yehicle);
        }

        // GET: Yehicles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Yehicle yehicle = db.Yehicles.Find(id);
            if (yehicle == null)
            {
                return HttpNotFound();
            }
            return View(yehicle);
        }

        // POST: Yehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Yehicle yehicle = db.Yehicles.Find(id);
            db.Yehicles.Remove(yehicle);
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
