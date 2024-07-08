using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication_PNT1.Models;
using System.Collections.Generic;

namespace WebApplication_PNT1.Context
{
    public class WebAppDatabaseContext : DbContext
    {
        public WebAppDatabaseContext(DbContextOptions<WebAppDatabaseContext> options): base(options)
        {
        }
        public DbSet<Proyecto> Proyectos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Pedido>()
                .HasKey(p => p.IdPedido);
            modelBuilder.Entity<Proyecto>()
                .HasKey(p => p.IdProyecto);

            // Configurar la relación uno a uno entre Pedido y Proyecto
            modelBuilder.Entity<Pedido>()
                .HasOne(p => p.Proyecto)
                .WithOne(p => p.Pedido)
                .HasForeignKey<Pedido>(p => p.ProyectoId)
                .OnDelete(DeleteBehavior.Cascade); // Configuración de eliminación en cascada (opcional)
        }
    }
    }


