using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Stateemo.Data;
using Stateemo.Models;

namespace Stateemo.Controllers
{
    public class RoleManagerController : Controller
    {
        private StateemoContext db = new StateemoContext();
        
        [AllowAnonymous]
        // GET: RoleManager
        public ActionResult Index()
        {
            return View(db.RoleModels.ToList());
        }

        [AllowAnonymous]
        // GET: RoleManager/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoleModel roleModel = db.RoleModels.Find(id);
            if (roleModel == null)
            {
                return HttpNotFound();
            }
            return View(roleModel);
        }

        [Authorize(Roles = "Admin")]
        // GET: RoleManager/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RoleManager/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description")] RoleModel roleModel)
        {
            if (ModelState.IsValid)
            {
                db.RoleModels.Add(roleModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(roleModel);
        }

        [Authorize(Roles = "Admin, Editor")]
        // GET: RoleManager/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoleModel roleModel = db.RoleModels.Find(id);
            if (roleModel == null)
            {
                return HttpNotFound();
            }
            return View(roleModel);
        }

        // POST: RoleManager/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description")] RoleModel roleModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(roleModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(roleModel);
        }

        // GET: RoleManager/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoleModel roleModel = db.RoleModels.Find(id);
            if (roleModel == null)
            {
                return HttpNotFound();
            }
            return View(roleModel);
        }

        // POST: RoleManager/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RoleModel roleModel = db.RoleModels.Find(id);
            db.RoleModels.Remove(roleModel);
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
