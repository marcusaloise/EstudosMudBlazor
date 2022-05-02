using Microsoft.AspNetCore.Mvc;
using ProvadoLilão.core.Data;
using ProvadoLilão.core.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProvadoLilão.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventosController : ControllerBase
    {
        private readonly EventoContext _db;

        public EventosController(EventoContext db)
        {
            _db = db;
        }


        // GET: api/<EventosController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_db.Eventos);
        }

        // GET api/<EventosController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var evento = _db.Eventos.Find(id);
            if (evento == null)
                return NotFound();


            return Ok(evento);
        }

        // POST api/<EventosController>
        [HttpPost]
        public IActionResult Post([FromBody] Evento evento)
        {
            if (evento == null)
                return BadRequest();

            _db.Eventos.Add(evento);
            _db.SaveChanges();

            return Created($"eventos/{evento.Id}", evento); 
        }

        // PUT api/<EventosController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Evento evento)
        {
            if (id != evento.Id)
                return BadRequest();


            _db.Eventos.Update(evento);
            _db.SaveChanges();

            return NoContent();
        }

        // DELETE api/<EventosController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var evento = _db.Eventos.Find(id);
            if (evento == null)
                return NotFound();
            _db.Eventos.Remove(evento);
            _db.SaveChanges();
            return NoContent(); 
        }
    }
}
