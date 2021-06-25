using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BankEfCore
{
    /// <summary>
    ///  Без этого класса миграция будет с ошибкой 
    /// </summary>
    class ContextFactory : IDesignTimeDbContextFactory<MySqlDbContext>
    {
        public MySqlDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MySqlDbContext>();

            ConfigurationBuilder builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            IConfigurationRoot config = builder.Build();

            // получаем строку подключения из файла appsettings.json
            string connectionString = config.GetConnectionString("DefaultConnection");

            MySqlServerVersion mySqlServerVersion = new MySqlServerVersion(new Version(8, 0, 25));

            optionsBuilder.UseMySql(connectionString, mySqlServerVersion);
            return new MySqlDbContext(optionsBuilder.Options);
        }
    }
}
