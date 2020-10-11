using CarSales.Data.Database;
using CarSales.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using FakeItEasy;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Xunit;
using CarSales.Data.Test.Database;
using CarSales.Data.Repository.v1;

namespace CarSales.Data.Test.Repository
{
    public class CarRepositoryTests : DatabaseTestBase
    {
        private readonly DBContext _dbContext;
        private readonly CarRepository _testee;
        private readonly CarRepository _testeeFake;
        private readonly Car _newCar;

        public CarRepositoryTests()
        {
            _dbContext = A.Fake<DBContext>();
            _testeeFake = new CarRepository(_dbContext);
            _testee = new CarRepository(Context);
            _newCar = new Car
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
            };
        }

        [Fact]
        public void AddAsync_WhenEntityIsNull_ThrowsException()
        {
            _testee.Invoking(x => x.AddAsync(null)).Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void AddAsync_WhenExceptionOccurs_ThrowsException()
        {
            A.CallTo(() => _dbContext.SaveChangesAsync(default)).Throws<Exception>();

            _testeeFake.Invoking(x => x.AddAsync(new Car())).Should().Throw<Exception>().WithMessage("entity could not be saved");
        }

        [Fact]
        public async void AddCarAsync_WhenCarIsNotNull_ShouldReturnBool()
        {
            var result = await _testee.AddAsync(_newCar);

            result.Should().BeOfType<Car>();
        }

        [Fact]
        public async void AddCarAsync_WhenCarIsNotNull_ShouldShouldAddCar()
        {
            var carCount = Context.Cars.Count();

            await _testee.AddAsync(_newCar);

            Context.Cars.Count().Should().Be(carCount + 1);
        }

        [Fact]
        public void GetAll_WhenExceptionOccurs_ThrowsException()
        {
            A.CallTo(() => _dbContext.Set<Car>()).Throws<Exception>();

            _testeeFake.Invoking(x => x.GetAllAsync()).Should().Throw<Exception>().WithMessage("Couldn't retrieve entities");
        }

        [Fact]
        public void UpdateAsync_WhenEntityIsNull_ThrowsException()
        {
            _testee.Invoking(x => x.UpdateAsync(null)).Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void UpdateAsync_WhenExceptionOccurs_ThrowsException()
        {
            A.CallTo(() => _dbContext.SaveChangesAsync(default)).Throws<Exception>();

            _testeeFake.Invoking(x => x.UpdateAsync(new Car())).Should().Throw<Exception>().WithMessage("entity could not be updated");
        }

       
    }
}
