using System.ComponentModel.DataAnnotations;

namespace Philharmonic.Areas.NotCookiesProject.Models
{
    public class DateModel
    {
        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public DateTime FirstDate { get; set; }
        [Custom("UseCurrentDate")]
        public DateTime? LastDate { get; set; }
        [Display(Name = "Указать текущую дату ?")]
        public DateTime NowDate { get; } = DateTime.Now;

        public bool UseCurrentDate { get; set; }

        public TimeSpan GetDateDifference()
        {
            if (LastDate != null)
            {
                return FirstDate.Subtract(LastDate.Value);
            }
            else
            {
                return NowDate.Subtract(FirstDate);
            }
        }

    }
}
