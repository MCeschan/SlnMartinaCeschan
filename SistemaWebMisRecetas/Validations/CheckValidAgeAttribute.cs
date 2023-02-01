using System.ComponentModel.DataAnnotations;

namespace SistemaWebMisRecetas.Validations
{
    public class CheckValidAgeAttribute: ValidationAttribute
    {
        public CheckValidAgeAttribute()
        {
            ErrorMessage = "La edad debe ser mayor o igual a 18";
        }
        public override bool IsValid(object value)
        {
            int edad = (int)value;
            if (edad < 18)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
