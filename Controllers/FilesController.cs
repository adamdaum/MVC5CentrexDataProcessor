using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5CentrexDataProcessor.Models;

namespace MVC5CentrexDataProcessor.Controllers
{
    [Authorize]
    public class FilesController : Controller
    {
        private CentrexEntities db = new CentrexEntities();

        // GET: /Files/Import
        public ActionResult Import()
        {
            return View();
        }

        // POST: /Files/Import
        [HttpPost]
        public ActionResult Import(HttpPostedFileBase file)
        {
            if (file == null || file.ContentLength <= 0) return View();

            // Save the file
            var fileName = Path.GetFileName(file.FileName);
            var fileExtension = fileName.Substring(fileName.LastIndexOf(".") + 1);
            var fullPath = Path.Combine(Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["Uploads"]),
                fileName.Substring(0, fileName.LastIndexOf(".")) + "_" + DateTime.Now.ToString("mmddYYY") + "." + fileExtension);
            file.SaveAs(fullPath);

            // Insert the file into the database
            using (var reader = new StreamReader(fullPath))
            {
                var line = "";
                while ((line = reader.ReadLine()) != null)
                {
                    var lineItems = line.Split("|".ToCharArray());

                    switch (lineItems[0])
                    {

                        case "07":
                            //ProcessRecord07(lineItems);
                            break;

                        case "09":
                            // Process record 09
                            ProcessRecord09(lineItems);
                            break;

                        case "10":
                            // Process record 10
                            ProcessRecord10(lineItems);
                            break;

                        case "12":
                            //ProcessRecord12(lineItems);
                            break;

                    }

                }

            }

            db.SaveChanges();

            return View();
        }

        private void ProcessRecord07(string[] lineItems)
        {
            throw new NotImplementedException();
        }

        private void ProcessRecord09(string[] lineItems)
        {
            //throw new NotImplementedException();

            decimal decimalCallCost = 0;
            decimal.TryParse(lineItems[5].Trim(), out decimalCallCost);

            var record09 = new Record09
            {
                Record_Type = lineItems[0].Trim(),
                Billing_Telephone_Number = lineItems[1].Trim(),
                Call_Date = lineItems[2].Trim(),
                Call_Time = lineItems[3].Trim(),
                Call_Duration_Seconds = lineItems[4].Trim(),
                Call_Cost = decimalCallCost,
                From_Number = lineItems[6].Trim(),
                From_City = lineItems[7].Trim(),
                To_Number = lineItems[8].Trim(),
                To_City = lineItems[9].Trim(),
                Call_Type = lineItems[10].Trim(),
                Usage_Type = lineItems[11].Trim(),
                Auth_Code = lineItems[12].Trim(),
                Call_Count = lineItems[13].Trim(),
                Carrier = lineItems[14].Trim(),
                Telephone_Number = lineItems[15].Trim(),
                Provider_Name = lineItems[16].Trim(),
                Rate_Period = lineItems[17].Trim(),
                From_State = lineItems[18].Trim(),
                To_State = lineItems[19].Trim(),
                Invoice_Number = lineItems[20].Trim()
            };

            db.Record09.Add(record09);
        }

        private void ProcessRecord10(string[] lineItems)
        {
            decimal decimalAmount = 0;
            decimal.TryParse(lineItems[4].Trim(), out decimalAmount);
            var record10 = new Record10
            {
                Record_Type = lineItems[0].Trim(),
                Billing_Telephone_Number = lineItems[1].Trim(),
                Number_of_Calls = lineItems[2].Trim(),
                Number_of_Seconds = lineItems[3].Trim(),
                Amount = decimalAmount,
                Invoice_Number = lineItems[5].Trim(),
                Telephone_Number = lineItems[6].Trim()
            };

            db.Record10.Add(record10);

            //throw new NotImplementedException();

        }

        private void ProcessRecord12(string[] lineItems)
        {
            throw new NotImplementedException();

        }


      


       

	}
}