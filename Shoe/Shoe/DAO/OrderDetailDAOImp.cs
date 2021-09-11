using Shoe.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shoe.DAO
{
    public class OrderDetailDAOImp : IOrderDetailDAO
    {
        private shoeContext _context;
        public OrderDetailDAOImp(shoeContext shoeContext)
        {
            _context = shoeContext;
        }
        public OrderDetail AddOderDatail(OrderDetail orderDetail)
        {
            _context.OrderDetails.Add(orderDetail);
            _context.SaveChanges();
            return orderDetail;
        }
    }
}
