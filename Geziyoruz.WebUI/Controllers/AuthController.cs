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
            if(response.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Register(CustomerRegisterDto customerRegisterDto) 
        {
            bool response = (await _authService.CustomerRegisterAsync(customerRegisterDto)).Succeeded;
            return RedirectToAction("Home", "Home");
        }
    }
}
