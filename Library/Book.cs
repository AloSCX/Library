//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Library
{
    using System;
    using System.Collections.Generic;
    
    public partial class Book
    {
        public int idBook { get; set; }
        public string name { get; set; }
        public string authors { get; set; }
        public System.DateTime year { get; set; }
        public string theme { get; set; }
        public int idCategory { get; set; }
        public System.DateTime insertDate { get; set; }
        public Nullable<System.DateTime> modifyDate { get; set; }
    
        public virtual Category Category { get; set; }
    }
}
