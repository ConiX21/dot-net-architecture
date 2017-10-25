using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResultatWCF.ServiceReferenceContact;

namespace ResultatWCF
{
    class Program
    {
        static void Main(string[] args)
        {

            Service1Client srv = new Service1Client();

            foreach (Contact item in srv.AllContact())
            {
                Console.WriteLine(item.Nom);
            }
        }
    }
}
