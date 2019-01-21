using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EventPlanning.Mvc.Models.Entities;

namespace EventPlanning.Mvc.Controllers
{
    [Authorize(Roles = "admin")]
    public class FullNamesController : Controller
    {
        private EventPlanningContext db = new EventPlanningContext();

        // GET: FullNames
        public ActionResult Index()
        {
            return View(db.FullNames.ToList());
        }

        // GET: FullNames/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FullName fullName = db.FullNames.Find(id);
            if (fullName == null)
            {
                return HttpNotFound();
            }
            return View(fullName);
        }

        // GET: FullNames/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FullNames/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FullNameId,LastName,FirstName,SureName")] FullName fullName)
        {
            if (ModelState.IsValid)
            {
                db.FullNames.Add(fullName);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fullName);
        }

        // GET: FullNames/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FullName fullName = db.FullNames.Find(id);
            if (fullName == null)
            {
                return HttpNotFound();
            }
            return View(fullName);
        }

        // POST: FullNames/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FullNameId,LastName,FirstName,SureName")] FullName fullName)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fullName).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fullName);
        }

        // GET: FullNames/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FullName fullName = db.FullNames.Find(id);
            if (fullName == null)
            {
                return HttpNotFound();
            }
            return View(fullName);
        }

        // POST: FullNames/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FullName fullName = db.FullNames.Find(id);
            db.FullNames.Remove(fullName);
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
