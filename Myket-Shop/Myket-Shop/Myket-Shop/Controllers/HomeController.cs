using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Myket_Shop.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ZarinpalSandbox;

namespace Myket_Shop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private Data.MyketShopContext _context;

        public HomeController(ILogger<HomeController> logger, Data.MyketShopContext context)
        {
            _logger = logger;
            _context = context;
        }

        [Route("ContactUs")]
        public IActionResult ContactUs()
        {
            return View();
        }
        public IActionResult Detail(int id)
        {
            var product = _context.Products.Include(p => p.Item).SingleOrDefault(p => p.Id == id);
            var cateogry = _context.Products.Where(p => p.Id == id).SelectMany(c => c.CategoryToProduct).Select(ca => ca.Category).ToList();
            var vm = new DetailsViewModel { Product = product, Categories = cateogry };
            return View(vm);
        }
        [Authorize]
        public IActionResult AddToCart(int itemId)
        {
            var product = _context.Products.Include(p => p.Item).SingleOrDefault(p => p.ItemId == itemId);
            if (product != null)
            {
                int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier).ToString());
                var order = _context.Orders.FirstOrDefault(o => o.UserId == userId && !o.IsFinaly);
                if (order != null)
                {
                    var orderDetail = _context.OrderDetails.FirstOrDefault(o => o.OrderId == order.OrderId && o.ProductId == product.Id);
                    if (orderDetail != null)
                    {
                        orderDetail.Count += 1;
                    }
                    else
                    {
                        _context.OrderDetails.Add(new OrderDetail()
                        {
                            OrderId = order.OrderId,
                            Name = product.Name,
                            Price = product.Item.Price,
                            ProductId = product.Id,
                            Count = 1

                        });
                    }
                }
                else
                {
                    order = new Order
                    {
                        UserId = userId,
                        CreateDate = DateTime.Now,
                        IsFinaly = false
                    };
                    _context.Orders.Add(order);
                    _context.SaveChanges();
                    _context.OrderDetails.Add(new OrderDetail()
                    {
                        OrderId = order.OrderId,
                        Name = product.Name,
                        Price = product.Item.Price,
                        ProductId = product.Id,
                        Count = 1
                    });
                }
                _context.SaveChanges();
            }
            return RedirectToAction("ShowCart");
        }
        [Authorize]
        [Route("Cart")]
        public IActionResult ShowCart()
        {
            int userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value.ToString());
            var order = _context.Orders.Where(o => o.UserId == userId && !o.IsFinaly).Include(o => o.OrderDetails).ThenInclude(o => o.Product).FirstOrDefault();
            return View(order);
        }
        //public IActionResult Payment()
        //{
        //    int userId=int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
        //    var order = _context.Orders.Include(o=>o.OrderDetails).Where(o => o.UserId == userId && !o.IsFinaly).FirstOrDefault();
        //    if (order==null)
        //    {
        //        return NotFound();
        //    }
        //    var payment = new Payment((int)order.OrderDetails.Sum(d => d.Price));
        //}
        [Authorize]
        public IActionResult RemoveCart(int detailId)
        {
            var orderDetail = _context.OrderDetails.Find(detailId);
            _context.OrderDetails.Remove(orderDetail);
            _context.SaveChanges();
            return RedirectToAction("ShowCart");
        }
        public IActionResult Index()
        {
            var Products = _context.Products.Include(p => p.Item).ToList();
            return View(Products);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
