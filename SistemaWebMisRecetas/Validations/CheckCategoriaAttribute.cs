using System.ComponentModel.DataAnnotations;

namespace SistemaWebMisRecetas.Validations
{
    public class CheckCategoriaAttribute : ValidationAttribute
    {
        public CheckCategoriaAttribute()
        {
            ErrorMessage = "La categoría solo puede ser desayuno";
        }
        public override bool IsValid(object value)
        {
            string categoria = (string)value;
            if (categoria == "desayuno")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
