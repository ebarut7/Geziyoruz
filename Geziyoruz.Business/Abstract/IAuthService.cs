

using Geziyoruz.Entities.Concrete;
using Geziyoruz.Entities.Concrete.Dtos.UserDtos;
using Microsoft.AspNetCore.Identity;

namespace Geziyoruz.Business.Abstract
{
    public interface IAuthService
    {
        Task<List<string>> GetRolesAsync(AppUser user);
        Task<AppUser> GetUserAsync(string userName);
        Task<IdentityResult> PasswordResetAsync(string userName, string newPassword);
        Task<IdentityResult> UpdatePasswordAsync(string userName, string currentPassword, string newPassword);
        Task<SignInResult> LoginAsync(LoginDto loginDto);
        Task<IdentityResult> AdminRegisterAsync(AdminRegisterDto AdminRegisterDto);
        Task<IdentityResult> CustomerRegisterAsync(CustomerRegisterDto customerRegisterDto);
        Task SignOutAsync();
        Task<IdentityResult> AddToRoleAsync(AppUser appUser, string role);
        Task<string> CreateTokenAsync(LoginDto loginDto);
    }
}
