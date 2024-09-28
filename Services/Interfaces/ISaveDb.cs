using Philharmonic.Models;

namespace Philharmonic.Services.Interfaces
{
    public interface ISaveDb
    {
        Task RegistrationUser(Register register);
    }
}
