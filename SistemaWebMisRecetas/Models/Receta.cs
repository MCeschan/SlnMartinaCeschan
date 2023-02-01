using SistemaWebMisRecetas.Validations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaWebMisRecetas.Models
{
    public class Receta
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Este es un campo obligatorio")]
        [Column(TypeName = "varchar(50)")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Este es un campo obligatorio")]
        [Column(TypeName = "varchar(50)")]
        [CheckCategoria]
        public string Categoria { get; set; }

        [Required(ErrorMessage = "Este es un campo obligatorio")]
        [DataType(DataType.MultilineText)]
        public string Ingredientes { get; set; }

        [Required(ErrorMessage = "Este es un campo obligatorio")]
        [DataType(DataType.MultilineText)]
        public string Instrucciones { get; set; }
        [Required(ErrorMessage = "Este es un campo obligatorio")]
        [Column(TypeName = "varchar(50)")]
        public string Autor { get; set; }
        [Required(ErrorMessage = "Este es un campo obligatorio")]
        [Column(TypeName = "varchar(50)")]
        public string Apellido { get; set; }
        [Required(ErrorMessage = "Este es un campo obligatorio")]
        [CheckValidAge]
        public int Edad { get; set; }
        [Required(ErrorMessage = "Este es un campo obligatorio")]
        [RegularExpression("^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$", ErrorMessage = "Solo formas válidas de email")]
        public string Email { get; set; }
    }
}
