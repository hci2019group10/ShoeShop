using Shoe.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shoe.DAO;

namespace Shoe.Service
{
    public class OrderDetailServiceImp : IOrderDetailService
    {
        private IOrderDetailDAO orderDetailDAO;
        public OrderDetailServiceImp(IOrderDetailDAO orderDetail)
        {
            orderDetailDAO = orderDetail;
        }

        public OrderDetail AddOderDatail(OrderDetail orderDetail)
        {
            return orderDetailDAO.AddOderDatail(orderDetail);
        }

    }
}
