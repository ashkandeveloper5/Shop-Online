using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Myket_Shop.Data;
using Myket_Shop.Models;
using System.IO;
using System.Linq;

namespace Myket_Shop.Pages.Admin
{
    public class DeleteModel : PageModel
    {
        private MyketShopContext _context;
        public DeleteModel(MyketShopContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Product Product { get; set; }
        public void OnGet(int id)
        {
            Product = _context.Products.FirstOrDefault(p => p.Id == id);
        }
        public IActionResult OnPost()
        {
            var product = _context.Products.Find(Product.Id);
            var item = _context.Items.First(p => p.Id == product.ItemId);
            _context.Items.Remove(item);
            _context.Products.Remove(product);
            _context.SaveChanges();
            string filepath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "dimage", product.Id + ".jpg");
            if (System.IO.File.Exists(filepath))
            {
                System.IO.File.Delete(filepath);
            }
            return RedirectToPage("Index");
        }
    }
}