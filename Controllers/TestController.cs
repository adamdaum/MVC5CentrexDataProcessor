using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC5CentrexDataProcessor.Models;

namespace MVC5CentrexDataProcessor.Controllers
{
    public class TestController : Controller
    {
        private CentrexEntities db = new CentrexEntities();

        // GET: /Test/
        public ActionResult Index()
        {
            return View(db.Record10.ToList());
        }

        // GET: /Test/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Record10 record10 = db.Record10.Find(id);
            if (record10 == null)
            {
                return HttpNotFound();
            }
            return View(record10);
        }

        // GET: /Test/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Test/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Record_Type,Billing_Telephone_Number,Number_of_Calls,Number_of_Seconds,Amount,Invoice_Number,Telephone_Number")] Record10 record10)
        {
            if (ModelState.IsValid)
            {
                db.Record10.Add(record10);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(record10);
        }

        // GET: /Test/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Record10 record10 = db.Record10.Find(id);
            if (record10 == null)
            {
                return HttpNotFound();
            }
            return View(record10);
        }

        // POST: /Test/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Record_Type,Billing_Telephone_Number,Number_of_Calls,Number_of_Seconds,Amount,Invoice_Number,Telephone_Number")] Record10 record10)
        {
            if (ModelState.IsValid)
            {
                db.Entry(record10).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(record10);
        }

        // GET: /Test/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Record10 record10 = db.Record10.Find(id);
            if (record10 == null)
            {
                return HttpNotFound();
            }
            return View(record10);
        }

        // POST: /Test/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Record10 record10 = db.Record10.Find(id);
            db.Record10.Remove(record10);
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
