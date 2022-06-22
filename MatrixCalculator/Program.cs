using System;
using System.IO;

namespace Matrix_Calculator
{
    class Program
    {
        static void Main()
        {
            double[,] firstMatrix;
            double[,] secondMatrix;
            double[,] result = new double[1, 1];
            bool wrongSizes = true;
            double alpha;
            string choice;
            int n1, n2, m1, m2;
            Greeting();//вывод инструкции в консоль
            if (Console.ReadKey(true).Key == ConsoleKey.Escape)//выход и программы
            {
                Environment.Exit(0);
            }
            do
            {
                Console.Clear();//очистка консоли после выполнения программы
                Intsruction();//вывод функционала программы
                choice=Console.ReadLine();
                while(choice.Length != 1 || (int)choice[0] < (int)'0' || (int)choice[0] > (int)'8')
                {
                    Console.WriteLine("Вы должны напечатать натуральное число, меньшее 9");
                    choice = Console.ReadLine();
                }
                Console.WriteLine();
                do
                {
                    ChoiceOfAction(choice, out alpha, out n1, out n2, out m1, out m2);//ввод размеров матрицы и значений констант
                    IncorrectInput(choice, n1,n2, m1, m2, ref wrongSizes);//вывод ошибки при неправильном вводе
                } while (!wrongSizes);
                GenerateMatrix(out firstMatrix, out secondMatrix, n1, m1, n2, m2);//создание матриц(-ы)
                Actions(choice, alpha, ref firstMatrix, ref secondMatrix, ref result);//действие матрицей(-ами)5
                Console.WriteLine("Для выхода нажмите Esc, для продолжения-любую другую клавишу");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
        public static void Print(double[,] result)
        {
            for (int i = 0; i < result.GetLength(0); i++)
            {
                for (int j = 0; j < result.GetLength(1); j++)
                {
                    if (Math.Abs(Math.Round(result[i, j], 2)) == 0)
                    {
                        result[i, j] = 0;
                    }
                    Console.Write("{0,20}", Math.Round(result[i, j],2));
                }
                Console.WriteLine();
            }
        }
        private static void Intsruction()
        {
            Console.WriteLine("Среди доступных операций присутствуют:\n" +
                                "1.Нахождение следа матрицы.\n" +
                                "2.Транспонирование матрицы.\n" +
                                "3.Сумма двух матриц.\n" +
                                "4.Разность двух матриц.\n" +
                                "5.Произведение двух матриц.\n" +
                                "6.Умножение матрицы на число (меньшее 10000 по модулю).\n" +
                                "7.Нахождение определителя матрицы.\n" +
                                "8.Приведения матрицы к каноническому виду.\n\n" +
                                "Для выбора действия просто напишите его номер.");
        }

        private static void Greeting()
        {
            Console.WriteLine("Добро пожаловать в \"Matrix calculator\"\n" +
                            "В данном приложении вы сможете проделывать различные действия с матрицами,\n" +
                            "состоящими из вещественных чисел, которые меньше 10000 по модулю.\n" +
                            "Количество строк и столбцов должно быть меньше 11.\n" +
                            "Каждое число при выводе будет округлено до 2 знаков после запятой. \n" +
                            "Для выхода нажмите Esc, для перехода к доступным действиям - любую другую кнопку.");
        }

        public static void IncorrectInput(string choice, int n1, int n2, int m1, int m2, ref bool wrongSizes)
        {
            string[] Errors = new string[] {"Матрица должны быть квадратной(количество столбцов равно " +
                "количеству строк)",
                "","Матрицы должны быть одинакового размера","Матрицы должны быть одинакового размера",
                "Количество столбцов первой матрицы должно быть равно количеству строк второй","",
            "Матрица должны быть квадратной(количество столбцов равно количеству строк)",""};//номер ошибки соответсует номеру(-1) выбранного действия
            int.TryParse(choice, out int choiceNum);
            if (choiceNum == 1)
            {
                wrongSizes = n1 == m1 ? true : false;
            }
            else if(choiceNum == 7)
            {
                wrongSizes = n1==m1 ? true : false;
            }
            else if (choiceNum == 3||choiceNum==4)
            {
                wrongSizes = n1 == n2 & m1 == m2 ? true : false;
            }
            else if (choiceNum == 5)
            {
                wrongSizes = m1==n2? true : false;
            }
            else
            {
                wrongSizes = true;
            }
            if (!wrongSizes)
            {
                Console.WriteLine(Errors[choiceNum-1]);
                Console.WriteLine();
            }
        }
        public static void Actions(string input, double alpha, ref double[,] firstMatrix, ref double[,] secondMatrix,
            ref double[,] result)
        {
            if (input == "1")
            {
                Trace(firstMatrix);//нахождение следа матрицы
            }
            else if (input == "2")
            {
                Transpose(firstMatrix, ref result);//транспонирование матрицы
            }
            else if (input == "3")
            {
                Sum(firstMatrix, secondMatrix, ref result);//нахождение суммы 2 матриц
            }
            else if (input == "4")
            {
                Difference(firstMatrix, secondMatrix, ref result);//нахождение разности двух матрицы
            }
            else if (input == "5")
            {
                MatrixProduct(firstMatrix, secondMatrix, ref result);//нахождение произведения двух матриц
            }
            else if (input == "6")
            {
                MultiplicationByNumber(alpha, firstMatrix);//умножение матрицы на число
            }
            else if (input == "7")
            {
                Determinant(ref firstMatrix);//нахождение определителя матрицы
            }
            else if (input == "8")
            {
                CanonicalMatrix(ref firstMatrix);//приведение матрицы к каноническому виду методом Гаусса
            }
        }
        public static void ChoiceOfAction(string input, out double alpha, out int n1, out int n2, out int m1, out 
            int m2)
        {
            alpha = 0;
            n1 = 0;
            m1 = 0;
            m2 = 0;
            n2 = 0;
            if (input == "1" | input == "2" | input == "6" | input == "7" | input == "8")
            {
                if (input == "6")
                {
                    do
                    {
                        Console.WriteLine("Введите значение числа, на которое будеть умножаться матрица " +
                            "(оно должно быть меньше 10000 по модулю.");
                    } while (!double.TryParse(Console.ReadLine(), out alpha) || alpha >= 10000 || alpha <= -10000);
                }
                InputOneMatrix(out n1, out m1);//ввод одной матрицы
            }
            else
            {
                InputTwoMatrices(out n1, out n2, out m1, out m2);//ввод двух матриц
            }
        }

        private static void InputOneMatrix(out int n1, out int m1)
        {
            string[] arrayStringElements;
            Console.WriteLine("Введите количество строк и столбцов в матрице (через пробел)");
            arrayStringElements =( Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries));
            while (arrayStringElements.Length != 2 || !int.TryParse(arrayStringElements[0], out n1) || n1 <= 0 ||
                !int.TryParse(arrayStringElements[1], out m1) || m1 <= 0 || m1 >= 11 || n1 >= 11)
            {
                Console.WriteLine("Оба значения должны быть натуральными числами (меньшими 11), " +
                    "написанными через пробел.\n" +
                    "Введите значение заново");
                arrayStringElements = (Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries));
            }
        }

