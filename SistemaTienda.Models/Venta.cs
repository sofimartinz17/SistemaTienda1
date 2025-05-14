using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaTienda.Models
{
    public class Venta
    {
        [Key] // Clave primaria
        public int Id { get; set; }

        [Required(ErrorMessage = "Ingrese un nombre del Cliente")]
        [Display(Name = "Nombre del Cliente")]
        public string Namecliente { get; set; }

        [Required(ErrorMessage = "El DUI es obligatorio")]
        [RegularExpression(@"^\d{8}-\d$", ErrorMessage = "El formato del DUI debe ser 12345678-9")]
        [Display(Name = "DUI")]
        public string DUI { get; set; }

        [Required(ErrorMessage = "Ingrese un nombre del Vehiculo")]
        [Display(Name = "Nombre del Vehiculo")]
        public string Namecarro { get; set; }

        [Required(ErrorMessage = "La fecha del pago es obligatoria")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Pago")]
        public DateTime FechaPago { get; set; }

        [Required(ErrorMessage = "El monto es obligatorio")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El monto debe ser mayor a cero")]
        [Display(Name = "Monto Pagado")]
        public decimal Monto { get; set; }

        [Required(ErrorMessage = "Debe seleccionar un método de pago")]
        [StringLength(50)]
        [Display(Name = "Método de Pago")]
        public string MetodoPago { get; set; }

        [Display(Name = "Estado del Pago")]
        [StringLength(20)]
        public string EstadoPago { get; set; } 
    }
}
