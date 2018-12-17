using System;
using System.Collections.Generic;
using Northwind.Data;

namespace Northwind.Persistence.Repositories
{
    public class OrdersRepository
    {

        private NorthwindDb _db;

        public OrdersRepository(NorthwindDb db)
        {
            _db = db;
        }



    }

}