using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProEventos.Domain
{
    // Essa classe está recebendo a Chave FK de Eventos. Essa relação é de Um para Muitos ( Eventos tem 1,n Lotes) e ( Lotes tem 1,1 Eventos)
    // Por esse motivo a classe de muitos geralmente são as que recebem a FK, ja a classe 1,1 recebe uma lista de lotes public IEnumerable<Lote> Lote { get; set; }
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