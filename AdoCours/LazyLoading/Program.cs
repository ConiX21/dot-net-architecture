using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LazyLoading.Data;
using System.Diagnostics;



namespace LazyLoading
{
    class Program
    {
        static void Main(string[] args)
        {
            //AfficheTout();

            AfficheUnContact2();
            ContactParTelephone();
            Console.ReadLine();
        }

        public static void AfficheTout()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            using (DBContactEntities entities = new DBContactEntities())
            {
                entities.Configuration.LazyLoadingEnabled = false;

                foreach (Contact contacts in entities.Contacts)
                {
                    StringBuilder sb = new StringBuilder();

                    sb.Append(contacts.Nom);
                    sb.Append(" ");
                    sb.Append(contacts.Prenom);
                    sb.Append(" ");
                    sb.Append(contacts.DateNaiss.ToString("dddd MMM yyyy"));
                    sb.Append(Environment.NewLine);
                    sb.Append("phone(s) Number : ");

                    foreach (Telephone telephones in contacts.Telephones)
                    {
                        sb.Append(Environment.NewLine);
                        sb.Append(telephones.Contact.IdContact);
                        sb.Append(" - ");
                        sb.Append(telephones.numero);
                    }

                    Console.WriteLine(sb);
                }

                sw.Stop();
                Console.WriteLine(sw.Elapsed.Milliseconds.ToString());
            }
        }

        public static void AfficheUnContact()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            using (DBContactEntities entities = new DBContactEntities())
            {

                entities.Configuration.LazyLoadingEnabled = false;

                Contact c = entities.Contacts.Include("Telephones").First();


                foreach (Telephone item in c.Telephones)
                {
                    Console.WriteLine(item.numero);
                }

                sw.Stop();
                Console.WriteLine(sw.Elapsed.Milliseconds);
            }
        }

        public static void AfficheUnContact2()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            using (DBContactEntities entities = new DBContactEntities())
            {

                entities.Configuration.LazyLoadingEnabled = false;

                Contact c = entities.Contacts.First();

                /*IQueryable<Contact> c = from co in entities.Contacts
                                        select co;*/

                string result = c.ToString();

                //remonte une collection de navigation (cote many)
                entities.Entry(c).Collection("Telephones").Load();

                foreach (Telephone item in c.Telephones)
                {
                    Console.WriteLine(item.numero);
                }

                //Comptage de donnees en memoires
                Console.WriteLine(entities.Contacts.Local.Count);

                sw.Stop();
                Console.WriteLine(sw.Elapsed.Milliseconds);
            }
        }

        public static void ContactParTelephone()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            using (DBContactEntities entities = new DBContactEntities())
            {
                entities.Configuration.LazyLoadingEnabled = false;

                IQueryable<Telephone> t = entities.Telephones.Where(te => te.idContact == 2);
                                         

                /*IQueryable<Telephone> t = from te in entities.Telephones
                                          where te.idContact == 2
                                          select te;*/

                foreach (Telephone tels in t)
                {
                    //remonte un element de navigation (cote one)
                    entities.Entry(tels).Reference("Contact").Load();
                    Console.WriteLine("Id contact : {0}, numero : {1}", tels.Contact.IdContact, tels.numero);                    
                }

            }

            sw.Stop();
            Console.WriteLine(sw.Elapsed.Milliseconds);

        }


    }
}
