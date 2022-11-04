using Microsoft.EntityFrameworkCore;
using P2_UnitTestMock.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2_UnitTestMock.Model {
    public class AppDbContext : DbContext{
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {  }

        public DbSet<Car> Cars { get; set; }
    }
}
