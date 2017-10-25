using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Contact.DATA.Models
{
    public partial class Person
    {
        public Person()
        {
            Phones = new HashSet<Phone>();
        }

        public int IdPerson { get; set; }

        [RegularExpression("^[A-Z]+$", ErrorMessage = "Not a valid string")]
        [Required]
        public string Lastname { get; set; }

        [RegularExpression("^[A-Z][-a-zA-Z]+$", ErrorMessage = "Not a valid string")]
        [Required]
        public string Firstname { get; set; }


        public string Address { get; set; }
        public string Zipcode { get; set; }
        public string City { get; set; }

        [EmailAddress(ErrorMessage = "You need toi enter a valid email")]
        [Required]
        public string Email { get; set; }

        public string Gender { get; set; }

        public virtual ICollection<Phone> Phones { get; set; }
    }
}
