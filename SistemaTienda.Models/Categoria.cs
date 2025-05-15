using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaTienda.Models
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre de la categoria es requerido")]
        [Display(Name = "Nombre de CAtegoria")]

        public string Nombre { get; set; }

        [Required]
        [Display(Name ="Ingrese orden ve visualizacion")]

        public int Orden { get; set; }
    }
}
