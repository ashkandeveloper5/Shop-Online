using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Myket_Shop.Data;
using Myket_Shop.Models;

namespace Myket_Shop.Pages.ManageUsers
{
    public class IndexModel : PageModel
    {
        private readonly Myket_Shop.Data.MyketShopContext _context;

        public IndexModel(Myket_Shop.Data.MyketShopContext context)
        {
            _context = context;
        }

        public IList<Users> Users { get;set; }

        public async Task OnGetAsync()
        {
            Users = await _context.Users.ToListAsync();
        }
    }
}
