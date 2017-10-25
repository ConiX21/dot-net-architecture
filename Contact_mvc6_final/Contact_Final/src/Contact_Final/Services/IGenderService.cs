using Contact_Final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contact_Final.Services
{
    public interface IGenderService
    {
        IEnumerable<Gender> GetAll();
    }
}
