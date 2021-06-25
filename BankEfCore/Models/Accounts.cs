using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [Key]
        public long ID { get; set; }

        /// <summary>
        /// Ссылка на клиента банка
        /// </summary>
        public int BankClientId { get; set; }
        [ForeignKey("BankClientIdKey")]
        public BankClients Client { get; set; }

        /// <summary>
        /// Имя счета
        /// </summary>
        [MaxLength(15)]
        [Required]
        public string AccountNumber { get; set; }

        /// <summary>
        /// Баланс клиента
        /// </summary>
        [Required]
        public decimal Balance { get; set; }

    }
}
