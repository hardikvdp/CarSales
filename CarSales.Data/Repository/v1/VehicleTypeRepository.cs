using CarSales.Data.Database;
using CarSales.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarSales.Data.Repository.v1
{
    public class VehicleTypeRepository : IDataRepository<VehicleType>
    {
        private DBContext _context;
        public VehicleTypeRepository(DBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<VehicleType>> GetAllAsync()
        {
            return await _context.VehicleTypes.ToListAsync();
        }

        public async Task<VehicleType> GetAsync(int Id)
        {
            return await _context.VehicleTypes.FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<VehicleType> GetByNameAsync(string name)
        {
            return await _context.VehicleTypes.FirstOrDefaultAsync(x => x.VehicleTypeName.ToLower() == name.ToLower());
        }

        public async Task<VehicleType> AddAsync(VehicleType vehicleType)
        {
            await _context.VehicleTypes.AddAsync(vehicleType);
            await _context.SaveChangesAsync();
            return vehicleType;
        }

        public async Task<VehicleType> UpdateAsync(VehicleType VehicleTypeChange)
        {
            var vehicleType = _context.VehicleTypes.Attach(VehicleTypeChange);
            vehicleType.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();
            return VehicleTypeChange;
        }

        public async Task<VehicleType> DeleteAsync(int Id)
        {
            var vehicleType = await _context.VehicleTypes.FirstOrDefaultAsync(e => e.Id == Id);
            if (vehicleType != null)
            {
                _context.VehicleTypes.Remove(vehicleType);
                await _context.SaveChangesAsync();
            }
            return vehicleType;
        }
    }
}
