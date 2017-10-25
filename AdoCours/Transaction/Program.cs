using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Transaction
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                using (TransactionScope t = new TransactionScope())
                {

                    using (DBContactEntities entities = new DBContactEntities())
                    {
                        entities.Contact.Add(new Contact() { Nom = "Botta", Prenom = "Julien", DateNaiss = DateTime.Now });
                        entities.SaveChanges();
                    }

                    //Si une excpetion est levee complete n'est pas appele donc ca rollback
                    t.Complete();
                }

                
            }
            catch (TransactionAbortedException ex)
            {

                Console.WriteLine("Transaction Annuler");
            }
            catch(TransactionException ex)
            {
                Console.WriteLine("Erreur de Transaction");
            } 

            


        }
    }
}
