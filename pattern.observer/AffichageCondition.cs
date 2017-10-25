
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pattern.observer
{
    public class AffichageConditions : Observateur, IAffichable
    {
        private float temperature;
        private float humidite;
        private ISujetable donneesMeteo;
        public AffichageConditions(ISujetable donneesMeteo)
        {
            this.donneesMeteo = donneesMeteo;
            donneesMeteo.enregistrerObservateur(this);
        }
        public void actualiser(float temperature, float humidite, float pression)
        {
            this.temperature = temperature;
            this.humidite = humidite;
            afficher();
        }
        public void afficher()
        {
            Console.Write("Conditions actuelles: " + temperature + " degrés C et " + humidite + " % d’humidité");
        }
    }

}
