using Inventario.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventario.Data
{
    public class DataContext : IdentityDbContext<Users>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Assignation> Assignations { get; set; }
        public DbSet<Bodega> Bodegas { get; set; }
        public DbSet<Conteo> Conteos { get; set; }
        public DbSet<Detail> Details { get; set; }
        public DbSet<Ubicacion> Ubicacions { get; set; }
        public DbSet<Zonas> Zonas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
       
    }
}
