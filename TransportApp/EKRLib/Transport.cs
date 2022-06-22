using System;

namespace EKRLib
{
    /// <summary>
    /// Абстрактный класс, представляюший информация о транспорте.
    /// Базовый класс для MotorBoat и Car.
    /// </summary>
    public abstract class Transport
    {
        // Поле для хранении информации о модели данного транспорта.
        private string model;

        // Поле для хранении информации о мощности данного транспорта.
        private uint power;

        /// <summary>
        /// Конструктор для создание экземпляра класса.
        /// </summary>
        /// <param name="model">Модель.</param>
        /// <param name="power">Мощность.</param>
        public Transport(string model,uint power)
        {
            Model = model;
            Power = power;
        }

        /// <summary>
        /// Свойство, представляющее модель транспорта.
        /// </summary>
        public string Model
        {
            get
            {
                return model;
            }
            init
            {
                if (value.Length != 5)
                {
                    throw new TransportException($"Недопустимая модель {value}");
                }
                for (int i = 0; i < 5; i++)
                {
                    if (!(value[i] <= 'Z' && value[i] >= 'A')&&!(value[i] <= '9' && value[i] >= '0'))
                    {
                        throw new TransportException($"Недопустимая модель {value}");
                    }
                }
                model = value;
            }
        }

        /// <summary>
        /// Свойство, представляющее мощность транспорта.
        /// </summary>
        public uint Power
        {
            get
            {
                return power;
            }
            init
            {
                if (value < 20)
                {
                    throw new TransportException("Мощность не может быть меньше 20 л.с.");
                }
                power = value;
            }
        }

        /// <summary>
        /// Метод для перевода экземпляра класса в строкове представление.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Model: {Model}, Power: {Power}";
        }

        /// <summary>
        /// Абстрактный метод, реализуемый в классах-наследниках, который должен возвращать звук,
        /// издаваемый конкретным видом транспорта.
        /// </summary>
        /// <returns>
        /// Строка, содержащая модель транспорта и звук(в строковом представлении), 
        /// который издаёт данный вид транспорта.
        /// </returns>
        public abstract string StartEngine();
    }
}
