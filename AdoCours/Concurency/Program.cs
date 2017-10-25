using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concurency
{
    class Program
    {
        static void Main(string[] args)
        {
            using (DBContactEntities entities = new DBContactEntities())
            {
                Contact c = entities.Contact.Find(15);

                c.Nom = "Concurrency";
                c.Prenom = "Conurrency";
                c.DateNaiss = DateTime.Now;

                try
                {
                    entities.SaveChanges();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    Console.WriteLine("eerur");
                    var entry = ex.Entries.Single();
                    var currentValues = entry.CurrentValues;
                    var dataBaseValues = entry.GetDatabaseValues();

                    var resolve = dataBaseValues.Clone();

                    entry.OriginalValues.SetValues(dataBaseValues);
                }

            }
        }
    }
}
