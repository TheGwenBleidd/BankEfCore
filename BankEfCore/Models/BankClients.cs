using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [Key]
        public long Id { get; set; }

        /// <summary>
        /// ФИО клиента
        /// </summary>
        [MaxLength(400)]
        [Required]
        public string ClientFullName { get; set; }

        /// <summary>
        /// Ссылка на страну клиента
        /// </summary>
        public int CountryId { get; set; }
        [ForeignKey("CountryIdKey")]
        public Countries Countries { get; set; }

        /// <summary>
        /// Ссылка на город клиента
        /// </summary>
        public int CityId { get; set; }
        [ForeignKey("CityIdKey")]
        public Cities Cities { get; set; }

        /// <summary>
        /// Адрес клиента
        /// </summary>
        [MaxLength(400)]
        [Required]
        public string Address { get; set; }

        /// <summary>
        /// ИИН клиента
        /// </summary>
        [MaxLength(12)]
        [Required]
        public string UniqueIdentityNumber { get; set; }

        /// <summary>
        /// Дата рождения клиента
        /// </summary>
        [Required]
        public DateTime ClientBirthday { get; set; }
    }
}
