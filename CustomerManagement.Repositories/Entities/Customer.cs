using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerManagement.Persistence.Entities
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Codigo { get; set; }

        [Display(Name = "Tipo Documento")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string TipoDocumento { get; set; } = null!;

        [Display(Name = "Número Documento")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public long NumeroDocumento { get; set; }

        [RegularExpression(@"^[a-zA-Z]+[ a-zA-Z-_]*$", ErrorMessage = "Debe ingresar solo letras en el campo {0}.")]
        [MaxLength(30, ErrorMessage = "El campo {0} tiene un máximo de {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Nombres { get; set; } = null!;

        [Display(Name = "Primer Apellido")]
        [MaxLength(30, ErrorMessage = "El campo {0} tiene un máximo de {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Apellido_1 { get; set; } = null!;

        [Display(Name = "Segundo Apellido")]
        [MaxLength(30, ErrorMessage = "El campo {0} tiene un máximo de {1} caractéres.")]
        public string Apellido_2 { get; set; } = null!;

        [Display(Name = "Género")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Genero { get; set; } = null!;

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Fecha Nacimiento")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public DateTime FechaNacimiento { get; set; }

        [MaxLength(100, ErrorMessage = "El campo {0} tiene un máximo de {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} debe tener al menos una dirección.")]
        public string Direcciones { get; set; } = null!;

        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Debe ingresar solo números en el campo {0}.")]
        [Display(Name = "Teléfonos")]
        [MaxLength(100, ErrorMessage = "El campo {0} tiene un máximo de {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} debe tener al menos un teléfono.")]
        public string Telefonos { get; set; } = null!;

        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Formato no valido para el campo email.")]
        [MaxLength(100, ErrorMessage = "El campo {0} tiene un máximo de {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Emails { get; set; } = null!;
    }
}
