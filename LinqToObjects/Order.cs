using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqToObjects
{
    class Order
    {
        public int IdOrder;
        public int Quantity;
        public bool Shipped;
        public string Month;
        public int IdProduct;

        public override string ToString()
        {
            return String.Format("IdOrder: {0} – IdProduct: {1} – " +
            "Quantity: {2} – Shipped: {3} – " +
            "Month: {4}", this.IdOrder, this.IdProduct,
            this.Quantity, this.Shipped, this.Month);
        }
    }
}
