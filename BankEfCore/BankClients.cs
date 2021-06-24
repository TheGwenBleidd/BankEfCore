using System;
using System.Collections.Generic;
using System.Text;

namespace BankEfCore
{
    /// <summary>
    /// Класс для клиентов банка
    /// </summary>
    public class BankClients
    {
        /// <summary>
        /// Первичный ключ
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// ФИО клиента
        /// </summary>
        public string ClientFullName { get; set; }

        /// <summary>
        /// Ссылка на страну клиента
        /// </summary>
        public int CountryId { get; set; }

        /// <summary>
        /// Ссылка на город клиента
        /// </summary>
        public int CityId { get; set; }

        /// <summary>
        /// Адрес клиента
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// ИИН клиента
        /// </summary>
        public string UniqueIdentityNumber { get; set; }

        /// <summary>
        /// Дата рождения клиента
        /// </summary>
        public DateTime ClientBirthday { get; set; }
    }
}
