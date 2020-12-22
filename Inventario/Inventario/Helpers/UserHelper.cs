using Inventario.Data.Entities;
using Inventario.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventario.Helpers
{
   
        public class UserHelper : IUserHelper
    {
            private readonly UserManager<Users> _userManager;
            private readonly RoleManager<IdentityRole> _roleManager;
            private readonly SignInManager<Users> _signInManager;

            public UserHelper(
                UserManager<Users> userManager,
                RoleManager<IdentityRole> roleManager,
                SignInManager<Users> signInManager)
            {
                _userManager = userManager;
                _roleManager = roleManager;
                _signInManager = signInManager;
            }

            public async Task<IdentityResult> AddUserAsync(Users user, string password)
            {
                return await _userManager.CreateAsync(user, password);
            }

            public async Task AddUserToRoleAsync(Users user, string roleName)
            {
                await _userManager.AddToRoleAsync(user, roleName);
            }

            public async Task CheckRoleAsync(string roleName)
            {
                var roleExists = await _roleManager.RoleExistsAsync(roleName);
                if (!roleExists)
                {
                    await _roleManager.CreateAsync(new IdentityRole
                    {
                        Name = roleName
                    });
                }
            }

            public async Task<bool> DeleteUserAsync(string email)
            {
                var user = await GetUserByEmailAsync(email);
                if (user == null)
                {
                    return true;
                }

                var response = await _userManager.DeleteAsync(user);
                return response.Succeeded;
            }


            public async Task<Users> GetUserByEmailAsync(string email)
            {
                var user = await _userManager.FindByEmailAsync(email);
                return user;
            }

            public async Task<bool> IsUserInRoleAsync(Users user, string roleName)
            {
                return await _userManager.IsInRoleAsync(user, roleName);
            }

            public async Task<SignInResult> LoginAsync(LoginViewModel model)
            {
                return await _signInManager.PasswordSignInAsync(
                    model.Username,
                    model.Password,
                    model.RememberMe,
                    false);
            }

            public async Task LogoutAsync()
            {
                await _signInManager.SignOutAsync();
            }


            public async Task<IdentityResult> UpdateUserAsync(Users user)
            {
                return await _userManager.UpdateAsync(user);
            }
            public async Task<SignInResult> ValidatePasswordAsync(Users user, string password)
            {
                return await _signInManager.CheckPasswordSignInAsync(
                    user,
                    password,
                    false);
            }


        }
 
}
