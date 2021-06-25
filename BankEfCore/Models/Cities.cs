using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BankEfCore
{
    /// <summary>
    /// Города
    /// </summary>
    public class Cities
    {
        /// <summary>
        /// Первичный ключ
        /// </summary>
        [Key]
        public long ID { get; set; }

        /// <summary>
        /// Код города
        /// </summary>
        [MaxLength(30)]
        [Required]
        public int CityCode { get; set; }

        /// <summary>
        /// Название города
        /// </summary>
        [MaxLength(400)]
        [Required]
        public string CityName { get; set; }
    }
}
