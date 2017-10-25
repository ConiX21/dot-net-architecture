using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AdoCours.Data;
using System.Data.Entity.Validation;
using System.Globalization;
using System.Reflection;
using System.Diagnostics;

namespace AdoCours
{
    class Program
    {
        static void Main(string[] args)
        {
            InsertRead();
        }

        static public void InsertRead()
        {
            using (ModelCoursContainer entities = new ModelCoursContainer())
            {
                Contact c = new Contact("GASQUET", "NICOLAS", Convert.ToDateTime("21/06/1981", new CultureInfo("fr-FR")));

                //Console.WriteLine(Convert.ToDateTime("21/06/1981", new CultureInfo("fr-FR")));

                DateTime t = new DateTime();

                if (t.GetType() == typeof(DateTime))
                {
                    Console.WriteLine("oo");
                }

                try
                {
                    entities.Contact.Add(c);

                    if (entities.SaveChanges() == 0)
                    {
                        Console.WriteLine("Erreur de validation");
                    }

                    foreach (Contact item in entities.Contact)
                    {
                        Console.WriteLine("{0} {1} {2}", item.Nom, item.Prenom, item.DateNaiss);
                    }
                }
                catch (DbEntityValidationException e)
                {

                    Console.WriteLine(e.Message);
                }



                Console.WriteLine("Id a supprimer");
                DeleteContact(int.Parse(Console.ReadLine()));

            }
        }

        static public void DeleteContact(int idContact)
        {
            using (ModelCoursContainer entities = new ModelCoursContainer())
            {

                Contact c = entities.Contact.Where(co => co.IdContact == idContact).First();

                Contact c1 = (from co in entities.Contact
                             where co.IdContact == idContact
                             select co).First();

                entities.Contact.Remove(c1);

                entities.SaveChanges();

                
            }
        }

        static public void Update(Contact c)
        {
            using (ModelCoursContainer entities = new ModelCoursContainer())
            {
                entities.Contact.Attach(c);

                foreach (PropertyInfo item in c.GetType().GetProperties())
                {
                    if (!item.Name.StartsWith("Id"))
                    {
                        Console.WriteLine("{0} :", item.Name);

                        if (item.GetValue(c, null) != null && item.GetValue(c, null).GetType() == typeof(DateTime))
                        {
                            item.SetValue(c, Convert.ToDateTime(Console.ReadLine(), new CultureInfo("fr-FR")), null);

                            continue;
                        }

                        item.SetValue(c, Console.ReadLine(), null);

                    }
                }

                entities.SaveChanges();
            }
        }
    }
}
