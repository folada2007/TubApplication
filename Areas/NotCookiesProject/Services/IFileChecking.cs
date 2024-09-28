using Philharmonic.Areas.NotCookiesProject.Models;

namespace Philharmonic.Areas.NotCookiesProject.Services
{
    public interface IFileChecking
    {
        void DeliteFile();
        bool ConditionFile();
        DateModel ReadFile();
        void WriteFile(DateModel model);
    }
}
