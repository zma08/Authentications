﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AuthenticationPractice.Models;

namespace AuthenticationPractice.Controllers
{
    public class PiratesController : Controller
    {
        private PirateContext db = new PirateContext();

        // GET: Pirates
        public ActionResult Index()
        {
            return View(db.Pirates.ToList());
        }

        // GET: Pirates/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pirate pirate = db.Pirates.Find(id);
            if (pirate == null)
            {
                return HttpNotFound();
            }
            return View(pirate);
        }

        // GET: Pirates/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pirates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Date")] Pirate pirate)
        {
            if (ModelState.IsValid)
            {
                db.Pirates.Add(pirate);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pirate);
        }

        // GET: Pirates/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pirate pirate = db.Pirates.Find(id);
            if (pirate == null)
            {
                return HttpNotFound();
            }
            return View(pirate);
        }

        // POST: Pirates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Date")] Pirate pirate)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pirate).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pirate);
        }

        // GET: Pirates/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pirate pirate = db.Pirates.Find(id);
            if (pirate == null)
            {
                return HttpNotFound();
            }
            return View(pirate);
        }

        // POST: Pirates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pirate pirate = db.Pirates.Find(id);
            db.Pirates.Remove(pirate);
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
