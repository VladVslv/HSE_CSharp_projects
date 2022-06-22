using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKRLib
{
    /// <summary>
    /// Класс, содержащий информация о моторной лодке.
    /// </summary>
    public class MotorBoat : Transport
    {
        /// <summary>
        /// Конструктор для создания экземпляра класса.
        /// </summary>
        /// <param name="model">Модель.</param>
        /// <param name="power">Мощность.</param>
        public MotorBoat(string model,uint power) : base(model, power) { }

        /// <summary>
        /// Метод, который возвращает модель лодки и звук, который она издаёт.
        /// </summary>
        /// <returns>Модель данной лодки и звук(в строковом представлении).</returns>
        public override string StartEngine()
        {
            return $"{Model}: Brrrbrr";
        }

        /// <summary>
        /// Метод для перевода экземпляра класса в строковое представление.
        /// </summary>
        /// <returns>Информация о данной лодке в строковом представлении.</returns>
        public override string ToString()
        {
            return "MotorBoat. " + base.ToString();
        }
    }
}
