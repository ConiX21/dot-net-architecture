using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqToObjects
{
    class Customer
    {
        public string Name;
        public string City;
        public Countries Country;
        public Order[] Orders;
        public override string ToString()
        {
            return String.Format("Name: {0} – City: {1} – Country: {2}",
            this.Name, this.City, this.Country);
        }
    }
}
