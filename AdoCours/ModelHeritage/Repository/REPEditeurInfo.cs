using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelHeritage.Repository
{
    class REPEditeurInfo
    {
        private ModelEditeurContainer _entities;

        public REPEditeurInfo(ModelEditeurContainer entities)
        {
            _entities = entities;
        }

        public void AjoutEditeurInfo(EditeurInfo edb)
        {
            _entities.Editeur.Add(edb);
            _entities.SaveChanges();
        }
    }
}
