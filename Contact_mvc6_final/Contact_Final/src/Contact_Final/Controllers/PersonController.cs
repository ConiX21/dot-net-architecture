using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Contact.DATA.Models;
using Contact.DATA.Repository;
using Contact_Final.Models;
using Contact_Final.Services;

namespace Contact_Final.Controllers
{
    [Route("people")]
    public class PersonController : Controller
    {
        private IPersonRepository _repository;
        private IGenderService _genderService;

        public PersonController(IPersonRepository repository, IGenderService genderService)
        {
            _repository = repository;
            _genderService = genderService;
        }


        [Route("people-list")]
        public IActionResult Index()
        {
            IEnumerable<Person> persons = new List<Person>();

            try
            {
                persons = _repository.GetAll();
                return View(persons);
            }
            catch (Exception)
            {
                return View(persons);
            }


        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpGet]
        [Route("person/[action]/{id:int}")]
        //[Route("{controller}/{action}/{int:id}")]
        public IActionResult Details(int id)
        {
            Person person = new Person();

            try
            {
                person = _repository.Find(id);
                //ViewData["SerializedPerson"] = new ObjectResult(person).Value.ToString();
                return View(person);
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }


        }

        [HttpGet]
        [Route("[action]/{id:int}")]
        public IActionResult Edit(int id)
        {
            PersonViewModel personViewModel = new PersonViewModel();
            try
            {
                personViewModel.Person = _repository.Find(id);
                personViewModel.Genders = _genderService.GetAll();
                return View(personViewModel);
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(PersonViewModel personViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Person person = personViewModel.Person;
                    _repository.Update(person);
                    return RedirectToAction("Index");
                }
                else
                {
                    throw new Exception();
                }
            }
            catch
            {
                return View();
            }
        }


    }
}