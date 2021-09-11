using Microsoft.AspNetCore.Mvc;
using Shoe.Models.DBModels;
using System.Diagnostics;
using Shoe.DAO;
using Shoe.Models;
using Shoe.Service;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Shoe.Controllers
{
    public class HomeController : Controller
    {
        private IProductService ProductService;
        private ICategoryService CategoryService;
        public HomeController(IProductService Product, ICategoryService Category)
        {
            ProductService = Product;
            CategoryService = Category;
        }

        public IActionResult Index()
        {
            ViewBag.MaleProduct = ProductService.getAllProductByGender("nam");
            ViewBag.FeMaleProduct = ProductService.getAllProductByGender("nữ");
            
            List<Category> listCategoryMale = CategoryService.getListCategoryByGender("nam");
            TempData["ListCategoryMaleSize"] = listCategoryMale.Count;
            for (int i =0;i< listCategoryMale.Count; i++)
            {
                TempData["ListCategoryMale" + i] = listCategoryMale[i].CategoryName;
            }

            List<Category> listCategoryFemale = CategoryService.getListCategoryByGender("nữ");
            TempData["ListCategoryFemaleSize"] = listCategoryFemale.Count;
            for (int i = 0; i < listCategoryFemale.Count; i++)
            {
                TempData["listCategoryFemale" + i] = listCategoryFemale[i].CategoryName;
            }
            TempData.Keep();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
