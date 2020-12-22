using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Inventario.Data.Entities
{
    public class Conteo
    {
        public int Id { get; set; }

        [Display(Name = "Nombre De la Sede")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [MaxLength(70, ErrorMessage = "El Campo {0} acepta solo {1} caracteres.")]
        public string Nombre { get; set; }


  

    }
}
