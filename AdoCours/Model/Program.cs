using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Data;
using Model.Repository;
using System.Reflection;
using System.Data.Entity.Infrastructure;
using System.Data.Objects;

namespace Model
{
    class Program
    {
        static private REPContact _repContact;

        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();

            using (DBContactEntities enitites = new DBContactEntities())
            {
                _repContact = new REPContact(enitites);

                Console.WriteLine("Valeur du filtre Contact");
                _repContact.ExtractValueConditionalMapping();

                foreach (Contact co in _repContact.SelectAllContact())
                {
                    sb.Append(string.Concat(co.Nom, " "));
                    sb.Append(string.Concat(co.Cp, " "));
                    sb.Append(string.Concat(co.Ville, " "));
                    sb.Append(string.Concat(co.DateNaiss, " "));
                    sb.AppendLine();
                }
                
                Console.WriteLine(sb);
            }
        }
    }
}
