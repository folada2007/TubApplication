using Philharmonic.Areas.NotCookiesProject.Services;
using System.Text.Json;

namespace Philharmonic.Areas.NotCookiesProject.Models
{
    public class FileChecking : IFileChecking
    {
        private const string _path = "TestFile.Json";
        public void DeliteFile()
        {
            File.Delete(_path);
        }
        public bool ConditionFile()
        {
            return File.Exists(_path);
        }

        public DateModel ReadFile()
        {
            var reader = File.ReadAllText(_path);

            if (!string.IsNullOrWhiteSpace(reader))
            {
                return JsonSerializer.Deserialize<DateModel>(reader);
            }
            throw new ArgumentException("Sorry your file is void");

        }

        public void WriteFile(DateModel model)
        {
            var writer = JsonSerializer.Serialize(model);
            File.WriteAllText(_path, writer);
        }

    }
}
