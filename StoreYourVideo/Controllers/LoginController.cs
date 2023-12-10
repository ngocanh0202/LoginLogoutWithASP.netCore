using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
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
            if (HttpContext.Session.GetString("User") != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(String username, String password)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var user = _context.users.SingleOrDefault(x=> x.UserName.Equals(username));
            if (user != null && string.IsNullOrEmpty(HttpContext.Session.GetString("User")))
            {
                String DePassword = Base64Decode(user.Password);
                if (!DePassword.Equals(password))
                {
                    ViewBag.failedLogin = "Login failed, Please check your user name or password";
                    return View();
                }
                else
                {
                    HttpContext.Session.SetString("User", user.ID.ToString());
                }
            }
            else
            {
                ViewBag.failedLogin = "Login failed, Please check your user name or password";
                return View();
            }
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Register()
        {
            if (HttpContext.Session.GetString("User") != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(String UserName,String Password)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            try
            {
                var user = new User {
                    UserName = UserName,
                    Password = Base64Encode(Password)
                };
                _context.Add(user);
                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                ViewBag.CheckRegister = $"Email is used";
                Console.WriteLine(ex);
                return View();
            }
            
            return RedirectToAction("Index"); // quay lại trang đăng nhập
          
        }
        private static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }
        private static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}
