using System;
using System.Collections.Generic;
using System.Text;

namespace BankEfCore
{
    /// <summary>
    /// Счета клиентов
    /// </summary>
    public class Accounts
    {
        /// <summary>
        /// Первичный ключ 
        /// </summary>
        public long ID { get; set; }

        /// <summary>
        /// Ссылка на клиента банка
        /// </summary>
        public int BankClientId { get; set; }

        /// <summary>
        /// Имя счета
        /// </summary>
        public string AccountNumber { get; set; }

        /// <summary>
        /// Баланс клиента
        /// </summary>
        public decimal Balance { get; set; }

    }
}
