using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Myket_Shop.Controllers
{
    [Authorize]
    public class TestController : Controller
    {
        public string test1()
        {
            return "test1";
        }
        public string test2()
        {
            return "test2";
        }
    }
}
