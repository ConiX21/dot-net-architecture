//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OneTableMultipleEntity
{
    using System;
    using System.Collections.Generic;
    
    public partial class Auteur
    {
        public Auteur()
        {
            this.Publication = new HashSet<Publication>();
        }
    
        public int IdAuteur { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Adresse { get; set; }
        public string CP { get; set; }
        public string Ville { get; set; }
    
        public virtual ICollection<Publication> Publication { get; set; }
    }
}