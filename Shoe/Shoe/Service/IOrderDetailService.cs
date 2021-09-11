using Shoe.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shoe.Service
{
    public interface IOrderDetailService
    {
        public OrderDetail AddOderDatail(OrderDetail orderDetail);
    }
}
