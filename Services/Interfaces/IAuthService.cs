using Philharmonic.Models;
using System.Security.Claims;

namespace Philharmonic.Services.Interfaces
{
    public interface IAuthService
    {
        Task<ClaimsPrincipal> AuthenticationUserAsync(Login login);
        Task SignInAsync(ClaimsPrincipal claimsPrincipal);
    }
}
