using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library.Models
{
    public class Library
    {
        public GetAllBook_Result book { get; set; }
        public List<GetAllCategory_Result> lstCategories { get; set; }
    }
}