using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SelfTracking.Data;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;

namespace SelfTracking
{
    class Program
    {
        static void Main(string[] args)
        {
            Contact c = SelectOne(2);

            c.Nom = "MY NEW NAME";

            UpdateContact(c);
            //Update2(c);
           // Affiche();
        }


        static public Contact SelectOne(int idContact)
        {
            using (DBContactEntities enitites = new DBContactEntities())
            {
                return enitites.Contacts.Where(co => co.IdContact == idContact).First();
            }

        }

        static public void UpdateContact(Contact c)
        {
            using (DBContactEntities entities = new DBContactEntities())
            {

                entities.Entry(c).State = System.Data.Entity.EntityState.Modified;

                Console.WriteLine(entities.Entry(c).State);

                Console.WriteLine("DataBase Values :");
                PrintProp(entities.Entry(c).GetDatabaseValues());

                Console.WriteLine("Current Values :");
                PrintProp(entities.Entry(c).CurrentValues);

                entities.SaveChanges();

            }
        }

        static public void PrintProp(DbPropertyValues prop)
        {
            foreach (var values in prop.PropertyNames)
            {
                Console.WriteLine("{0} : {1} ", values, prop[values]);
            }
        }

        public static void Affiche()
        {
            using (DBContactEntities entities = new DBContactEntities())
            {
                //Execurte une requete SQL
                List<Contact> lstContact = entities.Contacts.SqlQuery(@"SELECT * FROM Contact").ToList<Contact>();

                foreach (Contact item in lstContact)
                {
                    Console.WriteLine(item.IdContact);
                }
            }
        }

        public static void Update2(Contact c)
        {
            using (DBContactEntities entities = new DBContactEntities())
            {
                //Classe de performances
                Stopwatch sw = new Stopwatch();
                sw.Start();

                //Pour les performances desactiver Le tracking pourpasser en self
                entities.Configuration.AutoDetectChangesEnabled = false;

                entities.Contacts.Attach(c);

                Console.WriteLine(entities.Entry(c).State);

                c.Adresse = "NEW ADRESS";

                Console.WriteLine(entities.Entry(c).State);

                entities.SaveChanges();

                //Affiche les performances
                sw.Stop();
                Console.WriteLine(sw.Elapsed.TotalMilliseconds.ToString());

            }


        }
    }
}
