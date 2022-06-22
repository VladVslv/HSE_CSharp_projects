using System;
using EKRLib;
using System.IO;
using System.Text;

namespace TransportApp
{
    class Program
    {
        private static Random rand = new Random();
        
        /// <summary>
        /// Основной код программы.
        /// </summary>
        static void Main()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("Сгенерированный транспорт:");
                Transport[] machines = GenerateMachines();
                WriteInfo(machines, @"..\..\..\Cars.txt", @"..\..\..\MotorBoats.txt");
                Console.WriteLine("Нажмите Escape для выхода или любую другую клавишу для повтора программы.");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
            
            
        }

        /// <summary>
        /// Запись в файлы информации о лодках и машинах из данного массива.
        /// </summary>
        /// <param name="machines">Массив лодок и машин.</param>
        /// <param name="carsFilename">Имя файла в которых записывается информация о машинах.</param>
        /// <param name="motorBoatsFilename">Имя файла в которых записывается информация о лодках.</param>
        public static void WriteInfo(Transport[] machines, string carsFilename,string motorBoatsFilename)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(carsFilename, false, Encoding.Unicode))
                {
                    foreach (Transport machine in machines)
                    {
                        if (machine.GetType() == typeof(Car))
                        {
                            writer.WriteLine(machine);
                        }
                    }
                }
                using (StreamWriter writer = new StreamWriter(motorBoatsFilename, false, Encoding.Unicode))
                {
                    foreach (Transport machine in machines)
                    {
                        if (machine.GetType() == typeof(MotorBoat))
                        {
                            writer.WriteLine(machine);
                        }
                    }
                }
                Console.WriteLine("Информация об объектах успешно записана в файл.");
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                Console.WriteLine("Неполучилось записать информацию об объектах в файл!");
            }
        }



        /// <summary>
        /// Генерация массива случайной длины, который состоин из объектов типа Transport.
        /// </summary>
        /// <returns>Массив из моделей транспорта разных видов.</returns>
        public static Transport[] GenerateMachines()
        {
            Transport[] newMachines = new Transport[rand.Next(6, 10)];
            for (int i = 0; i < newMachines.Length; i++)
            {
                try
                {
                    if (rand.Next(2) == 0)
                    {
                        newMachines[i] = new Car(GenerateModel(), (uint)rand.Next(10, 100));
                    }
                    else
                    {
                        newMachines[i] = new MotorBoat(GenerateModel(), (uint)rand.Next(10, 100));
                    }
                    Console.WriteLine(newMachines[i].StartEngine());
                }
                catch (TransportException ex)
                {
                    Console.WriteLine(ex.Message);
                    i--;
                }
            }
            return newMachines;
        }

        /// <summary>
        /// Генерация случайной модели транспорта.
        /// </summary>
        /// <returns>Модель транспорта.</returns>
        public static string GenerateModel()
        {
            string newModel = "";
            for (int i = 0; i < 5; i++)
            {
                int nextSymbol = rand.Next((int)'A', (int)'Z' + 11);

                // Новый символ должен быть заглавной латиснкой буквой.
                if (nextSymbol <= (int)'Z')
                {
                    newModel += (char)nextSymbol;
                }

                // Новый символ должен быть заглавной цифрой.
                else
                {
                    newModel += (nextSymbol - (int)'Z' - 1).ToString();
                }
            }
            return newModel;
        }
    }
}
