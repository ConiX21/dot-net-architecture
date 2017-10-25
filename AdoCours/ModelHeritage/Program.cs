using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelHeritage.Repository;

namespace ModelHeritage
{
    class Program
    {
        static private REPEditeurDB _repEditeurDB;
        static private REPEditeurInfo _repEditeurInfo;

        static void Main(string[] args)
        {
            

            using (ModelEditeurContainer enitites = new ModelEditeurContainer())
            {
                /******* fait Heritage toolboox ***************/
                _repEditeurDB = new REPEditeurDB(enitites);

                EditeurDB e = new EditeurDB();

                e.Nom = "oracle";
                e.NbDB = 10;

                _repEditeurDB.AjoutEditeurDB(e);

                /***** Fait BaseType ********/
                _repEditeurInfo = new REPEditeurInfo(enitites);

                EditeurInfo ei = new EditeurInfo();

                ei.Nom = "oracle";
                ei.NbLivre = "25";

                _repEditeurInfo.AjoutEditeurInfo(ei);

            }





        }
    }
}
