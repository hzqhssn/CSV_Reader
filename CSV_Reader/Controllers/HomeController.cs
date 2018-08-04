using System;
using System.Web;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CSV_Reader.Models;
using System.IO;
using System.Data;

using Microsoft.AspNetCore.Http;
using LumenWorks.Framework.IO.Csv;

namespace CSV_Reader.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(IFormFile upload)
        {
            if (ModelState.IsValid)
            {

                if (upload != null && upload.Length > 0)
                {

                    if (upload.FileName.EndsWith(".csv"))
                    {
                        Stream stream = upload.OpenReadStream();
                        DataTable csvTable = new DataTable();
                        using (CsvReader csvReader =
                            new CsvReader(new StreamReader(stream), true))
                        {
                            csvTable.Load(csvReader);
                        }
                        return View(csvTable);
                    }
                    else
                    {
                        ModelState.AddModelError("File", "This file format is not supported");
                        return View();
                    }
                }
                else
                {
                    ModelState.AddModelError("File", "Please Upload Your file");
                }
            }
            return View();
        }


        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }


        public IActionResult sum()
        {
            return View();
        }

        [HttpPost]
        public IActionResult add()
        {
            int num1 = Convert.ToInt32(HttpContext.Request.Form["txtFirst"].ToString());
            int num2 = Convert.ToInt32(HttpContext.Request.Form["txtSecond"].ToString());
            int result = num1 + num2;
            ViewBag.SumResult = result.ToString();
            return View("sum");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
