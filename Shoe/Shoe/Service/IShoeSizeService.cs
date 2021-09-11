using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shoe.Service
{
    public interface IShoeSizeService
    {
        public bool checkQuantity(int productID);
    }
}
