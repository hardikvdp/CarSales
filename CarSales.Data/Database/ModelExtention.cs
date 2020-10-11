using CarSales.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarSales.Data.Database
{
    public static class ModelExtention
    {
        public static void SeedData(this ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<BodyType>().HasData(

                new BodyType
                {
                    Id = 1,
                    BodyTypeName = "HATCHBACK"
                },
                new BodyType
                {
                    Id = 2,
                    BodyTypeName = "SEDAN"
                },
                new BodyType
                {
                    Id = 3,
                    BodyTypeName = "UTE"
                }
                );

            modelBuilder.Entity<VehicleType>().HasData(

                new VehicleType
                {
                    Id = 1,
                    VehicleTypeName = "Car"
                },
                new VehicleType
                {
                    Id = 2,
                    VehicleTypeName = "Boat"
                },
                new VehicleType
                {
                    Id = 3,
                    VehicleTypeName = "Bike"
                }
                );

            modelBuilder.Entity<Car>().HasData(
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
                  },
                  new Car
                  {
                      Id = 4,
                      Make = "Toyota",
                      Model = "HiAce",
                      BodyTypeId = 3,
                      Engine = "AUTO",
                      Wheels = 4,
                      Price = 30000,
                      Doors = 2,
                      VehicleTypeId = 1,
                      Created = DateTime.Now
                  }
                );
        }
    }
}
