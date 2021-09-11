using Microsoft.AspNetCore.Mvc;
using Shoe.Models.DBModels;
using Shoe.Service;
using Shoe.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shoe.Controllers
{
    public class ProductController : Controller
    {
        private IProductService ProductService;
        public ProductController(IProductService Product)
        {
            ProductService = Product;
        }
        public IActionResult ProductDetail(int id)
        {
            ViewBag.Detail = ProductService.getProductById(id);
            return View();
        }
        public IActionResult Search( string keyword)
        {
            ViewBag.ListProduct = ProductService.searchProduct(keyword);
            ViewBag.ListProductSize = ProductService.searchProduct(keyword).Count();
            ViewBag.BreakcumA = "Shop";
            return View("ListProduct");
        }

        public IActionResult ListProduct(string gender, string category)
        {
            if(category=="" || category == null)
            {
                ViewBag.ListProduct = ProductService.searchProduct(gender);
                ViewBag.ListProductSize = ProductService.searchProduct(gender).Count();
                ViewBag.BreakcumA = gender;
            }
            else
            {
                ViewBag.ListProduct = ProductService.getListProductByGenderAndCategory(gender, category);
                ViewBag.ListProductSize = ProductService.getListProductByGenderAndCategory(gender, category).Count();
                ViewBag.BreakcumA = gender;
                ViewBag.BreakcumB = category;
            }
            
            return View();
        }

        public IActionResult Collection()
        {
            ViewBag.ListProduct = ProductService.getAllProduct();
            ViewBag.ListProductSize = ProductService.getAllProduct().Count();
            ViewBag.BreakcumA = "Collection";
            return View("ListProduct");
        }

        [HttpGet]
        public JsonResult Sort(string gender, string category, int minPrice, int maxPrice, string color, int size)
        {
            return Json(ProductService.sort(gender, category, minPrice, maxPrice, color, size));
        }
           
    }
}