        private static void InputTwoMatrices(out int n1, out int n2, out int m1, out int m2)
        {
            Console.WriteLine("Введите количество строк и столбцов в первой матрице (через пробел)");
            string[] arrayStringElements = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            while (arrayStringElements.Length != 2 || !int.TryParse(arrayStringElements[0], out n1) || n1 <= 0 ||
                !int.TryParse(arrayStringElements[1], out m1) || m1 <= 0 || m1 >= 11 || n1 >= 11)
            {
                Console.WriteLine("Оба значения должны быть натуральными числами (меньшими 11), " +
                    "написанными через пробел.\n" +
                    "Введите ззначение заново");
                arrayStringElements = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }
            Console.WriteLine("Введите количество строк и столбцов во второй матрице (через пробел)");
            arrayStringElements = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            while (arrayStringElements.Length != 2 || !int.TryParse(arrayStringElements[0], out n2) || n2 <= 0 ||
                !int.TryParse(arrayStringElements[1], out m2) || m2 <= 0 || n2 >= 11 || m2 >= 11)
            {
                Console.WriteLine("Оба значения должны быть натуральными числами (меньшими 11), написанными через" +
                    " пробел.\n" +
                    "Введите ззначение заново");
                arrayStringElements = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }
        }

        public static void GenerateMatrix(out double[,] firstMatrix, out double[,] secondMatrix, int n1, int m1, 
            int n2, int m2)
        {
            firstMatrix = new double[n1, m1];
            secondMatrix = new double[n2, m2];
            if (n2 == m2 && m2 == 0)
            {
                Console.WriteLine("\nСгенерировать ли матрицу(1), или вы хотите её сами ввести(2), или " +
                    "прочитать из файла(3) ? (напчетайте 1, 2 ли 3)");
                GetMatrix(ref firstMatrix, n1, m1);//выбор способа ввода матрицы
            }
            else
            {
                Console.WriteLine("\nСгенерировать ли первую матрицу(1), или вы хотите её сами ввести(2), " +
                    "или прочитать из файла(3)?(напчетайте 1, 2 ли 3)");
                GetMatrix(ref firstMatrix, n1, m1);//выбор способа ввода матрицы
                Console.WriteLine("\nСгенерировать ли вторую матрицу(1), или вы хотите её сами ввести(2)," +
                    " или прочитать из файла(3) ? (напчетайте 1, 2 ли 3)");
                GetMatrix(ref secondMatrix, n2, m2);//выбор способа ввода матрицы
            }
        }

