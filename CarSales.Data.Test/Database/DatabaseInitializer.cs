using CarSales.Data.Database;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using CarSales.Data.Models;

namespace CarSales.Data.Test.Database
{
    public class DatabaseInitializer
    {
        public static void Initialize(DBContext context)
        {
            if (context.Cars.Any())
            {
                return;
            }

            Seed(context);
        }

        private static void Seed(DBContext context)
        {
            var cars = new[]
            {
                new Car
                {
                    Id = 1,
                    Make = "Toyota",
                    Model = "Camry",
                    BodyTypeId = 2,
                    Engine = "AUTO",
                    Wheels = 4,
                    Price = 25000,
                    Doors = 4,
                    VehicleTypeId = 1,
                    Created = DateTime.Now
                },
                new Car
                {
                    Id = 2,
                     Make = "Toyota",
                     Model = "Corolla",
                     BodyTypeId = 1,
                     Engine = "AUTO",
                     Wheels = 4,
                     Price = 15000,
                     Doors = 4,
                     VehicleTypeId = 1,
                     Created = DateTime.Now
                },
                new Car
                {
                     Id = 3,
                      Make = "Toyota",
                      Model = "Hilux",
                      BodyTypeId = 3,
                      Engine = "AUTO",
                      Wheels = 4,
                      Price = 35000,
                      Doors = 2,
                      VehicleTypeId = 1,
                      Created = DateTime.Now
                }
            };

            context.Cars.AddRange(cars);
            context.SaveChanges();
        }
    }
}
