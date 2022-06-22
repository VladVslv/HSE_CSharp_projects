using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKRLib
{
    /// <summary>
    /// Класс, содержащий информация о машине.
    /// </summary>
    public class Car : Transport
    {
        /// <summary>
        /// Конструктор для создания экземпляра класса.
        /// </summary>
        /// <param name="model">Модель.</param>
        /// <param name="power">Мощность.</param>
        public Car(string model, uint power) : base(model, power) { }

        /// <summary>
        /// Метод, который возвращает модель машины и звук, который она издаёт.
        /// </summary>
        /// <returns>Модель данной машины и звук(в строковом представлении).</returns>
        public override string StartEngine()
        {
            return $"{Model}: Vroom";
        }

        /// <summary>
        /// Метод для перевода экземпляра класса в строковое представление.
        /// </summary>
        /// <returns>Информация о данной машине в строковом представлении.</returns>
        public override string ToString()
        {
            return "Car. " + base.ToString();
        }
    }
}
