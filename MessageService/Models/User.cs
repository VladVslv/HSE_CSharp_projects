using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessageService.Models
{
    /// <summary>
    /// Класс, содержащий информацию о зарегестрированном пользователе.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Имя пользователя.
        /// </summary>
        /// 
        public string Username { get; set; }
        /// <summary>
        /// Email пользователя (Id).
        /// </summary>
        public string Email { get; set; }
    }
}
