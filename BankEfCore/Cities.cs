using System;
using System.Collections.Generic;
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
        public long ID { get; set; }

        /// <summary>
        /// Код города
        /// </summary>
        public  int CityCode { get; set; }

        /// <summary>
        /// Название города
        /// </summary>
        public string CityName { get; set; }
    }
}
