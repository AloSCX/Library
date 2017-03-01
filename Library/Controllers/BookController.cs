using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library.Controllers
{
    public class BookController : Controller
    {
        private static List<GetAllBook_Result> lstBooks = new List<GetAllBook_Result>();
        private static List<GetAllCategory_Result> lstCategories = new List<GetAllCategory_Result>();

        // GET: Book
        public ActionResult Books()
        {
            using (var ef = new LibraryEntities())
            {
                lstBooks = ef.GetAllBook().ToList();
                lstCategories = ef.GetAllCategory().ToList();
            }

            lstBooks = lstBooks.OrderBy(o => o.idBook).ToList();

            return View(lstBooks);
        }

        private static string[] action;

        [HttpPost]
        public ActionResult Books(string submit)
        {
            action = submit.Split('.');

            switch (action[0])
            {
                case "New":
                    return RedirectToAction("NewBook", "Book");

                case "UpdBk":
                    return RedirectToAction("UpdBook", "Book");

                case "DelBk":
                    using (var ef = new LibraryEntities())
                    {
                        ef.DelCategory(Convert.ToInt32(action[1]));
                    }
                    return RedirectToAction("Books", "Book");

                case "Sort":
                    switch (action[1])
                    {
                        case "id":
                            lstBooks = lstBooks.OrderBy(o => o.idBook).ToList();
                            break;

                        case "name":
                            lstBooks = lstBooks.OrderBy(o => o.name).ToList();
                            break;

                        case "author":
                            lstBooks = lstBooks.OrderBy(o => o.authors).ToList();
                            break;

                        case "theme":
                            lstBooks = lstBooks.OrderBy(o => o.theme).ToList();
                            break;

                        case "year":
                            lstBooks = lstBooks.OrderBy(o => o.year).ToList();
                            break;

                        case "category":
                            lstBooks = lstBooks.OrderBy(o => o.catName).ToList();
                            break;

                        default:
                            break;
                    }
                    return View(lstBooks);

                default:
                    break;
            }

            return RedirectToAction("Library", "Library");
        }

        public ActionResult NewBook()
        {
            var library = new Models.Library();

            using (var ef = new LibraryEntities())
            {
                library.lstCategories = ef.GetAllCategory().ToList();
            }

            return View(library);
        }

        [HttpPost]
        public ActionResult NewBook(Models.Library library, string submit)
        {
            if (submit == "SaveNew")
            {
                var newBook = library.book;

                using (var ef = new LibraryEntities())
                {
                    ef.InsBook(newBook.name, newBook.authors, newBook.year, newBook.theme, newBook.idCategory);
                }
            }

            return RedirectToAction("Books", "Book");
        }

        public ActionResult UpdBook()
        {
            if (action != null)
            {
                var library = new Models.Library();

                library.book = lstBooks.Find(f => f.idBook == Convert.ToInt32(action[1]));
                library.lstCategories = lstCategories;

                return View(library);
            }

            return RedirectToAction("Books", "Book");
        }

        [HttpPost]
        public ActionResult UpdBook(GetAllBook_Result updBook, string submit)
        {
            if (submit == "SaveUpd" && action[0] == "UpdBk")
            {
                using (var ef = new LibraryEntities())
                {
                    ef.UpdBook(Convert.ToInt32(action[1]), updBook.name,updBook.authors, updBook.year, updBook.theme, updBook.idCategory);
                }
            }

            return RedirectToAction("Books", "Book");
        }
    }
}