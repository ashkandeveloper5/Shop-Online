using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Myket_Shop.Data;
using Myket_Shop.Models;
using System.Collections.Generic;

namespace Myket_Shop.Pages.Admin
{
    public class IndexModel : PageModel
    {
        public IEnumerable<Product> Products { get; set; }
        private MyketShopContext _context;
        public IndexModel(MyketShopContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
            Products = _context.Products.Include(p => p.Item);
        }
        public void OnPost()
        {
        }
    }
}
