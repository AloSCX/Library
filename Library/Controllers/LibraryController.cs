using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library.Controllers
{
    public class LibraryController : Controller
    {
        // GET: Library
        public ActionResult Library()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Library(string submit)
        {
            switch (submit)
            {
                case "Books":
                    return RedirectToAction("Books", "Book");

                case "Categories":
                    return RedirectToAction("Categories", "Category");

                default:
                    break;
            }

            return View();
        }
    }
}