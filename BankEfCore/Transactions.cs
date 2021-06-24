using System;
using System.Collections.Generic;
using System.Text;

namespace BankEfCore
{
    /// <summary>
    /// Класс для транзакции по счетам
    /// </summary>
    class Transactions
    {
        /// <summary>
        /// Первичный ключ 
        /// </summary>
        public long ID { get; set; }

        /// <summary>
        /// Тип трансзакции
        /// </summary>
        public string TransactionType { get; set; }

        /// <summary>
        /// Ссылка на клиента отправителя
        /// </summary>
        public int ClientSenderId { get; set; }

        /// <summary>
        /// Ссылка на счет отправителя
        /// </summary>
        public int ClientSenderAccountId { get; set; }

        /// <summary>
        /// Ссылка на клиента получателя
        /// </summary>
        public int ClientReceiverId { get; set; }

        /// <summary>
        /// Ссылка на счет получателя
        /// </summary>
        public int ClientReceiverAccountId { get; set; }

        /// <summary>
        /// Cумма трансзакции
        /// </summary>
        public decimal Amount { get; set; }

    }
}
