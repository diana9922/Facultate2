using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Facultate2.Models;

namespace Facultate2.Data
{
    public class Facultate2Context : DbContext
    {
        public Facultate2Context (DbContextOptions<Facultate2Context> options)
            : base(options)
        {
        }

        public DbSet<Facultate2.Models.Student> Student { get; set; }

        public DbSet<Facultate2.Models.Profesor> Profesor { get; set; }

        public DbSet<Facultate2.Models.Specializare> Specializare { get; set; }
    }
}
