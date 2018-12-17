using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwind.Data;
using Northwind.Models;

namespace Northwind.Persistence
{
    public class CategoriesRepository : NorthwindRepository<Category>
    {

        public CategoriesRepository(NorthwindDb db) : base(db)
        {
        }

      
    }

}
