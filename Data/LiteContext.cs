using BlazorAPIEmpleados.Models.Request;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorAPIEmpleados.Data
{
    public class LiteContext : DbContext
    {
        public virtual DbSet<Empleados> Empleados { get; set; }
        public virtual DbSet<Estatus> Estatuses { get; set; }
        //Contexto manual con SQLite
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=/Data/Database.db");
        }
    }
}
