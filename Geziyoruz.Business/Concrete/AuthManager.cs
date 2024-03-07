

using AutoMapper;
using Geziyoruz.Business.Abstract;
using Geziyoruz.Entities.Concrete;
using Geziyoruz.Entities.Concrete.Dtos.UserDtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Geziyoruz.Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IMapper _mapper;

        public AuthManager(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, SignInManager<AppUser> signInManager, IMapper mapper)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _mapper = mapper;
        }

        public async Task<IdentityResult> AddToRoleAsync(AppUser appUser, string role)
        {
            AppRole? appRole = _roleManager.Roles.FirstOrDefault(x => x.Name == role);
            if (appRole is null)
            {
                appRole = new AppRole()
                {
                    Name = role,
                    NormalizedName = role.ToUpper()
                };
                await _roleManager.CreateAsync(appRole);
            }
            return await _userManager.AddToRoleAsync(appUser, role);
        }

        public async Task<IdentityResult> AdminRegisterAsync(AdminRegisterDto adminRegisterDto) => await Register<Admin, AdminRegisterDto>(adminRegisterDto, adminRegisterDto.Password, "admin");


        public async Task<IdentityResult> CustomerRegisterAsync(CustomerRegisterDto customerRegisterDto) => await Register<Customer, CustomerRegisterDto>(customerRegisterDto, customerRegisterDto.Password, "customer");

        public async Task<List<string>> GetRolesAsync(AppUser user) => (await _userManager.GetRolesAsync(user)).ToList();

        public async Task<AppUser> GetUserAsync(string userName)
        {
            return await _userManager.Users.FirstOrDefaultAsync(x => !userName.Contains("@") ? x.UserName == userName : x.Email == userName);
        }

        public async Task<SignInResult> LoginAsync(LoginDto loginDto)
        {
            AppUser? user = loginDto.UserName.Contains("@") ? _userManager.Users.FirstOrDefault(x => x.Email == loginDto.UserName) : _userManager.Users.FirstOrDefault(x => x.UserName == loginDto.UserName);
            return user is not null ? await _signInManager.PasswordSignInAsync(user, loginDto.Password, true, false) : null;
        }

        public async Task<IdentityResult> PasswordResetAsync(string userName, string newPassword)
        {
            string token = null;
            AppUser? user = await GetUserAsync(userName);
            IdentityResult result = await _userManager.RemovePasswordAsync(user);
            if (result.Succeeded)
            {
                token = await _userManager.GeneratePasswordResetTokenAsync(user);
            }
            return await _userManager.ResetPasswordAsync(user, token, newPassword);
        }

        public async Task SignOutAsync() => await _signInManager.SignOutAsync();

        public async Task<string> CreateTokenAsync(LoginDto loginDto)
        {
            string token = "";
            AppUser user = await GetUserAsync(loginDto.UserName);
            if (user == null) return token;
            SignInResult result = user is not null ? await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, user.LockoutEnabled) : null;
            if (!result.Succeeded) return token;

            List<Claim> claims = new List<Claim>()
                {
                    new Claim("UserId",user.Id.ToString()),
                    new Claim(ClaimTypes.Name,user.UserName),
                    new Claim(ClaimTypes.Email,user.Email),
                    new Claim(ClaimTypes.GivenName,user.FirstName),
                    new Claim(ClaimTypes.Surname,user.LastName)
                };
            List<string> roles = await GetRolesAsync(user);
            foreach (string item in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, item));
            }
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims);
            var key = Encoding.UTF8.GetBytes("uzunguvenlikanahtari");
            SecurityTokenDescriptor descriptor = new SecurityTokenDescriptor()
            {
                //Sağlayıcı
                Audience = "localhost",
                //Kullanıcı 
                Issuer = "localhost",
                // Claimsler 
                Subject = claimsIdentity,
                // Geçerlilik süresi
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            SecurityToken jwtToken = handler.CreateToken(descriptor);
            token = handler.WriteToken(jwtToken);
            return token;
        }

        public async Task<IdentityResult> UpdatePasswordAsync(string userName, string currentPassword, string newPassword)
        {
            AppUser? user = await GetUserAsync(userName);
            return await _userManager.ChangePasswordAsync(user, currentPassword, newPassword);
        }

        public async Task<IdentityResult> Register<TEntity, TDto>(TDto registerDto, string password, string role)
        {
            AppUser appUser = _mapper.Map<AppUser>(registerDto);
            switch (typeof(TEntity))
            {
                case Type customerType when customerType == typeof(Customer):
                    appUser.Customer = _mapper.Map<Customer>(registerDto);
                    break;
                case Type adminType when adminType == typeof(Admin):
                    appUser.Admin = _mapper.Map<Admin>(registerDto);
                    break;
            }
            var result = await CreateUser(appUser, password);
            return result.Succeeded is true ? await AddToRoleAsync(appUser, role) : result;
        }

        private async Task<IdentityResult> CreateUser(AppUser appUser, string password) => await _userManager.CreateAsync(appUser, password);
    }
}
