using System;

namespace Bulls_and_cows
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Добро пожловать в игру \"Быки и коровы\"\n\nПравила:\n1.В данной игре я загадываю число, состоящее из неповторяющихся цифр (никакая цифра не может присутствовать в числе\nдважды, число не может начинаться с нуля).\n2.Затем вы вводите своё число.\n3.Дальше вы видите информацию о том, сколько цифр (коров) угадано, но не расположено на своих местах, и сколько цифр\n(быков) угадано и находится на своих местах.\nВаша задача- отгадать задуманное число.\nПриятной игры!\n");
            do
            {
                int N;
                bool check_n = true;
                N = Check_N(ref check_n); //Ввод количества цифр в числе и проверка правильности ввода.
                bool different_digits = true;
                string num_to_guess_string;
                Generate_Num(ref N, out different_digits, out num_to_guess_string); //Генерирование числа с различными цифрами
                Console.WriteLine("\nЧисло загадано:)\nДля выхода нажмите ESC, для продолжения - любую другую клавишу.\n");
                int your_points = 0;
                while (Console.ReadKey(true).Key != ConsoleKey.Escape && your_points != N) //Выход при нажатии Esc
                {
                    Console.WriteLine("Какое число вы хотите проверить?");
                    int cows = 0;
                    int bulls = 0;
                    long current_num;
                    string entered_value = Console.ReadLine();
                    if (!(long.TryParse(entered_value, out current_num)) | current_num >= (long)Math.Pow(10, N) | current_num < (long)Math.Pow(10, N - 1))//проверка введенного числа
                    {
                        Console.Write("Incorrect Input.");
                    }
                    else
                    {
                        Count_Bulls_and_Cows(N, num_to_guess_string, ref cows, ref bulls, current_num); //нахождение количества коров и быков
                    }
                    your_points = bulls;
                    Console.WriteLine( your_points == N ? "\n\nПоздравляю с победой!!!\nНажми Enter два раза для выхода из игры.\nДля того, чтобы начать заново, нажми Space два раза\n\n" : "(Для выхода нажмите ESC, для продолжения - любую другую клавишу.)\n");
                }
                if (your_points != N)//если количество быков никогда не было равно количеству цифр в числе - значит игрок решил завершить игру
                {
                    Console.WriteLine("Жалко, что ты не хочешь доиграть:(\nНажми Enter один раз для выхода из игры.\nДля того, чтобы начать заново, нажми Space\n\n");
                }
            } while (Console.ReadKey(true).Key == ConsoleKey.Spacebar); //начинание игы заново при нажатии Space
            Console.WriteLine("Хорошего дня!");
        }

        private static void Count_Bulls_and_Cows(int N, string num_to_guess_string, ref int cows, ref int bulls, long current_num)
        {
            string current_num_string = $"{current_num}";
            bool check;
            for (int j = 0; j < N; j++)
            {
                check = true;
                if (num_to_guess_string[j] == current_num_string[j])
                {
                    bulls++;
                    check = false;
                }
                for (int i = 0; i < N & check; i++)
                {
                    if (num_to_guess_string[j] == current_num_string[i])
                    {
                        cows++;
                        check = false;
                    }
                }
            }
            Console.Write($"Количество быков равно {bulls}. Количество коров равно {cows}.");
        }

        private static int Generate_Num(ref int N, out bool different_digits, out string num_to_guess_string)
        {
            if (N != 10)
            {
                Diferent_Difit_N(N, out different_digits, out num_to_guess_string); //нахождение произвольного числа из N<10 различных цифр, так как в int(а именно с таким типом работает класс Random) могут входить числа меньшие 2^31, куда входят не все десятизначные числа
            }
            else
            {
                Diferent_Difit_N(9, out different_digits, out num_to_guess_string); //нахождение числа из 9 различных цифр
                int digit_sum = 0;
                for (int i = 0; i < 9; i++)
                {
                    digit_sum += (int)num_to_guess_string[i] - (int)'0';
                }
                num_to_guess_string += $"{45 - digit_sum}"; //приписывание оставшейся цифры к девятизначному числу и получение десятизначного
            }
            return N;
        }

        private static void Diferent_Difit_N(int N, out bool different_digits, out string num_to_guess_string)
        {
            do 
            {
                different_digits = true;
                int Num_to_guess = (new Random()).Next((int)Math.Pow(10, N - 1), (int)Math.Pow(10, N));
                num_to_guess_string = $"{Num_to_guess}";
                for (int l = 0; l < (N - 1) & different_digits; l++)
                {
                    for (int m = l + 1; m < N & different_digits; m++)
                    {
                        different_digits = num_to_guess_string[l] == num_to_guess_string[m] ? false : true;
                    }
                }
            } while (!different_digits);
        }

        private static int Check_N(ref bool check_n)
        {
            int N;
            do
            {
                Console.WriteLine("Сколько цифр должно быть в числе ? (любое целое число от 1 до 10)");
                if (!(int.TryParse(Console.ReadLine(), out N)) | N > 10 | N < 1)
                {
                    Console.WriteLine("Incorrect Input.\n");
                }
                else
                {
                    check_n = false;
                }
            } while (check_n);
            return N;
        }
    }
}
