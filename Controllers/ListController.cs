using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CrudCodeFirst.Data;
using CrudCodeFirst.Models;

namespace CrudCodeFirst.Controllers
{
    public class ListController : Controller
    {
        private ListContext db = new ListContext();

        // GET: List
        public ActionResult Index()
        {
            return View(db.Lists.ToList());
        }

        // GET: List/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ListEntry listEntry = db.Lists.Find(id);
            if (listEntry == null)
            {
                return HttpNotFound();
            }
            return View(listEntry);
        }

        // GET: List/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: List/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Produto,Quantidade,Unidade")] ListEntry listEntry)
        {
            if (ModelState.IsValid)
            {
                db.Lists.Add(listEntry);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(listEntry);
        }

        // GET: List/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ListEntry listEntry = db.Lists.Find(id);
            if (listEntry == null)
            {
                return HttpNotFound();
            }
            return View(listEntry);
        }

        // POST: List/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Produto,Quantidade,Unidade")] ListEntry listEntry)
        {
            if (ModelState.IsValid)
            {
                db.Entry(listEntry).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(listEntry);
        }

        // GET: List/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ListEntry listEntry = db.Lists.Find(id);
            if (listEntry == null)
            {
                return HttpNotFound();
            }
            return View(listEntry);
        }

        // POST: List/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ListEntry listEntry = db.Lists.Find(id);
            db.Lists.Remove(listEntry);
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
