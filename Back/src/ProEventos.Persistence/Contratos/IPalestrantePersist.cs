using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ProEventos.Domain;

namespace ProEventos.Persistence.Contratos
{
    public interface IPalestrantePersist
    {
                     
             // PALESTRANTES

             Task<Palestrante[]> GetAllPalestranteByNomeAsync(string nome, bool includeEventos);
             Task<Palestrante[]> GetAllPalestranteAsync(bool includeEventos);
             Task<Palestrante> GetPalestranteByIdAsync(int palestranteId, bool includeEventos);
    }
}