using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Philharmonic.Areas.NotCookiesProject.Models
{

    public class CustomAttribute : ValidationAttribute
    {
        private readonly string _dependentProperty;
        public CustomAttribute(string dependentProperty)
        {
            _dependentProperty = dependentProperty;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var propertyInfo = validationContext.ObjectType.GetProperty(_dependentProperty);
            if (propertyInfo == null)
            {
                return new ValidationResult($"Неизвестное значение{_dependentProperty}");
            }
            var dependentValue = propertyInfo.GetValue(validationContext.ObjectInstance, null);
            if (dependentValue is bool UseCurrentDate && !UseCurrentDate && value == null)
            {
                return new ValidationResult(ErrorMessage ?? "Поле обязательно для заполнения");
            }

            return ValidationResult.Success;
        }
    }
}
