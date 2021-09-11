using Shoe.DAO;
using Shoe.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shoe.DAO
{
    public class OrderDAOImp : IOrderDAO
    {
        private shoeContext _context;
        public OrderDAOImp(shoeContext shoeContext)
        {
            _context = shoeContext;
        }
        public Order AddOrder(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
            return order;
        }
    }
}
