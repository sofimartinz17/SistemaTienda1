using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SistemaTienda.Models
{
    public class Producto
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Ingrese un nombre del producto")]
        [Display(Name = "Nombre del Producto")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La descripcion es obligatoria")]
        public string Descripcion { get; set; }

        [Display(Name = "Fecha Creación")]
        [DataType(DataType.Date)]
        public DateTime FechaCreacion { get; set; }

        [DataType(DataType.ImageUrl)]
        [Display(Name = "Imagen Producto")]
        public string UrlImagen { get; set; }

        [Required]
        public int CategoriaId { get; set; }

        [ForeignKey("CategoriaId")]
        public Categoria Categoria { get; set; }

        [Required(ErrorMessage = "Ingrese el número de placa")]
        [Display(Name = "Número de Placa")]
        public string NumeroPlaca { get; set; }

        [Required(ErrorMessage = "Ingrese el precio")]
        [DataType(DataType.Currency)]
        public decimal Precio { get; set; }

        [Required(ErrorMessage = "Ingrese el modelo")]
        public string Modelo { get; set; }

        [Required(ErrorMessage = "Ingrese el año")]
        [Range(1900, 2100, ErrorMessage = "Ingrese un año válido")]
        public int Año { get; set; }

        [Required(ErrorMessage = "Ingrese el color disponible")]
        [Display(Name = "Color Disponible")]
        public string ColorDisponible { get; set; }
    }
}
