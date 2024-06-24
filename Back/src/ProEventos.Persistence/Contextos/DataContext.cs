using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;

namespace ProEventos.Persistence.Contextos
{
    public class DataContext : DbContext
    {
        // Aqui definimos todos os Models do nosso projeto. ao chamarmos o metodo DbSet o entity mapea nossas entidades. 
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Lote> Lotes { get; set; }
        public DbSet<Palestrante> Palestrantes { get; set; }
        public DbSet<PalestranteEvento> PalestrantesEventos { get; set; }
        public DbSet<RedeSocial> RedeSociais { get; set; }

        // Esse trexo de Codigo, estamos sobrescrevendo um metodo da classe do EntityFramework a DB Context que nossa classe DataContext Herda. 
        // OnModelCreating: Estamos pegando esse metodo e definindo um parametro do tipo ModelBuilder e chamando de modelbuilder para usar ele dentro do metodo que estamos sobrescrevendo.
        // Na linha seguinte estamos dizendo pro entity que a classe PalestranteEventos vai receber 2 foreing Keys a de Evento e a de Palestrante. 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PalestranteEvento>().HasKey(PE => new {PE.EventoID, PE.PalestranteID});
        }

        // Aqui fica o metodos de configuração do banco de dados. 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string connectionString = 
                    "Server=localhost;" +
                    "Database=ProEventos;" +
                    "User=SA;" +
                    "Password=992534@Tx;" +
                    "Encrypt=false;TrustServerCertificate=true;";

                optionsBuilder.UseSqlServer(connectionString);
            }
        }
    }
    
}