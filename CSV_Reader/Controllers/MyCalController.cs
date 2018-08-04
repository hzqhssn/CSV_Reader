using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CSV_Reader.Controllers
{
    public class MyCalController : Controller
    {
        public IActionResult CalPage()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Add()
        {
            try
            {
                int num1 = Convert.ToInt32(HttpContext.Request.Form["Text1"].ToString());
                int num2 = Convert.ToInt32(HttpContext.Request.Form["Text2"].ToString());
                ViewBag.Result = (num1 + num2).ToString();
            }
            catch (Exception)
            {
                ViewBag.Result = "Wrong Input Provided.";
            }
            return View("CalPage");
        }

        [HttpPost]
        public IActionResult Minus()
        {
            try
            {
                int num1 = Convert.ToInt32(HttpContext.Request.Form["Text1"].ToString());
                int num2 = Convert.ToInt32(HttpContext.Request.Form["Text2"].ToString());
                ViewBag.Result = (num1 - num2).ToString();
            }
            catch (Exception)
            {
                ViewBag.Result = "Wrong Input Provided.";
            }
            return View("CalPage");
        }

        [HttpPost]
        public IActionResult Multiply()
        {
            try
            {
                int num1 = Convert.ToInt32(HttpContext.Request.Form["Text1"].ToString());
                int num2 = Convert.ToInt32(HttpContext.Request.Form["Text2"].ToString());
                ViewBag.Result = (num1 * num2).ToString();
            }
            catch (Exception)
            {
                ViewBag.Result = "Wrong Input Provided.";
            }
            return View("CalPage");
        }

        [HttpPost]
        public IActionResult Divide()
        {
            try
            {
                decimal num1 = Convert.ToDecimal(HttpContext.Request.Form["Text1"].ToString());
                decimal num2 = Convert.ToDecimal(HttpContext.Request.Form["Text2"].ToString());
                decimal f = num1 / num2;
                ViewBag.Result = f.ToString();
            }
            catch (Exception)
            {
                ViewBag.Result = "Wrong Input Provided.";
            }
            return View("CalPage");
        }
    }
}