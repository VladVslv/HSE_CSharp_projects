using MessageService.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;

namespace MessageService.Controllers
{
    /// <summary>
    /// Класс контроллера приложения.
    /// </summary>
    [Route("/[controller]")]
    public class MessengerController : Controller
    {
        // Строка, которая выводится при неправильной работе с файлами.
        static string wrongData = "Файлы MesssagesData.json и UsersData.json не существуют или неправильно записаны. " +
            "Рекомендуется сгенерировать данные заново.";

        // Сериалайзер для списка сообщений.
        static DataContractJsonSerializer messagesSerializer=
            new DataContractJsonSerializer(typeof(List<MessageInfo>));

        // Сериалайзер для списка пользователей.
        static DataContractJsonSerializer usersSerializer =
            new DataContractJsonSerializer(typeof(List<User>));

        static Random rand = new();

        /// <summary>
        /// Свойство для получения списка сообщений из файла.
        /// </summary>
        static List<MessageInfo> messages
        {
            get
            {
                try
                {
                    using (FileStream fs = new FileStream($"MessagesData.json", FileMode.Open))
                    {
                        return (List<MessageInfo>)messagesSerializer.ReadObject(fs);
                    }
                }
                catch(Exception)
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Свойство для получения списка пользователей из файла.
        /// </summary>
        public static List<User> users
        {
            get
            {
                try
                {
                    List<User> res;
                    using (FileStream fs = new FileStream($"UsersData.json", FileMode.Open))
                    {
                        res = (List<User>)usersSerializer.ReadObject(fs);
                    }
                    SerializeUsers(res);
                    return res.OrderBy(user => user.Email).ToList();
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }
        
        /// <summary>
        /// Cериализация нового списка сообщений.
        /// </summary>
        /// <param name="newMessages">Новый список сообщений.</param>
        static void SerializeMessages(List<MessageInfo> newMessages)
        {
            using(FileStream fs=new FileStream("MessagesData.json", FileMode.Create))
            {
                messagesSerializer.WriteObject(fs, newMessages);
            }
        }

        /// <summary>
        /// Сериализация нового списка пользователей.
        /// </summary>
        /// <param name="newUsers">Новый список пользователей.</param>
        static void SerializeUsers(List<User> newUsers)
        {
            using (FileStream fs = new FileStream("UsersData.json", FileMode.Create))
            {
                usersSerializer.WriteObject(fs, (newUsers.OrderBy(user=>user.Email)).ToList());
            }
        }


        /// <summary>
        /// Получение спика пользователей.
        /// </summary>
        /// <param name="limit">Максимальная длина списка.</param>
        /// <param name="offset">Номер пользователя, начиная с которого необходимо получать информацию.</param>
        /// <returns>Список пользователей или сообщение об ошибке.</returns>
        [HttpGet("AllUsers")]
        public IActionResult GetAllUsers(int limit,int offset)
        {
            if (users == null)
            {
                return BadRequest(new { message = wrongData });
            }
            int maxOffset = users.Count - 1;
            
            if (limit <= 0)
            {
                return BadRequest(new { message = "Limit должен быть больше 0." });
            }
            else if (offset < 0)
            {
                return BadRequest(new { message = "Offset должен быть не меньше 0." });
            }
            else if (offset > maxOffset)
            {
                return BadRequest(new { message = "Offset должен быть строго меньше, чем длина спика пользвателей." });
            }
            return Ok(users.GetRange(offset, Math.Min(limit, maxOffset - offset+1)));
        }

        /// <summary>
        /// Получение информации о пользователю по email.
        /// </summary>
        /// <param name="email">Email пользователя.</param>
        /// <returns>Информация о пользователе или сообщение об ошибке.</returns>
        [HttpGet("UserByEmail")]
        public IActionResult GetUserByEmail(string email)
        {
            if (users == null)
            {
                return BadRequest(new { message = wrongData });
            }
            User user= users.SingleOrDefault(user=>user.Email == email);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);

        }


        /// <summary>
        /// Получение спика сообщений между отправителем и получателем.
        /// </summary>
        /// <param name="senderId">Id отправителя.</param>
        /// <param name="recieverId">Id получателя.</param>
        /// <returns>Список сообщения или информация об ошибке.</returns>
        [HttpGet("MessagesBySenderAndReciever")]
        public IActionResult GetMessagesBySenderAndReciever(string senderId,string recieverId)
        {
            if (messages == null)
            {
                return BadRequest(new { message = wrongData });
            }
            IEnumerable<MessageInfo> conversation = from message in messages
                                                    where message.SenderID == senderId 
                                                    && message.RecieverID == recieverId
                                                    select message;
            if (conversation.ToList().Count == 0)
            {
                return NotFound();
            }
            return Ok(conversation);
        }

        /// <summary>
        /// Получение сообщений отправленных каким-то пользователем.
        /// </summary>
        /// <param name="senderId">Id отправителя.</param>
        /// <returns>Список сообщений или информация об ошибке.</returns>
        [HttpGet("MessagesBySender")]
        public IActionResult GetMessagesBySender(string senderId)
        {
            if (messages == null)
            {
                return BadRequest(new { message = wrongData });
            }
            IEnumerable<MessageInfo> conversation = from message in messages
                                                    where message.SenderID == senderId
                                                    select message;
            if (conversation.ToList().Count == 0)
            {
                return NotFound();
            }
            return Ok(conversation);
        }

        /// <summary>
        /// Получение сообщений полученных каким-то пользователем.
        /// </summary>
        /// <param name="recieverId">Id получателя.</param>
        /// <returns>Список сообщений или информация об ошибке.</returns>
        [HttpGet("MessagesByReciever")]
        public IActionResult GetMessagesByReciever(string recieverId)
        {
            if (messages == null)
            {
                return BadRequest(new { message = wrongData });
            }
            IEnumerable<MessageInfo> conversation = from message in messages
                                                    where message.RecieverID == recieverId
                                                    select message;
            if (conversation.ToList().Count == 0)
            {
                return NotFound();
            }
            return Ok(conversation);
        }

        /// <summary>
        /// Регистрация пользователя.
        /// </summary>
        /// <param name="email">Email пользователя.</param>
        /// <param name="username">Имя пользователя.</param>
        /// <returns>Информация об успешном или неуспешном выполнении.</returns>
        [HttpPost("AddUser")]
        public IActionResult AddUser(string email,string username)
        {
            if (users == null)
            {
                return BadRequest(new { message = wrongData });
            }
            List<User> newUsers = new List<User>(users);
            if (newUsers.SingleOrDefault(user=>user.Email==email)!=null)
            {
                return BadRequest(new { message = "Пользователь с таким email уже существует!" });
            }
            newUsers.Add(new Models.User() { Email = email, Username = username });
            SerializeUsers(newUsers);
            return Ok();
        }

        /// <summary>
        /// Отправление сообщения.
        /// </summary>
        /// <param name="subject">Тема сообщения.</param>
        /// <param name="message">Текст сообщения.</param>
        /// <param name="senderId">Id отправителя.</param>
        /// <param name="recieverId">Id получателя.</param>
        /// <returns>Информация об успешном или неуспешном выполнении.</returns>
        [HttpPost("SendMessage")]
        public IActionResult SendMessage(string subject, string message, string senderId,string recieverId)
        {
            if (messages == null||users==null)
            {
                return BadRequest(new { message = wrongData });
            }
            List<MessageInfo> newMessages=new List<MessageInfo>(messages);
            if (users.SingleOrDefault(user => user.Email == senderId) == null)
            {
                return BadRequest(new { message = "Пользователя senderId не существует!" });
            }
            if (users.SingleOrDefault(user => user.Email == recieverId) == null)
            {
                return BadRequest(new { message = "Пользователя recieverId не существует!" });
            }
            newMessages.Add(new MessageInfo()
            {
                Subject = subject,
                Message = message,
                SenderID = senderId,
                RecieverID = recieverId
            });
            SerializeMessages(newMessages);
            return Ok();
        }

        /// <summary>
        /// Генерация списка пользователей и сообщений.
        /// </summary>
        /// <returns>Информация об успешном или неуспешном выполнении.</returns>
        [HttpPost("GenerateData")]
        public IActionResult GenerateData()
        {
            GenerateUsers();
            GenerateMessages();
            return Ok();
        }
        
        /// <summary>
        /// Генерация списка пользователей.
        /// </summary>
        public static void GenerateUsers()
        {
            int numberOfUsers = rand.Next(5, 11);
            List<User> newUsers = new();
            for (int i = 1; i <= numberOfUsers; i++)
            {
                newUsers.Add(new User()
                {
                    Email = $"number{i}user@gmail.com",
                    Username = GenerateName()
                });
            }
            SerializeUsers(newUsers);
        }

        /// <summary>
        /// Генерация имени.
        /// </summary>
        /// <returns>Имя.</returns>
        public static string GenerateName()
        {
            int length = rand.Next(5, 11);
            string res = ((char)rand.Next('A', 'Z' + 1)).ToString();
            for (int i = 0; i < length-1; i++)
            {
                res += (char)rand.Next('a', 'z' + 1);
            }
            return res;

        }

        /// <summary>
        /// Генерация списка сообщений.
        /// </summary>
        public static void GenerateMessages()
        {
            List<MessageInfo> newMessages = new();
            int numberOfMessages = rand.Next(15, 31);
            for (int i = 0; i < numberOfMessages; i++)
            {
                newMessages.Add(new MessageInfo()
                {
                    Subject = $"Message number {i + 1}",
                    SenderID = users[rand.Next(users.Count)].Email,
                    RecieverID = users[rand.Next(users.Count)].Email,
                    Message = GenerateMessage(),
                });
            }
            SerializeMessages(newMessages);
        }

        /// <summary>
        /// Генерация сообщения.
        /// </summary>
        /// <returns>Сообщение.</returns>
        public static string GenerateMessage()
        {
            int numberOfLetters = rand.Next(10, 21);
            string res = ((char)rand.Next('A', 'Z' + 1)).ToString();
            for (int i = 0; i < numberOfLetters-1; i++)
            {
                if (rand.Next(5) == 0)
                {
                    res += " ";
                }
                res += (char)rand.Next('a', 'z' + 1);
            }
            return res + ".";
        }
    }
}