        private static void GetMatrix(ref double[,] firstMatrix, int n1, int m1)
        {
            string input = Console.ReadLine();
            bool check = false;
            while (input != "1" && input != "2" && input != "3")
            {
                Console.WriteLine("Вы должны ввести цифру 1, 2 или 3");
                input = Console.ReadLine();
            }
            if (input == "1")
            {
                for (int i = 0; i < n1; i++)
                {
                    for (int j = 0; j < m1; j++)
                    {
                        firstMatrix[i, j] = (double)(new Random().Next(-9999, 9999))+Math.Round(new Random().NextDouble(),2);
                    }
                }
                Console.WriteLine("\nСгенерированная матрица:");
                Print(firstMatrix);
            }
            else if (input == "3")
            {
                check = ReadFromFile(firstMatrix, n1, m1);//чтение матрицы из файла
            }
            else
            {
                ReadFromConsole(firstMatrix, n1, m1);//чтение матрицы их консоли
            }
        }

        private static void ReadFromConsole(double[,] firstMatrix, int n1, int m1)
        {
            string[] elements;
            Console.WriteLine("Введите матрицу (каждую строку с новой строки, числa должны идти через пробел)");
            for (int i = 0; i < n1; i++)
            {
                Console.WriteLine("Введите строку матрицы с номером {0} и длиной {1}", i + 1, m1);
                elements = (Console.ReadLine()).Split(" ",StringSplitOptions.RemoveEmptyEntries);
                while (elements.Length != m1)
                {
                    Console.WriteLine("Введите строку матрицы с номером {0} и длиной {1}", i + 1, m1);
                    elements = (Console.ReadLine()).Split(" ",StringSplitOptions.RemoveEmptyEntries);
                }
                for (int k = 0; k < m1; k++)
                {
                    if (!double.TryParse(elements[k], out firstMatrix[i, k]) || firstMatrix[i, k] >= 10000)
                    {
                        Console.WriteLine("Элементами строки должны быть целые числа, по модулю менбшие 10000");
                        i--;
                        break;
                    }
                }
            }
        }

