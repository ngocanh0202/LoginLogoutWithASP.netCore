using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using StoreYourVideo.Models;

namespace StoreYourVideo.Controllers
{
    public class LoginController : Controller
    {
        private readonly DBContextVideos _context;
        public LoginController(DBContextVideos context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(String username, String password)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
      
            return RedirectToAction("Index", "Home");

        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(User user)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            _context.Add(user);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index"); // quay lại trang đăng nhập
          
        }      
    }
}
