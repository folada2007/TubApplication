using System.ComponentModel.DataAnnotations;

namespace Philharmonic.Models
{
    public class Login
    {
        [Required(ErrorMessage ="Поле обязательно для заполнения")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public string Password { get; set; }
    }
}
