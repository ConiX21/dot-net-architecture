using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metadata.Data;
using Metadata.Repository;

namespace Metadata
{
    class Program
    {
        static private DBContactEntities _entities;
        static private REPContact _repContact;

        static void Main(string[] args)
        {
            using (_entities = new DBContactEntities())
            {
                _repContact = new REPContact(_entities);

                Contact c = new Contact();

                c.Nom = "gasquet";
                c.Prenom = "Nicolas";
                c.DateNaiss = new DateTime(1981, 06, 21);
                c.Cp = "85";
                c.Email = "ngs@ee.fr";

                _repContact.AddContact(c);
            }

        }
    }
}
