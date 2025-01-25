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
                user.ProfilePictureUrl = "Profil Resminizi Güncelleyin";
                user.Description = "Açıklamanızı Güncelleyin";
                user.Address = "Adresinizi Güncelleyin";
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
            return RedirectToAction("Profile", "Account", new { areas = "Admin" });
        }

        [Route("Profile")]
        public async Task<IActionResult> Profile()
        {

            var userId = HttpContext.Session.GetString("UserId");
            if (string.IsNullOrEmpty(userId))
            {
                return RedirectToAction("Login", "Account");
            }

            var user = await _userService.GetUserByIdAsync(userId);
            return View(user);

        }

		[Route("UpdateProfile")]
		public async Task<PartialViewResult> UpdateProfile()
		{
			var userId = HttpContext.Session.GetString("UserId");
			if (string.IsNullOrEmpty(userId))
			{
				return PartialView("_ErrorPartial", "Kullanıcı oturum açmamış.");
			}

			var user = await _userService.GetUserByIdAsync(userId);
			if (user == null)
			{
				return PartialView("_ErrorPartial", "Kullanıcı bulunamadı.");
			}

			return PartialView("UpdateProfile", user);

		}

		[HttpPost]
		[Route("UpdateProfile")]
		public async Task<IActionResult> UpdateProfile(ApplicationUser user)
		{
			var existingUser = await _userService.GetUserByIdAsync(user.ApplicationUserId);
			if (existingUser != null)
			{
				existingUser.FullName = user.FullName;
				existingUser.ProfilePictureUrl = user.ProfilePictureUrl;
				existingUser.UserName = user.UserName;
				existingUser.Title = user.Title;
				existingUser.Address = user.Address;
				existingUser.Description = user.Description;
				existingUser.Email = user.Email;

				// UpdateUserAsync çağrısı için userId ve updatedUser parametrelerini geçiyoruz
				await _userService.UpdateUserAsync(existingUser.ApplicationUserId, existingUser);

				return RedirectToAction("Profile", "Account");
			}

			return View("Error");
		}


	}
}