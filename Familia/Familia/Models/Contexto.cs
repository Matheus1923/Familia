using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Familia.Models
{
    public class Contexto : DbContext
    {
        public DbSet<Pai> Pais { get; set; }
        public DbSet<Mae> Maes { get; set; }
        public DbSet<Filho> Filhos { get; set; }
        public Contexto(DbContextOptions<Contexto> opcoes) : base(opcoes)
        {

        }
    }
}
