using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqToObjects
{
    class DataLayer
    {
        private Customer[] _Customers;
        private Product[] _Products;

        public DataLayer(Customer[] Customers, Product[] Products)
        {
            _Customers = Customers;
            _Products = Products;
        }

        /// <summary>
        /// Projection Operators 'Select'
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Object> QuerySelect()
        {
            //return = _Customers.Select(c => new { c.Name, c.City });
            //return = _Customers.Select(c => c.Name);
            return _Customers.Select((c, index) => new { index, c.Name, c.Country });
        }

        public IEnumerable<Order> QuerySelectMany()
        {
            //La ligne ci dessous est en erreur sur le type de retour  la methode select ne remonte que un seul order
            //return _Customers.Where(c => c.Country == Countries.Italy).Select(c => c.Orders);

            //SelectMany renvoi un ensemble d'elements
            return _Customers.Where(c => c.Country == Countries.Italy).SelectMany(c => c.Orders);

            //todo : OU pour SelectMany
            //return      from c in _Customers
            //            where c.Country == Countries.Italy
            //            from o in c.Orders
            //            select o;

            //Variante :
            //var items = _Customers.Where(c => c.Country == Countries.Italy)
            //        .SelectMany(c => c.Orders,(c, o) => new { o.Quantity, o.IdProduct });

            //var items = from c in _Customers
            //            where c.Country == Countries.Italy
            //            from o in c.Orders
            //            select new { o.Quantity, o.IdProduct };
        }

        public IEnumerable<object> QueryOrderBy()
        {
            //return  from c in _Customers
            //        where c.Country == Countries.Italy
            //        orderby c.Name descending
            //        select new { c.Name, c.City };

            //OU
            return _Customers.Where(c => c.Country == Countries.Italy)
                                .OrderByDescending(c => c.Name)
                                .Select(c => new { c.Name, c.City });

            //todo : OU Multi criteres
            //return _Customers.Where(c => c.Country == Countries.Italy)
            //                  .OrderByDescending(c => c.Name)
            //                  .ThenBy(c => c.City)
            //                  .Select(c => new { c.Name, c.City });

            //var expr =  from c in _Customers
            //            where c.Country == Countries.Italy
            //            orderby c.Name descending, c.City
            //            select new { c.Name, c.City };

            //todo : OU REVERSE
            //return _Customers.Where(c => c.Country == Countries.Italy)
            //                   .OrderByDescending(c => c.Name)
            //                   .Select(c => new { c.Name, c.City }).Reverse();

            //var expr = (from c in _Customers
            //            where c.Country == Countries.Italy
            //            orderby c.Name descending, c.City
            //            select new { c.Name, c.City }).Reverse();

            //todo : Ou simplement OrderBy
            //return _Customers.Where(c => c.Country == Countries.Italy)
            //                   .OrderBy(c => c.Name);

        }

        public IEnumerable<IGrouping<Countries, Customer>> QueryGroupBy()
        {
            return _Customers.GroupBy(c => c.Country);

            //Ou
            //return from c in _Customers
            //            group c by c.Country;
        }

        public IEnumerable<IGrouping<Countries, string>> QueryGroupBy2()
        {
            return _Customers.GroupBy(c => c.Country, c => c.Name);

            //Ou
            //return from c in _Customers
            //            group c by c.Country;
        }

        public IEnumerable<object> QueryGroupBy3()
        {
            return _Customers.GroupBy(c => c.Country, (k, c) => new { Key = k, Count = c.Count() });
        }

        public IEnumerable<object> QueryJoin()
        {
            return _Customers.SelectMany(c => c.Orders)
                             .Join(_Products, o => o.IdProduct,
                                              p => p.IdProduct,
                                              (o, p) => new { o.Month, o.Shipped, p.IdProduct, p.Price });

            //OU
            //return from c in _Customers
            //           from o in c.Orders
            //           join p in _Products
            //           on o.IdProduct equals p.IdProduct
            //           select new { o.Month, o.Shipped, p.IdProduct, p.Price };
        }

        public IEnumerable<Order> QueryLet()
        {
            var t = from c in _Customers
                    from o in c.Orders
                    let moyenne = c.Orders.Average(or => or.Quantity)
                    select new { Moyenne = moyenne };

            var developersGroupedByLanguage =
                from d in _Customers
                group d by d.Orders;

            return from c in _Customers
                   from o in c.Orders
                   let moyenne = c.Orders.Average(or => or.Quantity)
                   where o.Quantity > moyenne
                   select o;

        }
    }
}
