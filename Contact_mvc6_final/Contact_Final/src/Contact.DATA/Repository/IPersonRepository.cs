using Contact.DATA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contact.DATA.Repository
{
    public interface IPersonRepository
    {
        void Add(Person item);
        IEnumerable<Person> GetAll();
        Person Find(int idPerson);
        void Remove(int idPerson);
        void Update(Person person);
    }
}
