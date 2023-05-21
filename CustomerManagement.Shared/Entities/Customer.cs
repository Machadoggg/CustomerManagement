using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerManagement.Shared.Entities
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Range(1, 99999999999)]
        [StringLength(11)]
        [Required]
        public long Codigo { get; set; }

        [Display(Name = "Tipo Documento")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string TipoDocumento { get; set; } = null!;

        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Debe ingresar solo números.")]
        [Display(Name = "Número Documento")]
        [MaxLength(11, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public long NumeroDocumento { get; set; }

        [MaxLength(30, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Nombres { get; set; } = null!;

        [Display(Name = "Primer Apellido")]
        [MaxLength(30, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Apellido_1 { get; set; } = null!;

        [Display(Name = "Segundo Apellido")]
        [MaxLength(30, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        public string Apellido_2 { get; set; } = null!;

        [Display(Name = "Género")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Genero { get; set; } = null!;

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Fecha Nacimiento")]
        [MaxLength(11)]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public DateTime FechaNacimiento { get; set; }

        [MaxLength(100, ErrorMessage = "El campo {0} tiene un máximo de {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} debe tener al menos un dirección.")]
        public string Direcciones { get; set; } = null!;

        [Display(Name = "Teléfonos")]
        [MaxLength(100, ErrorMessage = "El campo {0} tiene un máximo de {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} debe tener al menos un teléfono.")]
        public string Telefonos { get; set; } = null!;

        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Formato no valido para email.")]
        [MaxLength(100, ErrorMessage = "El campo {0} tiene un máximo de {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Emails { get; set; } = null!;
    }
}
