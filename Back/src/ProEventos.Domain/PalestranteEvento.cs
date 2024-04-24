using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProEventos.Domain
{
    public class PalestranteEvento
    {
        public int PalestranteID { get; set; }
        public Palestrante Palestrantes { get; set; }
        public int EventoID { get; set; }
        public Evento Eventos { get; set; }
    }
}