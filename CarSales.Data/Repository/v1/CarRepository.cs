using CarSales.Data.Database;
using CarSales.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarSales.Data.Repository.v1
{
    public class CarRepository : IDataRepository<Car>
    {
        private DBContext _context;
        public CarRepository(DBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Car>> GetAllAsync()
        {
            return await _context.Cars
                .Include(b => b.VehicleType)
                .Include(b => b.BodyType)
                .ToListAsync();
        }

        public async Task<Car> GetAsync(int Id)
        {
            return await _context.Cars
                .Include(b => b.VehicleType)
                .Include(b => b.BodyType)
                .FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<Car> GetByNameAsync(string name)
        {
            return await _context.Cars
                .FirstOrDefaultAsync(x => String.Equals(x.Model, name, StringComparison.OrdinalIgnoreCase));
        }

        public async Task<Car> AddAsync(Car Car)
        {
            await _context.Cars.AddAsync(Car);
            await _context.SaveChangesAsync();
            return Car;
        }

        public async Task<Car> UpdateAsync(Car CarChange)
        {
            var Car = _context.Cars.Attach(CarChange);
            Car.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();
            return CarChange;
        }

        public async Task<Car> DeleteAsync(int Id)
        {
            var Car = await _context.Cars.FirstOrDefaultAsync(e => e.Id == Id);
            if (Car != null)
            {
                _context.Cars.Remove(Car);
                await _context.SaveChangesAsync();
            }
            return Car;
        }

        
    }
}