        private static bool ReadFromFile(double[,] firstMatrix, int n1, int m1)
        {
            string[] elements;
            bool check;
            do
            {
                InputFromFile(firstMatrix, n1, m1, out elements, out check);//чтение файла
            } while (check);
            return check;
        }

        private static void InputFromFile(double[,] firstMatrix, int n1, int m1,out string[] elements, out bool check)
        {
            string line;
            elements = new string[m1];
            check = false;
            string fileName = NameOfFile(n1, m1);//ввод имени файла
            try
            {
                LineFromFile(firstMatrix, n1, m1, ref elements, ref check, fileName);//чтение одной строки из файла
                if (check)
                {
                    Console.WriteLine($"В данном файле должны находиться {n1} строк по " +
                        $"{m1} числу (по модулю меньшему 10000) в каждой строке через пробел.");
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("Файл должен находитьсяв той же папке, что и исполняемый файл программы, " +
                    "и быть написан с расширением.");
                check = true;
            }
        }

        private static void LineFromFile(double[,] firstMatrix, int n1, int m1, ref string[] elements, ref bool check, string fileName)
        {
            string line;
            using (var file = new StreamReader(fileName))
            {
                for (int i = 0; i < n1; i++)
                {
                    line = file.ReadLine();
                    if (line == null)
                    {
                        check = true;
                        break;
                    }
                    elements = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    if (elements.Length != m1)
                    {
                        check = true;
                    }
                    int k = 0;
                    while (k < m1 && !check)
                    {
                        if (!double.TryParse(elements[k], out firstMatrix[i, k]) ||
                            Math.Abs(firstMatrix[i, k]) >= 10000)
                        {
                            check = true;
                            i--;
                        }
                        k++;
                    }
                }
            }
        }

        private static string NameOfFile(int n1, int m1)
        {
            Console.WriteLine("\nВведите название файла с расширением(он должен быть в той же паке, " +
                            "что и исполняемый файл программы).\n" +
                            $"В данном файле должны находиться {n1} строк по {m1} числу (меньшему 10000) " +
                            "в каждой строке через пробел");
            string fileName = Console.ReadLine();
            return fileName;
        }

        
        public static void Trace(double[,] firstMatrix)
        {
            double sum = 0;
            for (int i = 0; i < firstMatrix.GetLength(0); i++)
            {
                sum += firstMatrix[i, i];
            }
            Console.WriteLine("Cлед равен "+Math.Round(sum,2));
        }
        public static void Transpose(double[,] firstMatrix, ref double[,] result)
        {
            result = new double[firstMatrix.GetLength(1), firstMatrix.GetLength(0)];
            for (int i = 0; i < firstMatrix.GetLength(1); i++)
            {
                for (int j = 0; j < firstMatrix.GetLength(0); j++)
                {
                    result[i, j] = firstMatrix[j, i];
                }
            }
            Console.WriteLine("\nРезультат:");
            Print(result);
        }
        public static void Sum(double[,] firstMatrix, double[,] secondMatrix, ref double[,] result)
        {
            result = new double[firstMatrix.GetLength(0), firstMatrix.GetLength(1)];
            for (int i = 0; i < firstMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < firstMatrix.GetLength(1); j++)
                {
                    result[i, j] = firstMatrix[i, j] + secondMatrix[i, j];
                }
            }
            Console.WriteLine("\nРезультат:");
            Print(result);
        }
        public static void Difference(double[,] firstMatrix, double[,] secondMatrix, ref double[,] result)
        {
            result = new double[firstMatrix.GetLength(0), firstMatrix.GetLength(1)];
            for (int i = 0; i < firstMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < firstMatrix.GetLength(1); j++)
                {
                    result[i, j] = firstMatrix[i, j] - secondMatrix[i, j];
                }
            }
            Console.WriteLine("\nРезультат:");
            Print(result);
        }
        public static void MatrixProduct(double[,] firstMatrix, double[,] secondMatrix,  ref double[,] result)
        {
            result = new double[firstMatrix.GetLength(0), secondMatrix.GetLength(1)];
            for (int i = 0; i < result.GetLength(0); i++)
            {
                for (int j = 0; j < result.GetLength(1); j++)
                {
                    result[i, j] = 0;
                    for (int k = 0; k < firstMatrix.GetLength(1); k++)
                    {
                        result[i, j] += (firstMatrix[i, k] * secondMatrix[k, j]);
                    }
                }
            }
            Console.WriteLine("\nРезультат:");
            Print(result);
        }
        public static void MultiplicationByNumber(double alpha, double[,] firstMatrix)
        {

            for (int i = 0; i < firstMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < firstMatrix.GetLength(1); j++)
                {
                    firstMatrix[i, j] = alpha * firstMatrix[i, j];
                }
            }
            Console.WriteLine("\nРезультат:");
            Print(firstMatrix);
        }
        public static void GetTriangularMatrix(ref double[,] firstMatrix, out int sgn)
        {
            sgn = 0;
            int index;
            int currentInd = 0;
            for (int i = 0; i < firstMatrix.GetLength(1); i++)
            {
                index = currentInd;
                while (index < firstMatrix.GetLength(0) && Math.Abs(firstMatrix[index, i]) == 0)
                {
                    index++;
                }
                if (index < firstMatrix.GetLength(0))
                {
                    if (index != currentInd)
                    {
                        for (int k = i; k < firstMatrix.GetLength(1); k++)
                        {
                            (firstMatrix[index, k], firstMatrix[currentInd, k]) =
                                (firstMatrix[currentInd, k], (firstMatrix[index, k]));
                        }
                        sgn += 1;
                    }
                    for (int k = currentInd + 1; k < firstMatrix.GetLength(0); k++)
                    {
                        if (firstMatrix[k, i] != 0)
                        {
                            double gamma = firstMatrix[k, i] / firstMatrix[currentInd, i];
                            for (int l = i; l < firstMatrix.GetLength(1); l++)
                            {
                                firstMatrix[k, l] -= gamma * firstMatrix[currentInd, l];
                            }
                        }
                    }
                    currentInd += 1;
                }
            }
        }
        public static void Determinant(ref double[,] firstMatrix)
        {
            double determinant = 1.0;
            GetTriangularMatrix(ref firstMatrix, out int sgn);
            for (int i = 0; i < firstMatrix.GetLength(0); i++)
            {
                determinant *= firstMatrix[i, i];
            }
            determinant = sgn % 2 == 0 ? determinant : -determinant;
            if (Math.Abs(Math.Round(determinant, 2)) == 0)
            {
                Console.WriteLine( "Определитель равен 0");
                return;
            }
            Console.WriteLine("Определитель равен "+(Math.Round(determinant,2)+0.0));
        }
        static public void CanonicalMatrix(ref double[,] firstMatrix)
        {
            int currentIndex=0;
            GetTriangularMatrix(ref firstMatrix, out int sgn);
            for (int i = 0; i < firstMatrix.GetLength(0); i++)
            {
                while (currentIndex != firstMatrix.GetLength(1) && 
                    Math.Abs(firstMatrix[i, currentIndex]) == 0)
                {
                    currentIndex++;
                }
                if (currentIndex != firstMatrix.GetLength(1))
                {
                    for (int l = currentIndex+1; l < firstMatrix.GetLength(1); l++)
                    {
                        firstMatrix[i, l] /= firstMatrix[i, currentIndex];
                    }
                    firstMatrix[i, currentIndex] = 1;
                    for (int k = 0; k < i; k++)
                    {
                        for (int u = currentIndex+1; u < firstMatrix.GetLength(1); u++)
                        {
                            firstMatrix[k, u] -= firstMatrix[k, currentIndex] * firstMatrix[i, u];
                        }
                        firstMatrix[k, currentIndex] = 0;
                    }
                    currentIndex++;
                 }
            }
            Console.WriteLine("\nРезультат:");
            Print(firstMatrix);
        }
    }
}