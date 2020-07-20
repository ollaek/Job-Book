using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Job_Book.Models;

namespace Job_Book.Controllers
{
    public class RoleViewModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: RoleViewModels
        public ActionResult Index()
        {
            return View(db.RoleViewModels.ToList());
        }

        // GET: RoleViewModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoleViewModels roleViewModels = db.RoleViewModels.Find(id);
            if (roleViewModels == null)
            {
                return HttpNotFound();
            }
            return View(roleViewModels);
        }

        // GET: RoleViewModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RoleViewModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Name")] RoleViewModels roleViewModels)
        {
            if (ModelState.IsValid)
            {
                db.RoleViewModels.Add(roleViewModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(roleViewModels);
        }

        // GET: RoleViewModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoleViewModels roleViewModels = db.RoleViewModels.Find(id);
            if (roleViewModels == null)
            {
                return HttpNotFound();
            }
            return View(roleViewModels);
        }

        // POST: RoleViewModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Name")] RoleViewModels roleViewModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(roleViewModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(roleViewModels);
        }

        // GET: RoleViewModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoleViewModels roleViewModels = db.RoleViewModels.Find(id);
            if (roleViewModels == null)
            {
                return HttpNotFound();
            }
            return View(roleViewModels);
        }

        // POST: RoleViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RoleViewModels roleViewModels = db.RoleViewModels.Find(id);
            db.RoleViewModels.Remove(roleViewModels);
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
