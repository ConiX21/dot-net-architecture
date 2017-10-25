using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProcedureFunction.Data;
using System.Threading.Tasks;
using System.Data.Objects;
using System.Reflection;

namespace ProcedureFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            using (DBContactEntities entities = new DBContactEntities())
            {
                
                //Appel de procédure simple de lecture
                foreach (string item in entities.SelectionContactNom("G"))
                {
                    Console.WriteLine(item);
                }

                //Insert de client
                entities.InsertContact("GERARDO", "Pierre", DateTime.Now);

                Console.WriteLine(entities.InsertContactAndReturn("ZORRO", "DEl la Vega", DateTime.Now).FirstOrDefault());


                //Appel de function scalaire
                Contact co = entities.Contact.Where(c => c.Nom == Contact.ReturnNomContact(15)).First();

                Console.WriteLine(co.Nom);


                //TVFs appel
                foreach (AllContact_Result item in entities.AllContact())
                {
                    Console.WriteLine(item.Nom);
                }

                //TVFs appel avec parametre et complexe type specifique ID 15
                OneContact_Result complexContact = entities.OneContact(15).FirstOrDefault();

                foreach (PropertyInfo item in typeof(OneContact_Result).GetProperties())
                {
                    Console.WriteLine("{0} : {1}", item.Name, item.GetValue(complexContact));
                }
            }
        }
    }
}
