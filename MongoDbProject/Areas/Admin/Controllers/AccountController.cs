using Microsoft.AspNetCore.Mvc;
using MongoDbProject.Entities;
using MongoDbProject.Services.UserServices;

namespace MongoDbProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Account/")]
    public class AccountController : Controller
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [Route("Register")]
        // GET: Register Sayfasını Görüntüle
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        // POST: Kullanıcı Kaydet
        [Route("Register")]
        [HttpPost]
        public async Task<IActionResult> Register(ApplicationUser user, string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                ModelState.AddModelError("", "Şifre alanı boş olamaz.");
                return View(user);
            }

            // Şifreyi hashleyin
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(password);

            try
            {
                await _userService.RegisterUserAsync(user, password);
                TempData["SuccessMessage"] = "Kayıt başarılı! Giriş yapabilirsiniz.";
                return RedirectToAction("Login", "Account",new { areas = "Admin"});
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Bir hata oluştu: " + ex.Message);
                return View(user);
            }
        }


        [HttpGet]
        [Route("Login")]
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(string username, string password)
        {
            var user = await _userService.GetUserByUsernameAsync(username);
            if (user == null || !await _userService.CheckPasswordAsync(user, password))
            {
                ModelState.AddModelError("", "Geçersiz kullanıcı adı veya şifre.");
                return View();
            }

            // Giriş işlemi başarılı
            HttpContext.Session.SetString("UserId", user.ApplicationUserId);
            return RedirectToAction("Profile", "Account");
        }





    }
}