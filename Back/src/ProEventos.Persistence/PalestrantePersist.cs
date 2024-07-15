using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;
using ProEventos.Persistence.Contextos;
using ProEventos.Persistence.Contratos;

namespace ProEventos.Persistence
{
    public class PalestrantePersist : IPalestrantePersist
    {
        private readonly DataContext _context;

        public PalestrantePersist(DataContext context)
        {
            _context = context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        
        public async Task<Palestrante[]> GetAllPalestranteAsync(bool includeEventos = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
            
            .Include(p => p.RedesSociais);

            if (includeEventos)
            {
                query = query.Include(p => p.PalestranteEventos)
                .ThenInclude(pe => pe.Eventos);
            }

            query = query.OrderBy(p => p.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Palestrante[]> GetAllPalestranteByNomeAsync(string nome, bool includeEventos)
        {
           IQueryable<Palestrante> query = _context.Palestrantes
            
            .Include(p => p.RedesSociais);

            if (includeEventos)
            {
                query = query.Include(p => p.PalestranteEventos)
                .ThenInclude(pe => pe.Eventos);
            }

            query = query.OrderBy(p => p.Id)
            .Where(p => p.Nome.ToLower().Contains(nome.ToLower()));

            return await query.ToArrayAsync();
        }

      

        public async Task<Palestrante> GetPalestranteByIdAsync(int PalestranteId, bool includeEventos)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
            
            .Include(p => p.RedesSociais);

            if (includeEventos)
            {
                query = query.Include(p => p.PalestranteEventos)
                .ThenInclude(pe => pe.Eventos);
            }

            query = query.OrderBy(p => p.Id)
            .Where(p => p.Id == PalestranteId);

            return await query.FirstOrDefaultAsync();
        }

      

      
    }
}