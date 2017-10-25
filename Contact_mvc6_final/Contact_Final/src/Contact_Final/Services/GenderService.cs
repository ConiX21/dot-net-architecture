using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contact_Final.Models;

namespace Contact_Final.Services
{
    public class GenderService : IGenderService
    {
        public IEnumerable<Gender> GetAll()
        {
            return new List<Gender>()
            {
                new Gender() {IdGender = 1, GenderChar = 'M', Description = "Is a Male gender" },
                new Gender() {IdGender = 2, GenderChar = 'F', Description = "Is a Female gender" }
            };
        }
    }
}
