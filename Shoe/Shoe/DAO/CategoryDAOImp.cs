using Shoe.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shoe.DAO
{
    public class CategoryDAOImp : ICategoryDAO
    {
        private shoeContext _context;
        public CategoryDAOImp(shoeContext shoeContext)
        {
            _context = shoeContext;
        }
        public List<Category> getListCategoryByGender(string gender)
        {
            
            var categoryList = ( from c in _context.Categories
                     join p in _context.Products on c.CategoryId equals p.CategoryId
                     where p.Gender == gender
                     select new Category{ CategoryId = c.CategoryId, CategoryName = c.CategoryName  }).Distinct().ToList();
           
            return categoryList;
        }
        
    }
}
