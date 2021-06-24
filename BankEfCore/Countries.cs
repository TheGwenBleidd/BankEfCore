using System;
using System.Collections.Generic;
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
        public long ID { get; set; }

        /// <summary>
        /// Код страны
        /// </summary>
        public int CountryCode { get; set; }

        /// <summary>
        /// Название страны
        /// </summary>
        public string CountryName { get; set; }
    }
}
