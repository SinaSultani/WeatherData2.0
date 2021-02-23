using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace WeatherData2._0
{
    public class WeatherDbContextFactory : IDesignTimeDbContextFactory<WeatherDbContext>
    {
        public WeatherDbContext CreateDbContext(string[] args = null)
        {
            var configuartion = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var optionsBuilder = new DbContextOptionsBuilder<WeatherDbContext>();

            //optionsBuilder.UseSqlServer(configuartion["ConnectionStrings:DefaultConnection"]);
            optionsBuilder.UseSqlServer(configuartion.GetConnectionString("DefaultConnection"));

            return new WeatherDbContext(optionsBuilder.Options);
        }
    }
}
