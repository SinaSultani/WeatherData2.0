using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WeatherData2._0.Models;

namespace WeatherData2._0
{
    public class WeatherDbContext : DbContext
    {

        public DbSet<Enviornment> Enviornments { get; set; }

        public static void Initialize(WeatherDbContext context)
        {
            context.Database.EnsureCreated();
            var readWeather = context.Enviornments.FirstOrDefault();
            CultureInfo commaCorrector = CultureInfo.InvariantCulture;

            if (readWeather is null)
            {
                string WeatherPath = "TempFuktData_5.csv";
                List<string> weatherLines = File.ReadAllLines(WeatherPath)
                    .Skip(1)
                    .Distinct()
                    .ToList();

                int errorCount = 0;

                if (weatherLines.Count > 0)
                {
                    foreach (var line in weatherLines)
                    {

                        var weatherData = line.Split(',');


                        Enviornment env = new Enviornment();
                        try
                        {
                            env.Date = Convert.ToDateTime(weatherData[0]);
                            env.Humidity = Convert.ToInt32(weatherData[3]);
                            env.Temperature = (float)Convert.ToDouble(weatherData[2], commaCorrector);
                            env.InsideOrOutside = weatherData[1];
                            context.Enviornments.Add(env);

                        }
                        catch (FormatException)
                        {
                            env.Temperature = (float)int.Parse(weatherData[2]);
                        }
                        catch (Exception e)
                        {
                            errorCount++;
                            //Console.WriteLine(e.Message);
                        }
                    }
                    Console.WriteLine($"{errorCount} rows failed to load.");
                    context.SaveChanges();
                }
            }
        }

        public WeatherDbContext()
        {
        }

        

        public WeatherDbContext(DbContextOptions<WeatherDbContext> options) : base(options) { }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{

        //    modelBuilder.Seed();
        //}



    }
}

