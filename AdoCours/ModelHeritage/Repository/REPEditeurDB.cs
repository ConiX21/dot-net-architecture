using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelHeritage;

namespace ModelHeritage.Repository
{
    

    class REPEditeurDB
    {

        private ModelEditeurContainer _entities;

        public REPEditeurDB(ModelEditeurContainer entities)
        {
            _entities = entities;
        }

        public void AjoutEditeurDB(EditeurDB edb)
        {
            _entities.Editeur.Add(edb);
            _entities.SaveChanges();
        }
    }
}
