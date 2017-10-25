using Controler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Controler.Controllers
{
    public class PersonneController : Controller
    {
        // GET: Personne
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Personne(int id)
        {
            var personneViewModel = new PersonneViewModel();
            var p = GetPersonnes().Find(pe => pe.IdPersonne == id);

            personneViewModel.IdPersonne = p.IdPersonne;
            personneViewModel.Nom = p.Nom;
            personneViewModel.Prenom = p.Prenom;
            personneViewModel.Civilite = p.Civilite.Label;

            return View(personneViewModel);

        }

        public JsonResult Personnes()
        {


            return Json(GetPersonnes(), JsonRequestBehavior.AllowGet);
        }

        public List<Personne> GetPersonnes()
        {
            var personnes = new List<Personne>();
            var rnd = new Random();
            for (int i = 0; i < 100; i++)
            {
                personnes.Add(new Models.Personne()
                {
                    Nom = Faker.Name.Last(),
                    Prenom = Faker.Name.First(),
                    IdPersonne = i + 1,
                    Civilite = GetCivilites().Find(c => c.IdCivilite == rnd.Next(1, 2))
                });
            }

            return personnes;
        }

        public List<Civilite> GetCivilites()
        {
            return new List<Civilite>()
            {
                new Civilite() { IdCivilite = 1 , Label = "Monsieur" },
                new Civilite() { IdCivilite = 2 , Label = "Madame" }
            };
        }
    }
}