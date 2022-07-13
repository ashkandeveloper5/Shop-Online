using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Myket_Shop.Data;
using System.Linq;

namespace Myket_Shop.Controllers
{
    public class ProductController : Controller
    {
        private MyketShopContext _context;
        public ProductController(MyketShopContext context)
        {
            _context = context;
        }
        [Route("Group/{id}/{name}")]
        public IActionResult ShowProductByGroupId(int id,string name)
        {
            ViewData["GroupName"] = name;
            var product = _context.CategoryToProducts.Where(c => c.CategoryId == id).Include(p => p.Product).Select(p => p.Product).ToList();
            return View(product);
        }
    }
}
