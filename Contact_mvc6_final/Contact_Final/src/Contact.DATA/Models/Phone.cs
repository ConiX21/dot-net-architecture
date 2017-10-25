using System;
using System.Collections.Generic;

namespace Contact.DATA.Models
{
    public partial class Phone
    {
        public byte IdPhone { get; set; }
        public string PhoneNumber { get; set; }
        public int? IdPerson { get; set; }

        public virtual Person IdPersonNavigation { get; set; }
    }
}
