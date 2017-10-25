using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdoCours.Data
{
    
    partial class Contact
    {
        public Contact(string nom, string prenom,DateTime dateNaiss)
        {
            this.Nom = nom;
            this.Prenom = prenom;
            this.DateNaiss = dateNaiss;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(this.Nom);
            sb.Append(" ");
            sb.Append(this.Prenom);
            sb.Append(" ");
            sb.Append(this.Adresse);
            sb.Append(" "); 
            sb.Append(this.Cp);
            sb.Append(" ");
            sb.Append(this.Ville);
            sb.Append(" ");
            sb.Append(this.Email);
            sb.Append(" ");
            sb.Append(this.DateNaiss);


            return sb.ToString();
        }

    }
}
