using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqToObjects
{
    public class BusinessLayer : IBusinessAccessLayer
    {
        private Customer[] _Customers;
        private Product[] _Products;
        private DataLayer _DataLayer;

        public BusinessLayer()
        {
            InitializeCustomers();
            InitializeProducts();
            _DataLayer = new DataLayer(_Customers, _Products);
        }

        public void ProjectionSelect()
        {

            foreach (dynamic obj in _DataLayer.QuerySelect())
            {
                Console.WriteLine("{0} {1} {2}", obj.index, obj.Name, obj.Country);
            }

        }

        public void InitializeProducts()
        {
            _Products = new Product[] {
                new Product {IdProduct = 1, Price = 10 },
                new Product {IdProduct = 2, Price = 20 },
                new Product {IdProduct = 3, Price = 30 },
                new Product {IdProduct = 4, Price = 40 },
                new Product {IdProduct = 5, Price = 50 },
                new Product {IdProduct = 6, Price = 60 }};
        }

        public void InitializeCustomers()
        {

            _Customers = new Customer[] 
            {
                new Customer {  Name = "Paolo",City = "Brescia",Country = Countries.Italy,
                                Orders = new Order[] 
                                {
                                    new Order { IdOrder = 1, Quantity = 3, IdProduct = 1 , Shipped = false, Month = "January"},
                                    new Order { IdOrder = 2, Quantity = 5, IdProduct = 2 ,  Shipped = true, Month = "May"}
                                }
                },
                new Customer {  Name = "Marco", City = "Torino", Country = Countries.Italy,
                                Orders = new Order[] 
                                {
                                    new Order { IdOrder = 3, Quantity = 10, IdProduct = 1 ,Shipped = false, Month = "July"},
                                    new Order { IdOrder = 4, Quantity = 20, IdProduct = 3 , Shipped = true, Month = "December"}
                                }
                },
                new Customer {  Name = "James", City = "Dallas", Country = Countries.USA, Orders = new Order[] 
                                {
                                    new Order { IdOrder = 5, Quantity = 20, IdProduct = 3 , Shipped = true, Month = "December"}
                                }
                },
                new Customer    {  Name = "Frank", City = "Seattle",Country = Countries.USA, Orders = new Order[] {
                                    new Order { IdOrder = 6, Quantity = 20, IdProduct = 5 ,Shipped = false, Month = "July"}}
                                }   
            };
        }

        public void ProjectionSelectMany()
        {
            foreach (Order obj in _DataLayer.QuerySelectMany())
            {
                Console.WriteLine("{0} {1} {2} {3}", obj.IdOrder, obj.Month, obj.Quantity, obj.Shipped);
            }
        }

        public void ProjectionOrderBy()
        {
            foreach (dynamic obj in _DataLayer.QueryOrderBy())
            {
                Console.WriteLine("{0} {1}", obj.Name, obj.City);
            }
        }

        public void ProjectionGroupBy()
        {
            Console.WriteLine("{0}***********IGrouping<Countries, Customer>**************", Environment.NewLine);

            foreach (IGrouping<Countries, Customer> customerGroup in _DataLayer.QueryGroupBy())
            {
                Console.WriteLine("Country: {0}", customerGroup.Key);

                foreach (var item in customerGroup)
                {
                    Console.WriteLine("\t{0}", item);
                }

            }

            Console.WriteLine("{0}***********IGrouping<Countries, String>**************", Environment.NewLine);

            foreach (IGrouping<Countries, String> customerGroup in _DataLayer.QueryGroupBy2())
            {
                Console.WriteLine("Country: {0}", customerGroup.Key);
                foreach (var item in customerGroup)
                {
                    Console.WriteLine("\t{0}", item);
                }

            }

            Console.WriteLine("{0}***********IEnumerable<object>**************", Environment.NewLine);


            foreach (dynamic group in _DataLayer.QueryGroupBy3())
            {
                Console.WriteLine("Key: {0} - Count: {1}", group.Key, group.Count);
            }

        }

        public void ProjectionJoin()
        {
            foreach (dynamic item in _DataLayer.QueryJoin())
            {
                Console.WriteLine("{0} {1} {2} {3}", item.Month, item.Shipped, item.IdProduct, item.Price);
            }
        }

        public void ProjectionLet()
        {
            foreach (Order item in _DataLayer.QueryLet())
            {
                Console.WriteLine(item);
            }    
        }
    }
}
