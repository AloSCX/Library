using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library.Controllers
{
    public class CategoryController : Controller
    {
        private static List<GetAllCategory_Result> lstCategories = new List<GetAllCategory_Result>();

        // GET: Category
        public ActionResult Categories()
        {
            using (var ef = new LibraryEntities())
            {
                lstCategories = ef.GetAllCategory().ToList();
            }

            lstCategories = lstCategories.OrderBy(o => o.idCategory).ToList();

            return View(lstCategories);
        }

        private static string[] action;

        [HttpPost]
        public ActionResult Categories(string submit)
        {
            action = submit.Split('.');

            switch (action[0])
            {
                case "New":
                    return RedirectToAction("NewCategory", "Category");

                case "UpdCa":
                    return RedirectToAction("UpdCategory", "Category");

                case "DelCa":
                    using (var ef = new LibraryEntities())
                    {
                        ef.DelCategory(Convert.ToInt32(action[1]));
                    }
                    return RedirectToAction("Categories", "Category");

                default:
                    break;
            }

            return RedirectToAction("Library", "Library");
        }

        public ActionResult NewCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewCategory(GetAllCategory_Result newCategory, string submit)
        {
            if (submit == "SaveNew")
            {
                using (var ef = new LibraryEntities())
                {
                    ef.InsCategory(newCategory.name);
                }
            }

            return RedirectToAction("Categories", "Category");
        }

        public ActionResult UpdCategory()
        {
            if (action != null)
            {
                var updCategory = new GetAllCategory_Result();

                updCategory = lstCategories.Find(f => f.idCategory == Convert.ToInt32(action[1]));

                return View(updCategory);
            }

            return RedirectToAction("Categories", "Category");
        }

        [HttpPost]
        public ActionResult UpdCategory(GetAllCategory_Result updCategory, string submit)
        {
            if (submit == "SaveUpd" && action[0] == "UpdCa")
            {
                using (var ef = new LibraryEntities())
                {
                    ef.UpdCategory(Convert.ToInt32(action[1]), updCategory.name);
                }
            }

            return RedirectToAction("Categories", "Category");
        }
    }
}