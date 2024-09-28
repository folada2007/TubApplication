using Microsoft.AspNetCore.Identity;
using Philharmonic.Services.Interfaces;

namespace Philharmonic.Models
{
    public class SaveDb:ISaveDb
    {
        private readonly ApplicationDbContext _context;
        private readonly PasswordHasher<User> _passwordHasher;

        public SaveDb(ApplicationDbContext context, PasswordHasher<User> passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
        }

        public async Task RegistrationUser(Register register)
        {
            var user = new User
            {
                name = register.name,
                lives = register.Lives
            };

            user.passwordHash = _passwordHasher.HashPassword(user, register.password);
            _context.auths.Add(user);
            await _context.SaveChangesAsync();
        }

    }
}
