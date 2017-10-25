using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqToObjects
{
    interface IBusinessAccessLayer
    {
        void InitializeCustomers();
        void InitializeProducts();
        void ProjectionSelect();
        void ProjectionSelectMany();
        void ProjectionOrderBy();
        void ProjectionGroupBy();
        void ProjectionJoin();
        void ProjectionLet();

    }
}
