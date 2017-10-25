using System;
using System.Collections.Generic;
using System.Data.Objects.DataClasses;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcedureFunction.Data
{
    partial class Contact
    {
        [EdmFunction("DBContactModel.Store", "ReturnNomContact")]
        public static string ReturnNomContact(int idContact)
        {
            throw new Exception("Erreur");
        }
        
    }
}
