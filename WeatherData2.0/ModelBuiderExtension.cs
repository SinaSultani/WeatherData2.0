using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WeatherData2._0.Models;

namespace WeatherData2._0
{
    public static class ModelBuiderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Enviornment>().HasData(

                new Enviornment
                {
                    Id = 1,
                    Date = DateTime.Now,
                    Temperature = -3,
                    Humidity = 60,
                    InsideOrOutside = "Outside"

                },
                new Enviornment
                {
                    Id = 2,
                    Date = DateTime.Now,
                    Temperature = 25.2f,
                    Humidity = 20,
                    InsideOrOutside = "Inside"

                },
                new Enviornment
                {
                    Id = 3,
                    Date = DateTime.Now,
                    Temperature = 2,
                    Humidity = 80,
                    InsideOrOutside = "Outside"
                },
                new Enviornment
                {
                    Id = 4,
                    Date = DateTime.Now,
                    Temperature = 28.1f,
                    Humidity = 18,
                    InsideOrOutside = "Inside"

                }
                );
        }

    }
}
