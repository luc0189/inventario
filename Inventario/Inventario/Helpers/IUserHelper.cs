using Inventario.Data.Entities;
using Inventario.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Inventario.Helpers
{

    public interface IUserHelper
    {
        Task<Users> GetUserByEmailAsync(string email);

        Task<IdentityResult> AddUserAsync(Users user, string password);

        Task CheckRoleAsync(string roleName);

        Task AddUserToRoleAsync(Users user, string roleName);

        Task<bool> IsUserInRoleAsync(Users user, string roleName);
        Task<SignInResult> LoginAsync(LoginViewModel model);

        Task LogoutAsync();
        Task<bool> DeleteUserAsync(string email);
        Task<IdentityResult> UpdateUserAsync(Users user);
        Task<SignInResult> ValidatePasswordAsync(Users user, string password);
    }
}
