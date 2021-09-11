using Shoe.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shoe.DAO
{
    public interface IShoeSizeDAO
    {
        public bool checkQuantity(int productID);

        public List<ShoeSizeDetail> getShoeSizeByProductID(int productID);
    }
}
