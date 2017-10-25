using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pattern.observer
{
    public interface Observateur
    {
        void actualiser(float temp, float humidite, float pression);
    }
}
