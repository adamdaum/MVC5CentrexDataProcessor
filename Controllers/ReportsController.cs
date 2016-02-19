using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using MVC5CentrexDataProcessor.Models;
using MVC5CentrexDataProcessor.ViewModels;

namespace MVC5CentrexDataProcessor.Controllers
{
    public class ReportsController : Controller
    {

        private CentrexEntities db = new CentrexEntities();


        // GET: /Reports
        public ActionResult Index()
        {

            return View();
        }


        [HttpPost]
        // POST: /Reports
        public ActionResult Index(string searchString, string recordType)
        {


            if (recordType == "09")
            {
               

                return View(Record09Report(searchString));
            }

            if (recordType == "10")
            {
                var records = db.Record10.ToList();

                if (!string.IsNullOrEmpty(searchString))
                {
                    records = db.Record10.Where(r => r.Telephone_Number.Contains(searchString)).ToList();
                }

                return View("Record10Report", records);
               
            }


            return View();
        }

        public ActionResult Record09Report(string searchString)
        {
            var records = db.Record09.ToList();

            if (!string.IsNullOrEmpty(searchString))
            {
                records = db.Record09.Where(r => r.Telephone_Number.Contains(searchString)).ToList();
            }

            return View(records);
        }

        // GET: /Reports/Record10Report
        public ActionResult Record10Report() 
        {
            return View();
        }



        // GET: /Reports/Details/5
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



	}
}