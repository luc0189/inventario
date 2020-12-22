using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventario.Data.Entities
{
    public class Detail
    {
        public int Id { get; set; }
        public int Factor { get; set; }
        public int CantDigitada { get; set; }
        public int CantTotal { get; set; }
        public string Plu { get; set; }
        public string Nombre { get; set; }
        public string Cbarra { get; set; }

        //asignacion Id
    }
}
