using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pattern.observer
{
    public interface ISujetable
      {
        void enregistrerObservateur(Observateur o);
        void supprimerObservateur(Observateur o);
        void notifierObservateurs();
    }
}
