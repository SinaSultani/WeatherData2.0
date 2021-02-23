using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WeatherData2._0.Models;

namespace WeatherData2._0
{
    public class WeatherDbContext : DbContext
    {
        public WeatherDbContext()
        {
        }

        public DbSet<Enviornment> Enviornments { get; set; }

        public WeatherDbContext(DbContextOptions<WeatherDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
        }
    }
}
