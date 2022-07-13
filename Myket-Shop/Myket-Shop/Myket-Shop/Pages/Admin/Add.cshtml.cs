using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Myket_Shop.Models;
using Myket_Shop.Data;
using System.IO;

namespace Myket_Shop.Pages.Admin
{
    public class AddModel : PageModel
    {
        private MyketShopContext _context;
        public AddModel(MyketShopContext context)
        {
            _context = context;
        }
        [BindProperty]
        public AddEditProductViewModel Product { get; set; }
        public void OnGet()
        {
         
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var item = new Item()
            {
                Price = Product.Price,
                QuantityInStock = Product.QuantityInStock
            };
            _context.Add(item);
            _context.SaveChanges();
            var pro = new Product()
            {
                Name = Product.Name,
                Item = item
                ,
                Description = Product.Description
            };
            _context.Add(pro);
            _context.SaveChanges();
            pro.ItemId = pro.Id;
            _context.SaveChanges();
            if (Product.Picture?.Length > 0)
            {
                string filepath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "dimage", pro.Id + Path.GetExtension(Product.Picture.FileName));
                using (var stream = new FileStream(filepath, FileMode.Create))
                {
                    Product.Picture.CopyTo(stream);
                }
            }
            return RedirectToPage("index");
        }
    }
}