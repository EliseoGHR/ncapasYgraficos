using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrurebaaNCapas.EntidadesDeNegocio
{
    public class PersonaA
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "El nombre debe tener entre 2 y 50 caracteres")]
        public string Nombre { get; set; }
  
        [StringLength(200, MinimumLength = 2, ErrorMessage = "La dirección debe tener entre 2 y 200 caracteres")]
        public string? Direccion { get; set; }

        [Required(ErrorMessage = "Fecha de Nacimiento es requerido")]
        [Display(Name = "Fecha de Nacimiento")]
        public DateTime FechaNacimiento { get; set; }

        [Required(ErrorMessage = "El Telefono es obligatorio.")]
        [StringLength(8, ErrorMessage = "El teléfono debe tener exactamente 8 dígitos", MinimumLength = 8)]
        [RegularExpression("^[0-9]+$", ErrorMessage = "El campo Telefono solo debe contener números.")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "Correo Electrónico es requerido")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "El Correo Electrónico debe tener entre 2 y 50 caracteres")]
        [EmailAddress(ErrorMessage = "El correo no es valido, por favor ingrese un correo válido.")]
        [Display(Name = "Correo Electronico")]
        public string CorreoElectronico { get; set; }

        [NotMapped]
        public int Take { get; set; }
    }
}
