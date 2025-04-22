using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vepeeta.Data.Entity.Identity;
using Vepeeta.Service.Abstract;

namespace Vepeeta.Service.Implemention
{
    public class AppUserService : IAppUserService
    {
        private readonly UserManager<User> _userManager;

        public AppUserService(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        public async Task<bool> IsEmailExistExcludeSelf(string id, string email)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Email == email & u.Id != id);
            return user != null;
        }
    }
}
