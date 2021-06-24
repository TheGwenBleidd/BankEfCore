using System;
using System.Linq;

namespace BankEfCore
{
    class Program
    {
        static void Main(string[] args)
        {
            using (MySqlDbContext db = new MySqlDbContext())
            {
                Countries city1 = new Countries { CountryCode = 123, CountryName = "Kazakhstan" };
                Countries city2 = new Countries { CountryCode = 312, CountryName = "Uzbekistan" };

                db.Countries.AddRange(city1, city2);
                db.SaveChanges();
            }

            using(MySqlDbContext db = new MySqlDbContext())
            {
                var countries = db.Countries.ToList();
                Console.WriteLine("Список объектов:");
                foreach (Countries u in countries)
                {
                    Console.WriteLine($"{u.ID}.{u.CountryCode} - {u.CountryName}");
                }
            }
        }
    }
}
