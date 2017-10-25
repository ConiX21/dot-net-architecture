using Contact.DATA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contact_Final.Models
{
    public class PersonViewModel
    {
        public IEnumerable<Gender> Genders { get; set; }
        public Person Person { get; set; }
    }
}
