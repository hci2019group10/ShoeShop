using Shoe.DAO;
using Shoe.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shoe.Service
{
    public class OrderServiceImp : IOrderService
    {
        private IOrderDAO orderDAO;
        public OrderServiceImp(IOrderDAO order)
        {
            orderDAO = order;
        }
        public Order AddOrder(Order order)
        {
            return orderDAO.AddOrder(order);
        }

       
    }
}
