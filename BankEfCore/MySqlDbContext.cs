using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace BankEfCore
{
    class MySqlDbContext : DbContext
    {
        public DbSet<Countries> Countries { get; set; }
        public DbSet<Cities> Cities { get; set; }

        public DbSet<BankClients> BankClients { get; set; }

        public DbSet<Accounts> Accounts { get; set; }

        public DbSet<Transactions> Transactions { get; set; }


        public MySqlDbContext(DbContextOptions<MySqlDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BankClients>().HasAlternateKey(u => u.UniqueIdentityNumber);
        }
    }
}
