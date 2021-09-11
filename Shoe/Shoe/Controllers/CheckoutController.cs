using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shoe.Models.DBModels;
using Shoe.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shoe.Controllers
{
    public class CheckoutController : Controller
    {
        private IUserService UserService;
        private ICartItemService ItemService;
        private IProductService ProductService;
        private IOrderService OrderService;
        private IOrderDetailService OrderDetailService;

        public CheckoutController(IUserService User, ICartItemService Item, IProductService Product, IOrderService Order, IOrderDetailService OrderDetail)
        {
            UserService = User;
            ItemService = Item;
            ProductService = Product;
            OrderService = Order;
            OrderDetailService = OrderDetail;
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("userName") != null)
            {
                int UserId = int.Parse(HttpContext.Session.GetString("id"));
                ViewBag.User = UserService.getUser(UserId);

                List<CartItem> listCart = ItemService.getListCartItem(UserId);
                List<Product> listProduct = new List<Product>();
                int? totalPrice = 0;
                foreach (var item in listCart)
                {
                    Product product = ProductService.getProductById(item.ProductId);
                    listProduct.Add(product);
                    totalPrice += product.Price * item.Quantity;
                    ViewBag.ListCartItem = listProduct;
                    ViewBag.ListCart = listCart;
                    ViewBag.TotalPrice = totalPrice;
                }
                return View();
            }
            return Redirect("/Account/Login");
        }
        [HttpPost]
        public IActionResult doCheckout(Order order, string Address, string Province, string District, string Homlet)
        {
            int id = int.Parse( HttpContext.Session.GetString("id"));
            if (HttpContext.Session.GetString("userName") != null)
            {
                order.UserId = int.Parse(HttpContext.Session.GetString("id"));
                order.DateCreated = DateTime.Now;
                order.AddressDelivery = Address + ", " + Homlet + ", " + District + ", " + Province;
                order.Payment = 0;
                order.Status = 0;
                order.Paid = 0;
                OrderService.AddOrder(order);
                ItemService.deleteItemUser(id);
                
            }return Redirect("/Home/Index");
        }
    }
}
