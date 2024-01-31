using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Validations
{
    public class StringRangeAttribute : ValidationAttribute
    {
        public string[] AllowableValues { get; set; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || AllowableValues?.Contains(value?.ToString()) == true)
            {
                return ValidationResult.Success;
            }
            ErrorMessage ??= "Chỉ được chọn những giá trị sau {0}";
            var msg = string.Format(ErrorMessage, string.Join(", ", AllowableValues));
            return new ValidationResult(msg);
        }
    }
}
