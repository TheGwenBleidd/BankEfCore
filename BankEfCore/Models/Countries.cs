using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BankEfCore
{
    /// <summary>
    /// Города 
    /// </summary>
    public class Countries
    {
        /// <summary>
        /// Первичный ключ
        /// </summary>
        [Key]
        public long ID { get; set; }

        /// <summary>
        /// Код страны
        /// </summary>
        [MaxLength(30)]
        [Required]
        public int CountryCode { get; set; }

        /// <summary>
        /// Название страны
        /// </summary>
        [MaxLength(400)]
        [Required]
        public string CountryName { get; set; }
    }
}
