using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace BankEfCore
{
    class MySqlDbContext : DbContext
    {
        public DbSet<Countries> Countries { get; set; }

        public MySqlDbContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=localhost;user=root;password=521473698Kz;database=BankSystemDb;",
                new MySqlServerVersion(new Version(8, 0, 25)));
        }
    }
}
