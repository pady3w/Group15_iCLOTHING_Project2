﻿using Group15_iCLOTHINGApp.Models;
using System;
using System.Data.Entity;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Group15_iCLOTHINGApp.Controllers
{
    public class DepartmentController : Controller
    {
        private Group15_iCLOTHINGDBEntities db = new Group15_iCLOTHINGDBEntities();

        // GET: Departments
        public ActionResult Index()
        {
            return View(db.Department.ToList());
        }

        // GET: Departments/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department department = db.Department.Find(id);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }

        // GET: Departments/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Departments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "departmentName,departmentDescription")] Department department)
        {
            if (ModelState.IsValid)
            {
                Random rnd = new Random();
                department.departmentID = rnd.Next(1000, 9999).ToString();
                db.Department.Add(department);
                db.SaveChanges();
                return RedirectToAction("MaintainCatalog", "Administrator");
            }

            return View(department);
        }

        // GET: Departments/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department department = db.Department.Find(id);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }

        // POST: Departments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "departmentID,departmentName,departmentDescription")] Department department)
        {
            if (ModelState.IsValid)
            {
                Department department2 = db.Department.Find(department.departmentID);
                department2.departmentName = department.departmentName;
                department2.departmentDescription = department.departmentDescription;
                db.Entry(department2).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("MaintainCatalog", "Administrator");
            }
            return View(department);
        }

        // GET: Departments/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department department = db.Department.Find(id);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }

        // POST: Departments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Department department = db.Department.Find(id);
            db.Department.Remove(department);
            db.SaveChanges();
            return RedirectToAction("MaintainCatalog", "Administrator");
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
