using CarSales.Data.Database;
using Microsoft.EntityFrameworkCore;
using System;

namespace CarSales.Data.Test.Database
{
    public class DatabaseTestBase : IDisposable
    {
        protected readonly DBContext Context;

        public DatabaseTestBase()
        {
            var options = new DbContextOptions<DBContext>();
            Context = new DBContext(options);

            Context.Database.EnsureCreated();

            DatabaseInitializer.Initialize(Context);
        }

        public void Dispose()
        {
            Context.Database.EnsureDeleted();

            Context.Dispose();
        }
    }
}
