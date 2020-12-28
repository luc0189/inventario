using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Inventario.Data.Entities
{
    public class Zonas
    {
        public int Id { get; set; }

        [Display(Name = "Nombre De la Zona")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [MaxLength(70, ErrorMessage = "El Campo {0} acepta solo {1} caracteres.")]
        public string NombreZona { get; set; }

        [Display(Name = "Asig")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [MaxLength(70, ErrorMessage = "El Campo {0} acepta solo {1} caracteres.")]
        public string Asg { get; set; }
        public DateTime FechaActualización { get; set; }
        public Bodega Bodega { get; set; }

    }
}
