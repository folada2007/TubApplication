using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Philharmonic.Services.Interfaces;
using System.Security.Claims;
namespace Philharmonic.Models
{
    public class AuthenticationService:IAuthService
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _accessor;
        private readonly PasswordHasher<User> _passwordHasher;

        public AuthenticationService(ApplicationDbContext context,IHttpContextAccessor accessor,PasswordHasher<User> passwordHasher) 
        {
            _passwordHasher = passwordHasher;
            _context = context;
            _accessor = accessor;
        }

        public async Task<ClaimsPrincipal> AuthenticationUserAsync(Login login)
        {
            var Users = await _context.auths.FirstOrDefaultAsync(c => c.name == login.Name);
            if (Users != null) 
            {
                var PasswordResult = _passwordHasher.VerifyHashedPassword(Users, Users.passwordHash, login.Password);
                if (PasswordResult == PasswordVerificationResult.Success)
                {
                    var lives = Users.lives;
                    var Claims = new List<Claim>
                    {
                      new Claim(ClaimTypes.Name,login.Name),
                      new Claim("DaysLived",lives.ToString()) 
                    };

                    var claimsIdentity = new ClaimsIdentity(Claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    return new ClaimsPrincipal(claimsIdentity);
                }
            }
            return null;
        }

        public async Task SignInAsync(ClaimsPrincipal claimsPrincipal) 
        {
           await _accessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
           claimsPrincipal,
           new AuthenticationProperties
           {
               ExpiresUtc = DateTime.UtcNow.AddMinutes(60),
               IsPersistent = true
           });
        }
    }
}
