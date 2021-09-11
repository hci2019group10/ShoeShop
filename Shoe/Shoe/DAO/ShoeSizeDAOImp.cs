using Shoe.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shoe.DAO
{
    public class ShoeSizeDAOImp : IShoeSizeDAO
    {
        private shoeContext _context;
        public ShoeSizeDAOImp(shoeContext shoeContext)
        {
            _context = shoeContext;
        }
        public bool checkQuantity(int productID)
        {
            return true;
        }

        public List<ShoeSizeDetail> getShoeSizeByProductID(int productID)
        {
            List<ShoeSizeDetail> list = _context.ShoeSizeDetails.Where(o => o.ProductId == productID).ToList();
            return list;
        }
    }
}
