using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProEventos.Persistence;
using ProEventos.Domain;
using ProEventos.Persistence.Contextos;
using ProEventos.Application.Contratos;
using Microsoft.AspNetCore.Http;





namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventosController : ControllerBase
    {
       // Essa é a chamada do meu contexto na minha controler e o "READONLY" siguinifica que ele não pode ser alterado após a inicialização. o valor desse campo se torna apenas leitura. 
        
        private readonly IEventoService _eventoService;

       public  EventosController (IEventoService eventoService){
            _eventoService = eventoService;
            
    
       }

     
          [HttpGet]
        public async Task <IActionResult> Get()
        {
          try
          {
            var eventos = await _eventoService.GetAllEventosAsync(true);
            if (eventos == null) return NotFound("Nenhum evento encontrado");

            return Ok(eventos);
          }
          catch (Exception ex)
          {
            
            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar Eventos. erro: {ex.Message}");
          }
          
        }
        [HttpGet("{id}")]
        public  async Task <IActionResult> GetById(int id)
        {
          try
          {
            var evento = await _eventoService.GetEventoByIdAsync(id, true);
            if (evento == null) return NotFound("Evento por id não encontrado");

            return Ok(evento);
          }
          catch (Exception ex)
          {
            
            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar Eventos. erro: {ex.Message}");
          }
          
        }
        [HttpGet("{tema}/tema")]
        public  async Task <IActionResult> GetByTema(string tema)
        {
          try
          {
            var evento = await _eventoService.GetAllEventosByTemaAsync(tema, true);
            if (evento == null) return NotFound("Eventos por tema não encontrado");

            return Ok(evento);
          }
          catch (Exception ex)
          {
            
            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar Eventos. erro: {ex.Message}");
          }
          
        }
         [HttpPost]
        public async Task<IActionResult> Post(Evento model)
        {
          try
          {
            var evento = await _eventoService.AddEvento(model);
            if (evento == null) return BadRequest("Erro ao tentar adicionar evento.");

            return Ok(evento);
          }
          catch (Exception ex)
          {
            
            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar Adicionar Eventos. erro: {ex.Message}");
          }
        }
          [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Evento model)
        {
          try
          {
            var evento = await _eventoService.UpdateEvento(id, model);
            if (evento == null) return BadRequest("Erro ao tentar adicionar evento.");

            return Ok(evento);
          }
          catch (Exception ex)
          {
            
            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar Atualizar Eventos. erro: {ex.Message}");
          }
        }
        

          [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
          try
          {
              if(await _eventoService.DeleteEvento(id))
                return Ok("Deletado");
              
                else
                  return BadRequest("evento não deletado");
                
          }
          catch (Exception ex)
          {
            
            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar deletar Eventos. erro: {ex.Message}");
          }
        }
        }
    }

