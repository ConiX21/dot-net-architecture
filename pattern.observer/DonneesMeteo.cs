using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pattern.observer
{
    public class DonneesMeteo : ISujetable
    {
        private List<object> observateurs;
        private float temperature;
        private float humidite;
        private float pression;

        public DonneesMeteo()
        {
            observateurs = new List<Object>();
        }
        public void enregistrerObservateur(Observateur o)
        {
            observateurs.Add(o);
        }
        public void supprimerObservateur(Observateur o)
        {
            int i = observateurs.IndexOf(o);
            if (i >= 0)
            {
                observateurs.Remove(i);
            }
        }
        public void notifierObservateurs()
        {
            for (int i = 0; i < observateurs.Count; i++)
            {
                Observateur observateur = (Observateur)observateurs.ElementAt(i);
                observateur.actualiser(temperature, humidite, pression);
            }
        }
        public void actualiserMesures()
        {
            notifierObservateurs();
        }
        public void setMesures(float temperature, float humidite, float pression)
        {
            this.temperature = temperature;
            this.humidite = humidite;
            this.pression = pression;
            actualiserMesures();
        }
        // autres méthodes de DonneesMeteo
    }
}
