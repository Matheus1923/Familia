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
    public class MaeController : ControllerBase
    {
        public Contexto Contexto { get; set; }

        public MaeController (Contexto novoContexto)
        {
            this.Contexto = novoContexto;
        }

        [HttpGet]

        public List<Mae> Get()
        {
            return Contexto.Maes.ToList();
        }

        [HttpGet("{id}")]
        public Mae Get(int id)
        {
            return Contexto.Maes.First(p => p.IdMae == id);
        }

        [HttpGet("nome/{idnome}")]

        public List<Mae> Filtrar(string Nome)
        {
            return Contexto.Maes.Where(p => p.Nome == Nome).ToList();
        }

        [HttpPost]
        [Route("add")]

        public async Task<ActionResult<Mae>> Create(Mae Mae)
        {
            Mae.IdMae = 0;
            Contexto.Maes.Add(Mae);
            await Contexto.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = Mae.IdMae, Mae });
        }

        [HttpPost]
        [Route("update")]

        public async Task<ActionResult<Mae>> Update(Mae Mae)
        {
            Contexto.Maes.Update(Mae);
            await Contexto.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = Mae.IdMae, Mae });
        }
    }
}
