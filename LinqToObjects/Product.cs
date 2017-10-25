using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqToObjects
{
    class Product
    {
        public int IdProduct;
        public decimal Price;
        public override string ToString()
        {
            return String.Format("IdProduct: {0} – Price: {1}", this.IdProduct,
            this.Price);
        }
    }
}
