using System.ComponentModel.DataAnnotations;

namespace Philharmonic.Services.CustomAttributes
{
    public class NowOrSecond:ValidationAttribute
    {
        private readonly string _dependenceValue;

        public NowOrSecond(string dependenceValue) 
        {
            _dependenceValue = dependenceValue;
        }

        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            var info = validationContext.ObjectType.GetProperty(_dependenceValue);

            if (info == null) return new ValidationResult($"хз че за хуйня {_dependenceValue}");

            var depVal = info.GetValue(validationContext.ObjectInstance, null);
            if (depVal is bool currentDate && !currentDate && value == null)
            {
                return new ValidationResult(ErrorMessage ?? "Поле обязательно для заполнения");
            }
            else if(value != null && depVal is bool UseCurrentDate && UseCurrentDate) 
            {
                return new ValidationResult(ErrorMessage ?? $"Выберите {_dependenceValue} если желаете использовать текущую дату и {validationContext.DisplayName} если желаете использовать собственную");
            }

            return ValidationResult.Success;
        }


    }
}
