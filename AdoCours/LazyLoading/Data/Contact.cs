//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LazyLoading.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Contact
    {
        public Contact()
        {
            this.Telephones = new HashSet<Telephone>();
        }
    
        public int IdContact { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Adresse { get; set; }
        public string Cp { get; set; }
        public string Ville { get; set; }
        public string Email { get; set; }
        public System.DateTime DateNaiss { get; set; }
    
        public virtual ICollection<Telephone> Telephones { get; set; }
    }
}
