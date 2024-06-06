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

    }
}

