using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [Key]
        public long ID { get; set; }

        /// <summary>
        /// Тип трансзакции
        /// </summary>
        [Required]
        public string TransactionType { get; set; }

        /// <summary>
        /// Ссылка на клиента отправителя
        /// </summary>
        public int? ClientSenderId { get; set; }
        [ForeignKey("ClientSenderIdKey")]
        public BankClients Sender { get; set; }

        /// <summary>
        /// Ссылка на счет отправителя
        /// </summary>
        public int? ClientSenderAccountId { get; set; }
        [ForeignKey("ClientSenderAccountIdKey")]
        public Accounts SenderAccount { get; set; }
        /// <summary>
        /// Ссылка на клиента получателя
        /// </summary>
        public int? ClientReceiverId { get; set; }
        [ForeignKey("ClientReceiverIdKey")]
        public BankClients Receiver { get; set; }

        /// <summary>
        /// Ссылка на счет получателя
        /// </summary>
        public int? ClientReceiverAccountId { get; set; }
        [ForeignKey("ClientReceiverAccountIdKey")]
        public Accounts ReceiverAccount { get; set; }

        /// <summary>
        /// Cумма трансзакции
        /// </summary>
        [Required]
        public decimal Amount { get; set; }

    }
}
