using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaTienda.Models
{
    [Table("Pagos")]
    public class Pagos
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "La venta es obligatoria")]
        [Display(Name = "ID Venta")]
        public int VentaId { get; set; }

        [ForeignKey("VentaId")]
       

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
        public string EstadoPago { get; set; } = "Pagado";
    }
}