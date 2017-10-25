using Contact.DATA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contact.DATA.Repository
{
    public class PersonRepository : IPersonRepository
    {

        private MVC6_PersonContext _context;

        public PersonRepository(MVC6_PersonContext context)
        {
            _context = context;
        }

        public void Add(Person person)
        {
            _context.Person.Add(person);
            _context.SaveChanges();
        }

        public Person Find(int idPerson)
        {
            return _context.Person.Where(p => p.IdPerson == idPerson).First();
        }

        public IEnumerable<Person> GetAll()
        {
            return _context.Person.ToList();
        }

        public void Remove(int idPerson)
        {
            var person = Find(idPerson);
            _context.Person.Remove(person);
        }

        public void Update(Person person)
        {
            var personFind = Find(person.IdPerson);

            personFind.Lastname = person.Lastname;
            personFind.Firstname = person.Firstname;
            personFind.Address = person.Address;
            personFind.Zipcode = person.Zipcode;
            personFind.City = person.City;
            personFind.Phones = person.Phones;
            personFind.Email = person.Email;

            _context.SaveChanges();
        }
    }
}
