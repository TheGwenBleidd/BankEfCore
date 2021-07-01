using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace BankEfCore
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Connection to DB
            ///Подключение к БД через Builder
            var builder = new ConfigurationBuilder();

            builder.SetBasePath(Directory.GetCurrentDirectory());

            builder.AddJsonFile("appsettings.json");

            var config = builder.Build();

            string connectionString = config.GetConnectionString("DefaultConnection");

            var optionsBuilder = new DbContextOptionsBuilder<MySqlDbContext>();

            var options = optionsBuilder.UseMySql(connectionString,
                new MySqlServerVersion(new Version(8, 0, 25))).Options;

            #endregion

            #region Mock
            List<Countries> countries = new List<Countries>()
            {
                new Countries{CountryCode = 2, CountryName = "Uzbekistan"},
                new Countries{CountryCode = 3, CountryName = "China"},
                new Countries{CountryCode = 4, CountryName = "Russia"},
                new Countries{CountryCode = 5, CountryName = "Mongolia"},
                new Countries{CountryCode = 6, CountryName = "United Kingdom"},
                new Countries{CountryCode = 7, CountryName = "USA"},
                new Countries{CountryCode = 8, CountryName = "Turkmenistan"},
                new Countries{CountryCode = 9, CountryName = "Kyrgyztan"},
                new Countries{CountryCode = 10, CountryName = "Switzerland"},
                new Countries{CountryCode = 11, CountryName = "Germany"},
                new Countries{CountryCode = 12, CountryName = "Spain"},
                new Countries{CountryCode = 13, CountryName = "France"},
                new Countries{CountryCode = 14, CountryName = "Poland"},
                new Countries{CountryCode = 15, CountryName = "Ukraine"},
                new Countries{CountryCode = 16, CountryName = "Saudi Arabia"},
                new Countries{CountryCode = 17, CountryName = "Egypt"},
                new Countries{CountryCode = 18, CountryName = "Denmark"},
                new Countries{CountryCode = 19, CountryName = "Norway"},
                new Countries{CountryCode = 20, CountryName = "Turkey"},
            };

            List<Cities> cities = new List<Cities>()
            {
                new Cities{CityCode = 1, CityName = "Nursultan" },
                new Cities{CityCode = 2, CityName = "Tashkent" },
                new Cities{CityCode = 3, CityName = "Beijing" },
                new Cities{CityCode = 4, CityName = "Moscow" },
                new Cities{CityCode = 5, CityName = "Ulan-Bator" },
                new Cities{CityCode = 6, CityName = "London" },
                new Cities{CityCode = 7, CityName = "Washington" },
                new Cities{CityCode = 8, CityName = "Ashgabat" },
                new Cities{CityCode = 9, CityName = "Bishkek" },
                new Cities{CityCode = 10, CityName = "Zurich" },
                new Cities{CityCode = 11, CityName = "Berlin" },
                new Cities{CityCode = 12, CityName = "Madrid" },
                new Cities{CityCode = 13, CityName = "Paris" },
                new Cities{CityCode = 14, CityName = "Warsaw" },
                new Cities{CityCode = 15, CityName = "Kyiv" },
                new Cities{CityCode = 16, CityName = "Riyadh" },
                new Cities{CityCode = 17, CityName = "Cairo" },
                new Cities{CityCode = 18, CityName = "Copenhagen" },
                new Cities{CityCode = 19, CityName = "Oslo" },
                new Cities{CityCode = 20, CityName = "Ankara" },
            };

            List<BankClients> bankClients = new List<BankClients>()
            {
                new BankClients{ClientFullName="Arapbay Meirlan",CountryId=1,CityId=1,Address="street A, house 23",UniqueIdentityNumber="442595608311", ClientBirthday = DateTime.ParseExact("12/12/2001","dd/MM/yyyy", CultureInfo.InvariantCulture)},
                new BankClients{ClientFullName="Andrey",CountryId=2,CityId=2,Address="street B, house 32",UniqueIdentityNumber="529104307923", ClientBirthday = DateTime.ParseExact("15/01/1991","dd/MM/yyyy", CultureInfo.InvariantCulture)},
                new BankClients{ClientFullName="Vladislav",CountryId=3,CityId=3,Address="street C, house 12",UniqueIdentityNumber="558190662159", ClientBirthday = DateTime.ParseExact("20/02/1980","dd/MM/yyyy", CultureInfo.InvariantCulture)},
                new BankClients{ClientFullName="John",CountryId=4,CityId=4,Address="street D, house 15",UniqueIdentityNumber="399063057967", ClientBirthday = DateTime.ParseExact("17/02/2002","dd/MM/yyyy", CultureInfo.InvariantCulture)},
                new BankClients{ClientFullName="Anton",CountryId=5,CityId=5,Address="street E, house 53",UniqueIdentityNumber="095018393887", ClientBirthday = DateTime.ParseExact("11/03/1982","dd/MM/yyyy", CultureInfo.InvariantCulture)},
                new BankClients{ClientFullName="Michael",CountryId=6,CityId=6,Address="street F, house 26",UniqueIdentityNumber="459917290996", ClientBirthday = DateTime.ParseExact("23/01/1981","dd/MM/yyyy", CultureInfo.InvariantCulture)},
                new BankClients{ClientFullName="Mark",CountryId=7,CityId=7,Address="street G, house 9",UniqueIdentityNumber="112655042983", ClientBirthday = DateTime.ParseExact("12/11/1989","dd/MM/yyyy", CultureInfo.InvariantCulture)},
                new BankClients{ClientFullName="Joseph",CountryId=8,CityId=8,Address="street H, house 10",UniqueIdentityNumber="873618784028", ClientBirthday = DateTime.ParseExact("19/10/1995","dd/MM/yyyy", CultureInfo.InvariantCulture)},
                new BankClients{ClientFullName="Vito",CountryId=9,CityId=9,Address="street I, house 19",UniqueIdentityNumber="858957841172", ClientBirthday = DateTime.ParseExact("20/02/1978","dd/MM/yyyy", CultureInfo.InvariantCulture)},
                new BankClients{ClientFullName="Kazbek",CountryId=10,CityId=10,Address="street J, house 34",UniqueIdentityNumber="671052803591", ClientBirthday = DateTime.ParseExact("14/04/1961","dd/MM/yyyy", CultureInfo.InvariantCulture)},
                new BankClients{ClientFullName="Birzhan",CountryId=11,CityId=11,Address="street K, house 85",UniqueIdentityNumber="831615341437", ClientBirthday = DateTime.ParseExact("07/07/1970","dd/MM/yyyy", CultureInfo.InvariantCulture)},
                new BankClients{ClientFullName="Vladimir",CountryId=12,CityId=12,Address="street L, house 29",UniqueIdentityNumber="889909675178", ClientBirthday = DateTime.ParseExact("12/05/1993","dd/MM/yyyy", CultureInfo.InvariantCulture)},
                new BankClients{ClientFullName="Aizek",CountryId=13,CityId=13,Address="street M, house 11",UniqueIdentityNumber="850366690493", ClientBirthday = DateTime.ParseExact("25/12/1995","dd/MM/yyyy", CultureInfo.InvariantCulture)},
                new BankClients{ClientFullName="Gregor",CountryId=14,CityId=14,Address="street N, house 22",UniqueIdentityNumber="301245726365", ClientBirthday = DateTime.ParseExact("01/01/1967","dd/MM/yyyy", CultureInfo.InvariantCulture)},
                new BankClients{ClientFullName="Aslan",CountryId=15,CityId=15,Address="street O, house 56",UniqueIdentityNumber="782589196667", ClientBirthday = DateTime.ParseExact("12/03/1973","dd/MM/yyyy", CultureInfo.InvariantCulture)},
                new BankClients{ClientFullName="Arman",CountryId=16,CityId=16,Address="street P, house 60",UniqueIdentityNumber="124354999382", ClientBirthday = DateTime.ParseExact("13/07/1994","dd/MM/yyyy", CultureInfo.InvariantCulture)},
                new BankClients{ClientFullName="Ivan",CountryId=17,CityId=17,Address="street Q, house 79",UniqueIdentityNumber="441734637723", ClientBirthday = DateTime.ParseExact("05/05/1999","dd/MM/yyyy", CultureInfo.InvariantCulture)},
                new BankClients{ClientFullName="Konstantin",CountryId=18,CityId=18,Address="street R, house 81",UniqueIdentityNumber="792575234702", ClientBirthday = DateTime.ParseExact("16/02/1998","dd/MM/yyyy", CultureInfo.InvariantCulture)},
                new BankClients{ClientFullName="Adolf",CountryId=19,CityId=19,Address="street S, house 24",UniqueIdentityNumber="271033764724", ClientBirthday = DateTime.ParseExact("08/08/1954","dd/MM/yyyy", CultureInfo.InvariantCulture)},
                new BankClients{ClientFullName="Martin",CountryId=20,CityId=20,Address="street T, house 13",UniqueIdentityNumber="070524516463", ClientBirthday = DateTime.ParseExact("19/09/1969","dd/MM/yyyy", CultureInfo.InvariantCulture)},
            };

            List<Accounts> accounts = new List<Accounts>()
            {
                new Accounts{BankClientId=1, AccountNumber="QQCVGYHOOQBIHUZ",Balance=100000},
                new Accounts{BankClientId=2, AccountNumber="TODKKGBYGQEHIIV",Balance=150000},
                new Accounts{BankClientId=3, AccountNumber="CBSAKRFLFYYDVME",Balance=200000},
                new Accounts{BankClientId=4, AccountNumber="CCPRWUXWUBJRPIB",Balance=250000},
                new Accounts{BankClientId=5, AccountNumber="TLUTULFYCHTVHGN",Balance=300000},
                new Accounts{BankClientId=6, AccountNumber="UMYKOILLYKSIZGA",Balance=130000},
                new Accounts{BankClientId=7, AccountNumber="CEFEZJNJMOKXADB",Balance=1000000},
                new Accounts{BankClientId=8, AccountNumber="LGSHWYXGNCEGTCT",Balance=2300000},
                new Accounts{BankClientId=9, AccountNumber="IQJEYUTGPREIHJX",Balance=3000000},
                new Accounts{BankClientId=10, AccountNumber="WPWSMERENYCMQYO",Balance=190000},
                new Accounts{BankClientId=11, AccountNumber="OATNFYAIKKPCKVB",Balance=230000},
                new Accounts{BankClientId=12, AccountNumber="YZESVPTMDTWCEQO",Balance=3340000},
                new Accounts{BankClientId=13, AccountNumber="DLWQZZAJAZZXMEO",Balance=450000},
                new Accounts{BankClientId=14, AccountNumber="WLTBQDBZEBCEYVP",Balance=500000},
                new Accounts{BankClientId=15, AccountNumber="LUFURMYUZBYYOCD",Balance=999999},
                new Accounts{BankClientId=16, AccountNumber="GHXZCDFAXIFXHMK",Balance=870000},
                new Accounts{BankClientId=17, AccountNumber="WDJZIQMNOBDSGRC",Balance=545000},
                new Accounts{BankClientId=18, AccountNumber="EQAGJDPTSECQCWG",Balance=1230000},
                new Accounts{BankClientId=19, AccountNumber="TJQNNVURJOTATTS",Balance=1500000},
                new Accounts{BankClientId=20, AccountNumber="NEKCQFEDNABLGKZ",Balance=45000},
            };
            #endregion

            

        }
        /// <summary>
        /// Вставляет данные в БД
        /// </summary>
        /// <param name="options">Конфигурация</param>
        /// <param name="countries">Страны</param>
        /// <param name="cities">Города</param>
        /// <param name="accounts">Счета клиентов</param>
        /// <param name="bankClients">Клиенты банка</param>
        static void InsertData(DbContextOptions<MySqlDbContext> options, List<Countries> countries, List<Cities> cities, List<Accounts> accounts, List<BankClients> bankClients)
        {
            #region Проверка на null
            if (options is null)
            {
                throw new ArgumentNullException();
            }

            if(countries is null)
            {
                throw new ArgumentNullException();
            }

            if(cities is null)
            {
                throw new ArgumentNullException();
            }

            if(accounts is null)
            {
                throw new ArgumentNullException();
            }

            if(accounts is null)
            {
                throw new ArgumentNullException();
            }
            #endregion
            ///Подключение через контекст и вставка данных
            using (MySqlDbContext db = new MySqlDbContext(options))
            {
                db.Countries.AddRange(countries);
                db.Cities.AddRange(cities);
                db.BankClients.AddRange(bankClients);
                db.Accounts.AddRange(accounts);
                db.SaveChanges();
            };

            Console.WriteLine("Data inserted succesfully!");
        }

        /// <summary>
        /// Показывает все таблицы в БД
        /// </summary>
        /// <param name="options">Конфигурация</param>
        static void ShowAllData(DbContextOptions<MySqlDbContext> options)
        {
            using (MySqlDbContext db = new MySqlDbContext(options))
            {
                var bankclients = db.BankClients.ToList();
                var accounts = db.Accounts.ToList();
                var countries = db.Countries.ToList();
                var cities = db.Cities.ToList();
                var transactions = db.Transactions.ToList();

                foreach (var client in bankclients)
                {
                    Console.WriteLine($"FullName:{client.ClientFullName} Address:{client.Address} UniqueIdentityNumber:{client.UniqueIdentityNumber} Birthday:{client.ClientBirthday} CountryId:{client.CountryId} CityId:{client.CityId}");
                }

                foreach (var account in accounts)
                {
                    Console.WriteLine($"BankClientId:{account.BankClientId} AccountNumber:{account.AccountNumber} Balance:{account.Balance}");
                }

                foreach (var country in countries)
                {
                    Console.WriteLine($"CountryName:{country.CountryName}");
                }

                foreach(var city in cities)
                {
                    Console.WriteLine($"CityName:{city.CityName}");
                }

                foreach (var transaction in transactions)
                {
                    Console.WriteLine($"Transaction Type:{transaction.TransactionType} Client Sender Id:{transaction.ClientSenderId} Client Sender Account Id:{transaction.ClientSenderAccountId} Client Receiver Id:{transaction.ClientReceiverId} Client Receiver Account Id:{transaction.ClientReceiverAccountId} Amount:{transaction.Amount}");
                }

            };
        }

        /// <summary>
        /// Изменяет данные клиента банка
        /// </summary>
        /// <param name="options">Конфигурация</param>
        /// <param name="bankClient">Клиент банка</param>
        static void ChangeClient(DbContextOptions<MySqlDbContext> options, BankClients bankClient)
        {
            if(options is null)
            {
                throw new ArgumentNullException();
            }


            if(bankClient is null)
            {
                throw new ArgumentNullException();
            }

            using(MySqlDbContext db = new MySqlDbContext(options))
            {
                var currentUser = db.BankClients.AsNoTracking().SingleOrDefault(u => u.ClientFullName == bankClient.ClientFullName);
                if( currentUser != null)
                {
                    currentUser.ClientFullName = "Sponge Bob";
                    currentUser.CountryId = 2;
                    currentUser.CityId = 2;
                    currentUser.Address = "Krusty Krab";
                    currentUser.UniqueIdentityNumber = "291422013923";
                    db.Update(currentUser);
                    db.SaveChanges();
                    Console.WriteLine("Success!");
                }
                if (currentUser == null)
                {
                    Console.WriteLine("Такого пользователя не существует, попробуйте еще раз");
                }
            };

        }

        /// <summary>
        /// Удаляет клиента банка из БД
        /// </summary>
        /// <param name="options">Конфигурация</param>
        /// <param name="bankClient">Клиент банка</param>
        static void DeleteClient(DbContextOptions<MySqlDbContext> options, BankClients bankClient)
        {
            if(options is null)
            {
                throw new ArgumentNullException();
            }

            if (bankClient is null)
            {
                throw new ArgumentNullException();
            }

            using (MySqlDbContext db = new MySqlDbContext(options))
            {
                var currentUser = db.BankClients.AsNoTracking().SingleOrDefault(u => u.ClientFullName == bankClient.ClientFullName);
                if (currentUser != null)
                {
                    db.BankClients.Remove(currentUser);
                    db.SaveChanges();
                    Console.WriteLine("Client deleted");
                }
                if (currentUser == null)
                {
                    Console.WriteLine("Такого пользователя не существует системе, попробуйте еще раз");
                }

            }
        }

        /// <summary>
        /// Метод для перевода денег
        /// </summary>
        /// <param name="options">Конфигурация</param>
        /// <param name="senderAcc">Аккаунт отправителя</param>
        /// <param name="receiverAcc">Аккаунт получателя</param>
        /// <param name="amount">Сумма транзакции</param>
        static void MoneyTransfer(DbContextOptions<MySqlDbContext> options,Accounts senderAcc, Accounts receiverAcc, decimal amount)
        {
            if(options is null)
            {
                throw new ArgumentNullException();
            }
            if(senderAcc is null)
            {
                throw new ArgumentNullException();
            }

            if(receiverAcc is null)
            {
                throw new ArgumentNullException();
            }

            if(amount < 0)
            {
                throw new ArgumentException();
            }

            using(MySqlDbContext db = new MySqlDbContext(options))
            {
                var sender = db.Accounts.SingleOrDefault(s => s.AccountNumber == senderAcc.AccountNumber);
                var receiver = db.Accounts.SingleOrDefault(s => s.AccountNumber == receiverAcc.AccountNumber);

                if(sender != null & receiver != null)
                {
                    sender.Balance -= amount;
                    receiver.Balance += amount;

                    db.UpdateRange(sender, receiver);

                    var transaction = new Transactions
                    {
                        TransactionType = "Money Transfer",
                        ClientSenderId = sender.BankClientId,
                        ClientSenderAccountId = (int)sender.ID,
                        ClientReceiverId = receiver.BankClientId,
                        ClientReceiverAccountId = (int)receiver.ID,
                        Amount = amount
                    };

                    db.Transactions.Add(transaction);

                    db.SaveChanges();

                    Console.WriteLine("Money transfered succesfully!");
                }

                if(sender == null && receiver == null)
                {
                    Console.WriteLine("These accounts doesn't exist in system, try again");
                }
            }
        }

        /// <summary>
        /// Метод для снятия денег
        /// </summary>
        /// <param name="options">Конфигурация</param>
        /// <param name="account">Аккаунт который производит операцию снятия денег</param>
        /// <param name="amount">Сумма транзакции</param>
        static void MoneyWithdraw(DbContextOptions<MySqlDbContext> options, Accounts account, decimal amount)
        {
            if(options is null)
            {
                throw new ArgumentNullException();
            }

            if(account is null)
            {
                throw new ArgumentNullException();
            }

            if(amount < 0)
            {
                throw new ArgumentException();
            }

            using(MySqlDbContext db = new MySqlDbContext(options))
            {
                var currentAccount = db.Accounts.SingleOrDefault(a => a.AccountNumber == account.AccountNumber);
                if(currentAccount != null)
                {
                    currentAccount.Balance -= amount;

                    db.Update(currentAccount);

                    var transaction = new Transactions
                    {
                        TransactionType = "Money Withdraw",
                        ClientSenderId = currentAccount.BankClientId,
                        ClientSenderAccountId = (int)currentAccount.ID,
                    };

                    db.Transactions.Add(transaction);

                    db.SaveChanges();

                    Console.WriteLine("Money withdrawed succesfully!");
                }

                if(currentAccount == null)
                {
                    Console.WriteLine("This account doesn't exist in system, try again!");
                }
            }
        }

        /// <summary>
        /// Метод для пополнение счета
        /// </summary>
        /// <param name="options">Конфигурация</param>
        /// <param name="account">Аккаунт который производит операцию пополнения счета</param>
        /// <param name="amount">Сумма транзакции</param>
        static void MoneyRefill(DbContextOptions<MySqlDbContext> options, Accounts account, decimal amount)
        {
            if (options is null)
            {
                throw new ArgumentNullException();
            }

            if (account is null)
            {
                throw new ArgumentNullException();
            }

            if (amount < 0)
            {
                throw new ArgumentException();
            }

            using (MySqlDbContext db = new MySqlDbContext(options))
            {
                var currentAccount = db.Accounts.SingleOrDefault(a => a.AccountNumber == account.AccountNumber);
                if (currentAccount != null)
                {
                    currentAccount.Balance += amount;

                    db.Update(currentAccount);

                    var transaction = new Transactions
                    {
                        TransactionType = "Money Refill",
                        ClientSenderId = currentAccount.BankClientId,
                        ClientSenderAccountId = (int)currentAccount.ID,
                    };

                    db.Transactions.Add(transaction);

                    db.SaveChanges();

                    Console.WriteLine("Money refilled succesfully!");
                }

                if (currentAccount == null)
                {
                    Console.WriteLine("This account doesn't exist in system, try again!");
                }
            }
        }

        /// <summary>
        /// Вывод на консоль ФИО клиента, Баланс, Страна и город проживания
        /// </summary>
        /// <param name="options">Конфигурация</param>
        static void ShowBalanceCountryCity(DbContextOptions<MySqlDbContext> options)
        {
            if(options is null)
            {
                throw new ArgumentNullException();
            }

            using (MySqlDbContext db = new MySqlDbContext(options))
            {
                var query = from account in db.Accounts
                            join client in db.BankClients on account.BankClientId equals client.Id
                            join country in db.Countries on client.CountryId equals country.ID
                            join city in db.Cities on client.CityId equals city.ID
                            select new { FullName = client.ClientFullName, Balance = account.Balance, Country = country.CountryName, City = city.CityName };

                foreach (var item in query)
                {
                    Console.WriteLine($"tCountry:{item.Country}\tCity:{item.City}\tFullName:{item.FullName}\tBalance:{item.Balance}");
                }
            }
        }

        /// <summary>
        /// Метод который выводит общий баланс клиентов из стран
        /// </summary>
        /// <param name="options"></param>
        static void ShowBalanceByCountry(DbContextOptions<MySqlDbContext> options)
        {
            if (options is null)
            {
                throw new ArgumentNullException();
            }

            using (MySqlDbContext db = new MySqlDbContext(options))
            {
                var query = from account in db.Accounts
                            join client in db.BankClients on account.BankClientId equals client.Id
                            join country in db.Countries on client.CountryId equals country.ID
                            select new {country.CountryName, account.Balance}
                            into x
                            group x by new {x.CountryName}
                            into y
                            select new
                            {
                                y.Key.CountryName,
                                Count = y.Select(x => x.Balance).Sum()
                            };

                foreach (var item in query)
                {
                    Console.WriteLine($"CountryName:{item.CountryName} TotalBalance:{item.Count}");
                }
               
            }
        }

        /// <summary>
        /// Метод выводит общий баланс клиентов по городам
        /// </summary>
        /// <param name="options">Конфигурация</param>
        static void ShowBalanceByCity(DbContextOptions<MySqlDbContext> options)
        {
            if (options is null)
            {
                throw new ArgumentNullException();
            }

            using (MySqlDbContext db = new MySqlDbContext(options))
            {
                var query = from account in db.Accounts
                            join client in db.BankClients on account.BankClientId equals client.Id
                            join city in db.Cities on client.CityId equals city.ID
                            select new { city.CityName, account.Balance }
                            into x
                            group x by new { x.CityName }
                            into y
                            select new
                            {
                                y.Key.CityName,
                                Count = y.Select(x => x.Balance).Sum()
                            };

                foreach (var item in query)
                {
                    Console.WriteLine($"CountryName:{item.CityName} TotalBalance:{item.Count}");
                }

            }
        }
    }
}

