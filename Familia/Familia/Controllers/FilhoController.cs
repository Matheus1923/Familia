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
    public class FilhoController : ControllerBase
    {
        public Contexto Contexto { get; set; }

        public FilhoController (Contexto novoContexto)
        {
            this.Contexto = novoContexto;
        }

        [HttpGet]

        public List<Filho> Get()
        {
            return Contexto.Filhos.ToList();
        }

        [HttpGet("{id}")]
        public Filho Get(int id)
        {
            return Contexto.Filhos.First(p => p.IdFilho == id);
        }

        [HttpGet("nome/{idnome}")]

        public List<Filho> Filtrar(string Nome)
        {
            return Contexto.Filhos.Where(p => p.Nome == Nome).ToList();
        }

        [HttpPost]
        [Route("add")]

        public async Task<ActionResult<Filho>> Create(Filho Filho)
        {
            Filho.IdFilho = 0;
            Contexto.Filhos.Add(Filho);
            await Contexto.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = Filho.IdFilho, Filho });
        }

        [HttpPost]
        [Route("update")]

        public async Task<ActionResult<Filho>> Update(Filho Filho)
        {
            Contexto.Filhos.Update(Filho);
            await Contexto.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = Filho.IdFilho, Filho });
        }
    }
}
