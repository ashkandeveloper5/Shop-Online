using Myket_Shop.Models;
using System.Collections.Generic;
using System.Linq;

namespace Myket_Shop.Data.Repositories
{
    public interface IUserRepository
    {
        bool IsExistUserByEmail(string email);
        void AddUser(Users user);
        Users GetUserForLogin(string email, string password);
        List<OrderDetail> ListOrderDetails(int id);
    }
    public class UserRepository : IUserRepository
    {
        private MyketShopContext _context;
        public UserRepository(MyketShopContext context)
        {
            _context = context;
        }
        public void AddUser(Users user)
        {
            _context.Add(user);
            _context.SaveChanges();
        }

        public Users GetUserForLogin(string email, string password)
        {
            return _context.Users.SingleOrDefault(u => u.Email == email && u.Password == password);
        }

        public bool IsExistUserByEmail(string email)
        {
            return _context.Users.Any(u => u.Email == email);
        }
        public List<OrderDetail> ListOrderDetails(int id)
        {
            List<OrderDetail> list = new List<OrderDetail>();
            Order orders = _context.Orders.FirstOrDefault(p => p.UserId == id);
            for (int i = 0; i < orders.OrderDetails.Count; i++)
            {
                list.Add(new OrderDetail
                {
                    Name = orders.OrderDetails[i].Name,
                    Price = orders.OrderDetails[i].Price,
                    Product = orders.OrderDetails[i].Product,
                    Count = orders.OrderDetails[i].Count
                });
            }
            return list;
        }
    }
}
