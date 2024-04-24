using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProEventos.Domain
{
    public class Lote
    {
        public int id { get; set; }
        public string nome { get; set; }
        public decimal preco { get; set; }
        public DateTime? DataInicio { get; set; }
         public DateTime? DataIFim { get; set; }
         public int Quantidade { get; set; }
         public int EventoId { get; set; }
         public Evento Evento { get; set; }
    }
}