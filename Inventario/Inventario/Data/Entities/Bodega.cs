﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Inventario.Data.Entities
{
    public class Bodega
    {
        public int Id { get; set; }

        [Display(Name = "Nombre De la Bodega")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [MaxLength(70, ErrorMessage = "El Campo {0} acepta solo {1} caracteres.")]
        public string NameBodega { get; set; }
            
        public DateTime FechaActualización { get; set; }
        public ICollection<Zonas> Zonas { get; set; }

    }
}
