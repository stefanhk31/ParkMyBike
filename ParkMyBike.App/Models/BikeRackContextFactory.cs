using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data.Common;

namespace ParkMyBike.Models
{
    public class BikeRackContextFactory : IDisposable
    {
        private DbConnection _connection;

        private DbContextOptions<BikeRackContext> CreateOptions()
        {
            return new DbContextOptionsBuilder<BikeRackContext>()
                .UseSqlite(_connection).Options;
        }

        public BikeRackContext CreateInMemoryContext()
        {

            if (_connection == null)
            {
                _connection = new SqliteConnection("DataSource=:memory:");
                _connection.Open();

                var options = CreateOptions();
                using (var context = new BikeRackContext(options))
                {
                    context.Database.EnsureCreated();
                }
            }

            return new BikeRackContext(CreateOptions());
        }

        public void Dispose()
        {
            if (_connection != null)
            {
                _connection.Dispose();
                _connection = null;
            }
        }
    }
}
