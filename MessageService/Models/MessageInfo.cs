using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessageService.Models
{
    /// <summary>
    /// Класс, содержащий информацию об отправленных сообщениях.
    /// </summary>
    public class MessageInfo
    {
        /// <summary>
        /// Тема сообщения.
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Текст сообщения.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Id отправителя.
        /// </summary>
        public string SenderID { get; set; }

        /// <summary>
        /// Id получателя.
        /// </summary>
        public string RecieverID { get; set; }

    }
}
