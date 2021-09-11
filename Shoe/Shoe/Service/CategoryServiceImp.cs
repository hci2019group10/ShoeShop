using Shoe.DAO;
using Shoe.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shoe.Service
{
    public class CategoryServiceImp : ICategoryService
    {
        private ICategoryDAO categoryDAO;
        public CategoryServiceImp(ICategoryDAO category)
        {
            categoryDAO = category;
        }
        public List<Category> getListCategoryByGender(string gender)
        {
            return categoryDAO.getListCategoryByGender(gender);
        }
    }
}
