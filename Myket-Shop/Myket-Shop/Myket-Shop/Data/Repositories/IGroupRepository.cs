
using Myket_Shop.Models;
using System.Collections;
using System.Collections.Generic;

namespace Myket_Shop.Data.Repositories
{
    public interface IGroupRepository
    {
        IEnumerable<Category> GetAllCategories();
    }
    public class GroupRepository : IGroupRepository
    {
        private MyketShopContext _context;
        public GroupRepository(MyketShopContext context)
        {
            _context = context;
        }
        public IEnumerable<Category> GetAllCategories()
        {
            return _context.Categories;
        }
    }
}
