using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Navigation.Data;
using System.Diagnostics;

namespace Navigation
{
    class Program
    {
        static void Main(string[] args)
        {
            ListerContactTel();

        }

        public static Contact SelectOneContact(int idContact)
        {
            using (DBContactEntities enitites = new DBContactEntities())
            {
                return enitites.Contact.Where(c => c.IdContact == idContact).First();
            }
        }

        public static void AddTel(Contact c, string numero)
        {
            using (DBContactEntities entities = new DBContactEntities())
            {
                entities.Contact.Attach(c);
                c.Telephone.Add(new Telephone() { numero = numero });
                entities.SaveChanges();
            }
        }

        public static void ListerContactTel()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            using (DBContactEntities entities = new DBContactEntities())
            {

                foreach (Contact contacts in entities.Contact)
                {
                    Console.WriteLine("Nom : {0}", contacts.Nom);

                    foreach (Telephone telephones in contacts.Telephone)
                    {
                        Console.WriteLine("Numero : {0}", telephones.numero);
                    }
                }
            }

            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);
        }
    }
}
