using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEventos.API.Models;

namespace ProEventos.API.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Evento> Eventos { get; set; }
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