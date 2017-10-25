using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneTableMultipleEntity
{
    class Program
    {
        static void Main(string[] args)
        {
            //Deplacement des proprite de l'entite coordonnee dans l'entite de Auteur pour 
            //une relation one to one
            //Penser au mapping de champs dans la table auteur

            using (DBPublicationEntities entities = new DBPublicationEntities())
            {
                entities.Auteur.Add(new Auteur()
                {
                    Nom = "GASQUET",
                    Adresse = "34 route",
                    Ville = "Rians",
                    Prenom = "Nicolas",
                    CP = "83560"
                });

                entities.SaveChanges();
            }
        }
    }
}
