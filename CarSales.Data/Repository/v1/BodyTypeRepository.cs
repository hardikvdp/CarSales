using CarSales.Data.Database;
using CarSales.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarSales.Data.Repository.v1
{
    public class BodyTypeRepository : IDataRepository<BodyType>
    {
        private DBContext _context;
        public BodyTypeRepository(DBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BodyType>> GetAllAsync()
        {
            return await _context.BodyTypes.ToListAsync();
        }

        public async Task<BodyType> GetAsync(int Id)
        {
            return await _context.BodyTypes.FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<BodyType> GetByNameAsync(string name)
        {
            return await _context.BodyTypes.FirstOrDefaultAsync(x => x.BodyTypeName.ToLower() == name.ToLower());
        }

        public async Task<BodyType> AddAsync(BodyType BodyType)
        {
            await _context.BodyTypes.AddAsync(BodyType);
            await _context.SaveChangesAsync();
            return BodyType;
        }

        public async Task<BodyType> UpdateAsync(BodyType BodyTypeChange)
        {
            var BodyType = _context.BodyTypes.Attach(BodyTypeChange);
            BodyType.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();
            return BodyTypeChange;
        }

        public async Task<BodyType> DeleteAsync(int Id)
        {
            var BodyType = await _context.BodyTypes.FirstOrDefaultAsync(e => e.Id == Id);
            if (BodyType != null)
            {
                _context.BodyTypes.Remove(BodyType);
                await _context.SaveChangesAsync();
            }
            return BodyType;
        }
    }
}
