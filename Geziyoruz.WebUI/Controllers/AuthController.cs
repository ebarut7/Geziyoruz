using Geziyoruz.Business.Abstract;
using Geziyoruz.Entities.Concrete.Dtos.UserDtos;
using Microsoft.AspNetCore.Mvc;

namespace Geziyoruz.WebUI.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            Microsoft.AspNetCore.Identity.SignInResult response = await _authService.LoginAsync(loginDto);
            var user = await _authService.GetUserAsync(loginDto.UserName);
            var getRole = await _authService.GetRolesAsync(user);
            if (response.Succeeded && getRole.Contains("customer"))
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Register(CustomerRegisterDto customerRegisterDto)
        {
            bool response = (await _authService.CustomerRegisterAsync(customerRegisterDto)).Succeeded;
            
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult AdminLogin()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AdminLogin(LoginDto loginDto)
        {
            Microsoft.AspNetCore.Identity.SignInResult response = await _authService.LoginAsync(loginDto);
            var user = await _authService.GetUserAsync(loginDto.UserName);
            var getRole= await _authService.GetRolesAsync(user);
            if (response.Succeeded && getRole.Contains("admin"))
            {
                return RedirectToAction("Panel","Admin");
            }
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> AdminRegister(AdminRegisterDto adminRegisterDto)
        {
            if (adminRegisterDto.Code == "985463")
            {
                bool response= (await _authService.AdminRegisterAsync(adminRegisterDto)).Succeeded;
                return RedirectToAction("Panel","Admin");
            }
            return RedirectToAction("Login");
        }

        [HttpGet]
        public async Task<IActionResult> SignOut()
        {
            await _authService.SignOutAsync();
            return View("Login");
        }
    }
}
