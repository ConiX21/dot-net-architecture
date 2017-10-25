using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metadata.Data;
using System.Data.Entity.Validation;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace Metadata.Repository
{
    class REPContact
    {
        private DBContactEntities _enitites;

        public REPContact(DBContactEntities enitites)
        {
            _enitites = enitites;
        }

        public void AddContact(Contact c)
        {
            try
            {
                DbEntityValidationResult vresult = _enitites.Entry(c).GetValidationResult();

                if (vresult.IsValid)
                {
                    _enitites.Contacts.Add(c);
                    _enitites.SaveChanges();
                }
                else
                {
                    //Console.WriteLine(vresult.ValidationErrors.First().ErrorMessage);

                    foreach (DbValidationError item in vresult.ValidationErrors)
                    {
                        Console.WriteLine(item.ErrorMessage);
                    }
                }

            }
            catch (DbEntityValidationException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Errue générale " + ex.Message);
            }
            finally
            {
                Trace.Write("tentative d'ajout");
            }


        }



    }
}
