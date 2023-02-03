using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.DbContexts
{

    public class ApplicationDbContextFactory
    {
        private readonly string _connectionString;
        public ApplicationDbContextFactory(string connectionString)
        {
            _connectionString = connectionString;

        }

        public ApplicationDbContext CreateDbContext()
        {
            DbContextOptions options= new DbContextOptionsBuilder().UseSqlServer(_connectionString).Options;
            return new ApplicationDbContext(options);
        }
    }
}
