using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pattern.observer
{
    class Program
    {
        static void Main(string[] args)
        {
            DonneesMeteo donneesMeteo = new DonneesMeteo();
            AffichageConditions affichageCond = new AffichageConditions(donneesMeteo);
            AffichageStats affichageStat = new AffichageStats(donneesMeteo);
            AffichagePrevisions affichagePrev = new AffichagePrevisions(donneesMeteo);
            donneesMeteo.setMesures(26, 65, 1020);
            donneesMeteo.setMesures(28, 70, 1012);
            donneesMeteo.setMesures(22, 90, 1012);
        }
    }
}
