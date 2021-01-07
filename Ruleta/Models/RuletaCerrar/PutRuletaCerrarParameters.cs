using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ruleta.Models.RuletaCerrar
{
    public class PutRuletaCerrarParameters
    {
        [Required]
        public int? RuletaID { get; set; }
        [Required]
        public bool? Estado { get; set; }

        public int? NumeroGanador { get; set; }
        public Apuestas[] ApuestasTotales  { get; set; }

        public class Apuestas
        {
            public int? JugadorID { get; set; }
            public int? DineroApostado { get; set; }
            public int? CampoApuestaID { get; set; }
            public double? RetornoApuesta { get; set; }
        }
    }
}