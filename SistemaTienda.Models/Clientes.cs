using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace SistemaTienda.Models
{
    public class Clientes
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El apellido es obligatorio")]
        [Display(Name = "Apellido")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "El DUI es obligatorio")]
        [RegularExpression(@"^\d{8}-\d$", ErrorMessage = "El formato del DUI debe ser 12345678-9")]
        [Display(Name = "DUI")]
        public string DUI { get; set; }

        [Required(ErrorMessage = "El correo es obligatorio")]
        [EmailAddress(ErrorMessage = "Ingrese un correo válido")]
        [Display(Name = "Correo")]
        public string Correo { get; set; }

        [Required(ErrorMessage = "El teléfono es obligatorio")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Solo se permiten números en el teléfono")]
        [Display(Name = "Teléfono")]
        public string Telefono { get; set; }

        public bool Estado { get; set; } = true;
    }
}
