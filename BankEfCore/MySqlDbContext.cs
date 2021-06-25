using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace BankEfCore
{
    /// <summary>
    /// Контекст данных
    /// </summary>
    class MySqlDbContext : DbContext
    {

        /// <summary>
        /// Добавление моделей 
        /// </summary>
        public DbSet<Countries> Countries { get; set; }
        public DbSet<Cities> Cities { get; set; }

        public DbSet<BankClients> BankClients { get; set; }

        public DbSet<Accounts> Accounts { get; set; }

        public DbSet<Transactions> Transactions { get; set; }


        public MySqlDbContext(DbContextOptions<MySqlDbContext> options)
            : base(options)
        {
        }

        public MySqlDbContext([NotNull] DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ///Установление уникального идентификатора для свойства ИИН
            modelBuilder.Entity<BankClients>().HasAlternateKey(u => u.UniqueIdentityNumber);
        }
    }
}
