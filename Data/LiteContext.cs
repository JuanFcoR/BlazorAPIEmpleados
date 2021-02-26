using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorAPIEmpleados.Data
{
    public class LiteContext : DbContext
    {
        //Contexto manual con SQLite
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=/Data/Database.db");
        }
    }
}
