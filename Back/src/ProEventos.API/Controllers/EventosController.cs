﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProEventos.API.Data;
using ProEventos.API.Models;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventosController : ControllerBase
    {
       
        private readonly DataContext _context;

       public  EventosController (DataContext context){
            _context = context;
        
      

       }
      
  
     
          [HttpGet]
        public IEnumerable<Evento> Get()
        {
          
          return _context.Eventos.ToList();
        }
        [HttpGet("{id}")]
        public Evento GetById(int id)
        {
          return _context.Eventos.FirstOrDefault(evento => evento.EventoId == id);
          
        }
         [HttpPost]
        public string Post()
        {
          return "Exemplo de Post";
        }
          [HttpPut("{id}")]
        public string Put(int id)
        {
          return $"Exemplo de put {id}";
        }
          [HttpDelete("{id}")]
        public string Delete(int id)
        {
          return $"Exemplo de Delete {id}";
        }
    }
}
