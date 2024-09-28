using Microsoft.Identity.Client;
using Philharmonic.Services.CustomAttributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Philharmonic.Models
{
    public class Register
    {
        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public string? name { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        [MinLength(8,ErrorMessage = "Пароль должен быть не менне 8 символов")]
        public string? password { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        [Compare("password",ErrorMessage = "Пароли не совпадают")]
        public string? confirmPassword { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public DateTime? firstDate { get; set; }

        [NowOrSecond("currentDate")]
        public DateTime? secondDate { get; set; }

        public DateTime NowDate { get; } = DateTime.Now;

        public bool currentDate { get; set; }
        public int Lives { get; set; }
        public int GetDifferenceDate()
        {
            if (firstDate != null)
            {
                if (secondDate != null)
                {
                    return firstDate.Value.Subtract(secondDate.Value).Days;
                }
                else
                {
                    return NowDate.Subtract(firstDate.Value).Days;
                }
            }
            return 0;
        }
    }
}
