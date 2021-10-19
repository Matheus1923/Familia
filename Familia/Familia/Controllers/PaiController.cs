using Familia.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Familia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaiController : ControllerBase
    {
        public Contexto Contexto { get; set; }

        public PaiController(Contexto novoContexto)
        {
            this.Contexto = novoContexto;
        }

        [HttpGet]

        public List<Pai> Get()
        {
            return Contexto.Pais.ToList();
        }

        [HttpGet("{id}")]
        public Pai Get(int id)
        {
            return Contexto.Pais.First(p => p.IdPai == id);
        }

        [HttpGet("nome/{idnome}")]

        public List<Pai> Filtrar(string Nome)
        {
            return Contexto.Pais.Where(p => p.Nome == Nome).ToList();
        }

        [HttpPost]
        [Route("add")]

        public async Task<ActionResult<Pai>> Create (Pai Pai)
        {
            Pai.IdPai = 0;
            Contexto.Pais.Add(Pai);
            await Contexto.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = Pai.IdPai, Pai });
        } 

        [HttpPost]
        [Route("update")]

        public async Task<ActionResult<Pai>> Update(Pai Pai)
        {
            Contexto.Pais.Update(Pai);
            await Contexto.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = Pai.IdPai, Pai });
        }
    }
}
