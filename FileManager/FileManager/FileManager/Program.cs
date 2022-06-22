using System;
using System.IO;
using System.Text;
using System.Linq;

class Program
{
    static void Main()
    {
        do
        {
            Console.Clear();
            PrintInstruction();
            if (Console.ReadKey(true).Key == ConsoleKey.C)
            {
                PrintFromFiles();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Далее вам будет предложено выбрать директорию/файл и в зависимости от его типа" +
                    ", вы сможете " +
                    "выбрать действия, которые могут производиться с ним.\n" +
                    "Для продолжения нажмите Enter.");
                Console.ReadLine();
                Console.Clear();
                string currentPath = ChoosePath();
                currentPath = FinalPath(currentPath);
                Action(ChooseAction(currentPath), currentPath);
            }
            Console.WriteLine("\nДействие успешно выполнено!");
            Console.WriteLine("Нажмите Esc для выхода, любую другую клавишу - для перезапуска приложения.");
        } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        
    }

    /// <summary>
    /// Метод выполняет выбранное действия с текущим файлом.
    /// </summary>
    /// <param name="choice">Номер действия.</param>
    /// <param name="path">Путь к файлу.</param>
    public static void Action(int choice, string path)
    {
        Console.Clear();
        switch (choice)
        {
            case 1:
                AllFilesInDirectory(path);
                break;
            case 2:
                Console.WriteLine(File.ReadAllText(path,ChooseEncoding()));
                break;
            case 3:
                CopyFile(path);
                break;
            case 4:
                MoveFile(path);
                break;
            case 5:
                File.Delete(path);
                break;
            case 6:
                CreateTextFile(path);
                break;
            case 7:
                FindInDirectory(path);
                break;
            case 8:
                SearchInDirectory(path);
                break;
            case 9:
                CopyFromDirectory(path);
                break;
            case 10:
                Diff(path);
                break;
        }
    }

    /// <summary>
    /// Метод сравнивает отличия между двумя файлами (по аналогии с функцией diff).
    /// </summary>
    /// <param name="path1">Путь к первому файлу.</param>
    public static void Diff(string path1)
    {
        string path2 = EnterTextFile();
        string[] text1 = File.ReadAllLines(path1, Encoding.UTF8);
        string[] text2 = File.ReadAllLines(path2, Encoding.UTF8);
        string[] subText = LongestSubsequence(text1, text2);
        int prevInd1;
        int prevInd2;
        int currentInd1 = 0;
        int currentInd2 = 0;
        int curretnInd = 0;
        while (currentInd1 != text1.Length || currentInd2 != text2.Length)
        {
            prevInd1 = currentInd1;
            prevInd2 = currentInd2;
            PrintNext(text1, text2, subText, prevInd1, prevInd2, ref currentInd1, ref currentInd2, curretnInd);
            curretnInd++;
        }
    }

    /// <summary>
    /// Метод выводит в консоль строки, которые нужно добавить/удалить в первом файле до следуюшей общей строки.
    /// </summary>
    /// <param name="text1">Массив строк из первого файла.</param>
    /// <param name="text2">Массив строк из второго файла.</param>
    /// <param name="subsequence">Массив общих строк первого и второго файла.</param>
    /// <param name="prevInd1">Индекс строки, с которой начинается рассмотрение первого текста.</param>
    /// <param name="prevInd2">Индекс строки, с которой начинается рассмотрение второго текста.</param>
    /// <param name="currentInd1">Индекс строки, которой заканчивается рассмотрение первого файла 
    /// (следующей необщей строки).</param>
    /// <param name="currentInd2">Индекс строки, которой заканчивается рассмотрение второг файла 
    /// (следующей необщей строки).</param>
    /// <param name="curretnInd">Индекс текущей рассматриваем общей строки.</param>
    public static void PrintNext(string[] text1, string[] text2, string[] subsequence, int prevInd1, int prevInd2,
        ref int currentInd1, ref int currentInd2, int curretnInd)
    {
        if (curretnInd == subsequence.Length)
        {
            currentInd1 = text1.Length;
            currentInd2 = text2.Length;
            Print(text1, text2, prevInd1, currentInd1, prevInd2, currentInd2);
        }
        else
        {
            while (text1[currentInd1] != subsequence[curretnInd])
            {
                currentInd1++;
            }
            while (text2[currentInd2] != subsequence[curretnInd])
            {
                currentInd2++;
            }
            Print(text1, text2, prevInd1, currentInd1, prevInd2, currentInd2);
            currentInd1++;
            currentInd2++;
        }
    }

    /// <summary>
    /// Метод выводит в консоль строки первого и второго файла и показывает, нужно ли удалять строки(d)/
    /// изменять их(c)/или добавлять(a) в первый файл.
    /// </summary>
    /// <param name="text1">Массив строк первого файла.</param>
    /// <param name="text2">Массив строк второго файла</param>
    /// <param name="prevInd1">Номер строки, с которой начинается вывод первого текста.</param>
    /// <param name="currentInd1">Номер первой строки в первом тексте, которую не нужно выводить.</param>
    /// <param name="prevInd2">Номер строки, с которой начинается вывод второго текста.</param>
    /// <param name="currentInd2">Номер первой строки во втором тексте, которую не нужно выводить.</param>
    public static void Print(string[] text1, string[] text2, int prevInd1, int currentInd1, int prevInd2, 
        int currentInd2)
    {
        if (currentInd1 == prevInd1 && currentInd2 != prevInd2)
        {
            Console.WriteLine($"{prevInd1}a{Eq(prevInd2 + 1, currentInd2)}");
            PrintPartOfText(text2, prevInd2, currentInd2, '>');
        }
        else if (currentInd2 == prevInd2 && currentInd1 != prevInd1)
        {
            Console.WriteLine($"{Eq(prevInd1 + 1, currentInd1)}d{prevInd2}");
            PrintPartOfText(text2, prevInd2, currentInd2, '>');
        }
        else if (currentInd2 != prevInd2 && currentInd1 != prevInd1)
        {
            Console.WriteLine($"{Eq(prevInd1 + 1, currentInd1)}c{Eq(prevInd2 + 1, currentInd2)}");
            PrintPartOfText(text1, prevInd1, currentInd1, '<');
            Console.WriteLine("---");
            PrintPartOfText(text2, prevInd2, currentInd2, '>');
        }
    }

    /// <summary>
    /// Выводит некоторые элементы массиво из строк.
    /// При выводе добавляет в начало указанный символ.
    /// </summary>
    /// <param name="text">Рассматривамый массив.</param>
    /// <param name="prevInd">Индекс первой строки, которую нужно выводить.</param>
    /// <param name="currentInd">Индекс первой строик, которую не нужно выводить.</param>
    /// <param name="a">Первый символ строки.</param>
    private static void PrintPartOfText(string[] text, int prevInd, int currentInd,char a)
    {
        for (int i = prevInd; i < currentInd; i++)
        {
            Console.WriteLine(a + text[i]);
        }
    }


    /// <summary>
    /// Возвращает одно число(преобразованные строку), если число равны.
    /// Если они разные, то возвращает строку, состоящую из этих чисел, написанный через запятую.
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns>Строка, содержащая одно число или два, написанные через запятую.</returns>
    public static string Eq(int a, int b)
    {
        if (a == b)
        {
            return a.ToString();
        }
        else
        {
            return a.ToString() + ',' + b.ToString();
        }
    }
    /// <summary>
    /// Возвращает наибольшую общую подпоследовательность строк в двух массивах.
    /// </summary>
    /// <param name="text1">Первый масив строк.</param>
    /// <param name="text2">Второй массив строк.</param>
    /// <returns>Массив строк, состоящий из наибольшей подпоследовательноси строк в исходных массивах.</returns>
    public static string[] LongestSubsequence(string[] text1, string[] text2)
    {
        int[,] array = new int[text1.Length + 1, text2.Length + 1];
        for (int i = 0; i < text1.Length + 1; i++)
        {
            for (int j = 0; j < text2.Length + 1; j++)
            {
                if (i == 0 || j == 0)
                {
                    array[i, j] = 0;
                }
                else if (text1[i - 1] == text2[j - 1])
                {
                    array[i, j] = array[i - 1, j - 1] + 1;
                }
                else
                {
                    array[i, j] = Math.Max(array[i - 1, j], array[i, j - 1]);
                }
            }
        }
        return FindSubsequence(text1, text2, array); ;
    }

    /// <summary>
    /// Возвращает наибольшую общую подпоследовательность строк в двух массивах с помощью данного массив "связей строк" 
    /// в исходных массивах.
    /// </summary>
    /// <param name="text1">Первый массив строк.</param>
    /// <param name="text2">Второй массив строк.</param>
    /// <param name="array">Двумерный масси целых чисел "связей строк" в сиходный массивах</param>
    /// <returns>Массив строк, состоящий из наибольшей подпоследовательноси строк в исходных массивах.</returns>
    private static string[] FindSubsequence(string[] text1, string[] text2, int[,] array)
    {
        string[] subsequence = new string[0];
        int ind1 = text1.Length;
        int ind2 = text2.Length;
        while (ind1 != 0 && ind2 != 0)
        {
            if (array[ind1 - 1, ind2] == array[ind1, ind2])
            {
                ind1--;
            }
            else if (array[ind1, ind2 - 1] == array[ind1, ind2])
            {
                ind2--;
            }
            else
            {
                Array.Resize(ref subsequence, subsequence.Length + 1);
                subsequence[^1] = text1[ind1 - 1];
                ind1--;
                ind2--;
            }
        }
        Array.Reverse(subsequence);
        return subsequence;
    }

    /// <summary>
    /// Перемещает текущий файл во вводимую директорию.
    /// </summary>
    /// <param name="filePath">Путь к текущему файлу</param>
    public static void MoveFile(string filePath)
    {
        Console.WriteLine("Введите путь к директории, в которую будет перемещаться файл.");
        string dirPath = Console.ReadLine();
        while (!Directory.Exists(dirPath))
        {
            Console.WriteLine("Неправильный путь!");
            Console.WriteLine("Введите путь к директории, в которую будет перемещаться файл.");
            dirPath = Console.ReadLine();
        }
        File.Move(filePath, dirPath + "\\" + Path.GetFileName(filePath),true);
    }

    /// <summary>
    /// Копирует текущий файл во вводимую директорию.
    /// </summary>
    /// <param name="filePath">Путь к текущему файлу</param>
    public static void CopyFile(string filePath)
    {
        Console.WriteLine("Введите путь к директории, в которую будет копироватья файл.");
        string dirPath = Console.ReadLine();
        while (!Directory.Exists(dirPath))
        {
            Console.WriteLine("Неправильный путь!");
            Console.WriteLine("Введите путь к директории, в которую будет копироватья файл.");
            dirPath = Console.ReadLine();
        }
        File.Copy(filePath, dirPath +"\\"+Path.GetFileName(filePath),true);
    }
    /// <summary>
    /// Выводит все файлы текущей директории.
    /// </summary>
    /// <param name="path">Путь к текущей директории.</param>
    public static void AllFilesInDirectory(string path)
    {
        Console.WriteLine("Все файлы в директории {0}:", path);
        string[] allFiles = Directory.GetFiles(path);
        string[] allDir = Directory.GetDirectories(path);
        string[] all = allFiles.Concat(allDir).ToArray();
        PrintArray(all);
    }
    
    /// <summary>
    /// Дает пользователю выбрать действия для текущего файла, в зависимости от его типа.
    /// </summary>
    /// <param name="path">Путь текущему файлу.</param>
    /// <returns>Номер выбранного действия.</returns>
    public static int ChooseAction(String path)
    {
        Console.Clear();
        string extension = Path.GetExtension(path);
        int[] possibleActions;
        if (Path.GetExtension(path) == ".txt") 
        {
            possibleActions = new int[] { 2, 3, 4, 5, 10 };
            PrintActions(possibleActions);
            Console.WriteLine("Для выбора действия просто напишите его номер.");
            return possibleActions[CheckChoice(5) - 1];
        }
        else if (Directory.Exists(path))
        {
            possibleActions = new int[] { 1, 6, 7, 8, 9};
            PrintActions(possibleActions);
            Console.WriteLine("Для выбора действия просто напишите его номер.");
            return possibleActions[CheckChoice(5) - 1];
        }
        else
        {
            possibleActions = new int[] { 3, 4, 5 };
            PrintActions(possibleActions);
            Console.WriteLine("Для выбора действия просто напишите его номер.");
            return possibleActions[CheckChoice(3) - 1];
        }
    }

    /// <summary>
    /// Выводит в консоль список возможных действий.
    /// </summary>
    /// <param name="possibleChoices">Массив целых чисел, содержазий номера возможнх действий.</param>
    public static void PrintActions(int[] possibleChoices)
    {
        string[] actions = new string[]{"Просмотр всех файлов какой-либо директории.",
            "Вывод содержимого текстового файла в консоль (поддерживаемые кодировки ASCII, Unicode, UTF32, UTF8).",
            "Копирование файла.",
            "Перемещение файла.",
            "Удаление файла.",
            "Создание текстового файла (поддерживаемые кодировки ASCII, Unicode, UTF32, UTF8).",
            "Вывод всех файлов в директории c заданным расширением.",
            "Вывод всех файлов с заданным расширением в текущей директории и всех её поддиректориях.",
            "Копирование всех файлов с заданным расширением из одной директори в другую. Если директория " +
            "не существует, " +
            "то она будет создаваться. Все файлы с одинакомы названиями будут заменяться на новый.",
            "Вывести разичия между двумя текстовыми файлами (по аналогии с функцией diff)." };
        for (int i = 0; i < possibleChoices.Length; i++)
        {
            Console.WriteLine($"{i+1}. {actions[possibleChoices[i]-1]}");
        }
    }

    /// <summary>
    /// Возвращает путь к файлу, с которым буду производитья действия.
    /// </summary>
    /// <param name="currentPath">Путь к текущей директории.</param>
    /// <returns>Путь к файлу, с которым будут производиться действия.</returns>
    public static string FinalPath(string currentPath)
    {   
        ConsoleKeyInfo key;
        while (Directory.Exists(currentPath))
        {
            if (currentPath[^2] == ':' || currentPath[^1] == ':')
            {
                Console.Clear();
                currentPath= ChooseFolder(currentPath);
            }
            PrintInstruction(currentPath);
            key = Console.ReadKey(true);
            Console.WriteLine("Текущая директорая: {0}", currentPath);
            if (key.Key == ConsoleKey.A)
            {
                break;
            }
            else if (key.Key == ConsoleKey.P)
            {
                if (currentPath[^2] == ':' || currentPath[^1] == ':')
                {
                    currentPath = ChooseFolder(currentPath);
                }
                else
                {
                    currentPath = Path.GetFullPath(Path.Combine(currentPath, @"..\"));
                }
            }
            else
            {
                currentPath = ChooseFolder(currentPath);
            }
        }
        return currentPath;
    }

    /// <summary>
    /// Выводит возможные действия с текущей директорией.
    /// </summary>
    /// <param name="currentPath">Путь к текущей директории.</param>
    private static void PrintInstruction(string currentPath)
    {
        Console.Clear();
        Console.WriteLine("Текущая директорая: {0}", currentPath);
        Console.WriteLine("Нажмите A (Actions) для того, чтобы просмотреть список действий для текущей" +
            " директории.");
        Console.WriteLine("Нажмите P (Previous) для того, чтобы подняться на один уровень вверх.");
        Console.WriteLine("Нажмите любую другую клавишу, чтобы посмотреть " +
            "список файлов/поддиректорий в текущей директории.");
    }

    /// <summary>
    /// Выводит инструкцию к приложению.
    /// </summary>
    public static void PrintInstruction()
    {
        Console.WriteLine("Список доступных действий:\n" +
            "1. Просмотр всех файлов какой-либо директории.\n" +
            "2. Вывод содержимого текстового файла в консоль (поддерживаемые кодировки ASCII, Unicode, " +
            "UTF32, UTF8).\n" +
            "3. Копирование файла.\n" +
            "4. Перемещение файла.\n" +
            "5. Удаление файла.\n" +
            "6. Создание текстового файла (поддерживаемые кодировки ASCII, Unicode, UTF32, UTF8).\n" +
            "7. Вывод всех файлов в директории с заданным расширеним.\n" +
            "8. Вывод всех файлов с заданным расширением в текущей директории и всех её поддиректориях.\n" +
            "9.Копирование всех файлов с заданным расширением из одной директори в другую. Если директория " +
            "не существует, " +
            "то она будет создаваться. Все файлы с одинакомы названиями будут заменяться на новый.\n" +
            "10. Вывести разичия между двумя текстовыми файлами (по аналогии с функцией diff).\n" +
            "Также вы можете найти конкатенацию нескольких текстовых файлов(до 15 штук).\n" +
            "Если не указан тип кодировки, то при записи/чтении файла будет использоваться UTF8!!!!!\n\n" +
            "Нажмите C (Concatenation), чтобы найти конкатенацию нескольких текстовых файлов.\n" +
            "Нажмите любую другю клавишу, чтобы перейти к выполнению остальных действий.");
    }

    /// <summary>
    /// Отвечате за выбор того, как будет вводиться путь к файлу.
    /// </summary>
    /// <returns>Возвращает путь к файлу.</returns>
    public static string ChoosePath()
    {
        Console.WriteLine("Вы можете ввести путь к файлу(1), ввести директорию для рассмотрение(2) " +
            "или начать " +
            "рассмотрение с выбора диска(3)");
        int choice = CheckChoice(3);
        Console.Clear();
        switch (choice)
        {
            case 1:
                return EnterThePath("file");
            case 2:
                return EnterThePath("all");
            default:
                return ChooseDrive();
        }
    }

    /// <summary>
    /// Отвечает за выбор диска.
    /// </summary>
    /// <returns>Путь к выбранному диску.</returns>
    public static string ChooseDrive()
    {
        DriveInfo[] allDrives = DriveInfo.GetDrives();
        Console.WriteLine("Все диски, доступные на компьютере:");
        PrintArray(allDrives);
        Console.WriteLine("Для выбора диска, просто введите его номер.");
        int choice = CheckChoice(allDrives.Length);
        return allDrives[choice-1].Name;
    }

    /// <summary>
    /// Отвечает за выбор файла/поддиректории в текущей директории.
    /// </summary>
    /// <param name="path">Путь к текущей директории.</param>
    /// <returns>Путь к выбранному файлу/директории.</returns>
    public static string ChooseFolder(string path)
    {
        string[] allFiles = Directory.GetFiles(path);
        string[] allDir = Directory.GetDirectories(path);
        string[] all = allFiles.Concat(allDir).ToArray();
        PrintArray(all);
        Console.WriteLine("Для выбора директории/файла просто введите его номер.");
        int choice = CheckChoice(all.Length);
        return all[choice-1];
    }

    /// <summary>
    /// Выводит файлы с заданным расширением в текущей директории.
    /// </summary>
    /// <param name="path">Путь к текущей директории.</param>
    public static void FindInDirectory(string path)
    {
        string mask = CheckMask();
        string[] allFiles = Directory.GetFiles(path, mask);
        if (allFiles.Length == 0)
        {
            Console.WriteLine("В данной директории файлов с заданным расширением не существует.");
            return;
        }
        Console.WriteLine("Все файлы с заданным расширеним:");
        foreach (string file in allFiles)
        {
            Console.WriteLine(Path.GetFileName(file));
        }
    }

    /// <summary>
    /// Копирует файлы с заданным расширеним из текущей директории и всех её поддиректориях
    /// во вводиму директорию.
    /// </summary>
    /// <param name="path">Путь к текущей директории.</param>
    public static void CopyFromDirectory(string path)
    {
        string mask = CheckMask();
        string[] allFiles = Directory.GetFiles(path, mask, SearchOption.AllDirectories);
        Console.WriteLine("Введите путь к директории, в которую будет производиться копирование файлов.\n" +
            "Если директория не существует, " +
            "то она будет создаваться. Все файлы с одинакомы названиями будут заменяться на новый.\n");
        string dirPath = Console.ReadLine();
        while (!Directory.Exists(Path.GetDirectoryName(dirPath))||path==dirPath)
        {
            Console.WriteLine("Неправильный путь!");
            Console.WriteLine("Введите путь к директории, в которую будет производиться копирование файлов.");
            dirPath = Console.ReadLine();
        }
        if (!Directory.Exists(dirPath))
        {
            Directory.CreateDirectory(dirPath);
        }
        foreach(string elem in allFiles)
        {
            File.Copy(elem, dirPath + "\\" + Path.GetFileName(elem), true);
        }
    }
    /// <summary>
    /// Выводит файлы с заданным расширеним в текущей директории и всех её поддиректориях.
    /// </summary>
    /// <param name="path">Путь к текущей директории.</param>
    public static void SearchInDirectory(string path)
    {
        string mask = CheckMask();
        string[] allFiles = Directory.GetFiles(path, mask, SearchOption.AllDirectories);
        if (allFiles.Length == 0)
        {
            Console.WriteLine("В данной директории и её поддиректориях файлов с заданным расширением не существует.");
            return;
        }
        Console.WriteLine("Все файлы с заданным расширением:");
        foreach (string file in allFiles)
        {
            Console.WriteLine(Path.GetFileName(file));
        }
    }

    /// <summary>
    /// Ввод правильного расширения файла.
    /// </summary>
    /// <returns>Возвращает расширение файла в виде регулярного выражения.</returns>
    public static string CheckMask()
    {
        string mask;
        bool checkForInvalidChars=true;
        char[] invalidChars= (@".~@#$%^-_(){}'`").ToCharArray();
        do
        {
            checkForInvalidChars = true;
            Console.WriteLine("Введите маску файла. (например \".txt\")");
            mask=Console.ReadLine();
            if (mask=="" ||mask==null|| mask[0]!='.')
            {
                checkForInvalidChars = false;
                Console.WriteLine("Неверная маска файла!");
            }
            else
            {
                foreach (char elem in mask[..^1])
                {
                    if (!(elem >= 'a' && elem <= 'z') && !(elem >= 'A' && elem <= 'Z') && 
                        !(elem >= '0' && elem <= '9') && !invalidChars.Contains(elem))
                    {
                        checkForInvalidChars = false;
                        Console.WriteLine("Неверная маска файла!");
                        break;
                    }
                }
            }
        } while (!checkForInvalidChars);
        return '*'+mask+'?';
    }

    /// <summary>
    /// Создаёт текстовый файл в текущей директории.
    /// </summary>
    /// <param name="path">Путь к текущей директории.</param>
    public static void CreateTextFile(string path)
    {
        Console.WriteLine("Как будет называться файл?");
        string fileName = Console.ReadLine();
        Encoding enc = ChooseEncoding();
        Console.WriteLine("Какой текст будет содержаться в файле?(пустая строка-конец файла)");
        string text = "";
        string nextString = Console.ReadLine();
        while (nextString != "")
        {
            text += nextString + "\n";
            nextString = Console.ReadLine();
        }
        File.WriteAllText(path + "\\"+fileName+".txt", text, enc);
    }

    /// <summary>
    /// Выводит конкатенацию нескольких файлов в консоль.
    /// </summary>
    public static void PrintFromFiles()
    {
        Console.Clear();
        Console.WriteLine("Введите количество файлов (до 15 штук).");
        int numberOFiles=CheckChoice(15);
        string path;
        string text="";
        Console.Clear();
        for(int i=0; i<numberOFiles; i++)
        {
            Console.WriteLine("Введите путь к файлу номер {0}.",i+1);
            path = Console.ReadLine();
            while (!File.Exists(path)||Path.GetExtension(path)!=".txt")
            {
                Console.WriteLine("Вы должны полный путь к текстовому файлу(с расширением \".txt\")!");
                path = Console.ReadLine();
            }
            text += File.ReadAllText(path,Encoding.UTF8);
        }
        Console.WriteLine(text);
    }
    
    /// <summary>
    /// Отвечает за выбор кодировки.
    /// </summary>
    /// <returns>Выбранная кодировка.</returns>
    public static Encoding ChooseEncoding()
    {
        Console.WriteLine("Какую кодировку использовать?");
        string[] Endcodings = new string[] { "ASCII", "Unicode", "UTF32", "UTF8" };
        PrintArray(Endcodings);
        int choice = CheckChoice(4);
        switch (choice)
        {
            case 1:
                return Encoding.ASCII;
            case 2:
                return Encoding.Unicode;
            case 3:
                return Encoding.UTF32;
            default:
                return Encoding.UTF8;
        }
    }

    /// <summary>
    /// Выводит элеиенты данного массива в консоль.
    /// </summary>
    /// <param name="array">Массив элементов с типом DriveInfo/</param>
    public static void PrintArray(DriveInfo[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            Console.WriteLine((i+1) + ". " + array[i].Name[..^2]);
        }
    }

    /// <summary>
    /// Выводит элеиенты данного массива в консоль.
    /// </summary>
    /// <param name="array">Массив строк.</param>
    public static void PrintArray(string[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            Console.WriteLine((i + 1) + ". " + Path.GetFileName(array[i]));
        }
    }

    /// <summary>
    /// Отвечает за правильный ввод пути к текстовому файлу.
    /// </summary>
    /// <returns>Путь к текстовому файлу.</returns>
    public static string EnterTextFile()
    {
        string path;
        Console.WriteLine("Введите путь к текстовому файлу.");
        path = Console.ReadLine();
        while (!File.Exists(path) || Path.GetExtension(path) != ".txt")
        {
            Console.WriteLine("Неправильный путь!");
            Console.WriteLine("Введите путь ко второму текстовому файлу (с раширением \".txt\").");
            path = Console.ReadLine();
        }
        return path;
    }

    /// <summary> 
    /// Отвечает за правильный ввод пути к файлу/директории.
    /// </summary>
    /// <param name="typeOfFile">Тип нужного объекта (="file", если нужно ввести путь к файлу,
    /// в других случаях вводится путь к директории).</param>
    /// <returns></returns>
    public static string EnterThePath(string typeOfFile)
    {
        string path;
        switch (typeOfFile)
        {
            case "file":
                Console.WriteLine("Введите путь к файлу (не к директории).");
                path = Console.ReadLine();
                while (!File.Exists(path))
                {
                    Console.WriteLine("Файл не существует!");
                    Console.WriteLine("Введите путь к файлу (не к директории).");
                    path = Console.ReadLine();
                }
                return path;
            default:
                Console.WriteLine("Введите путь к директории.");
                path = Console.ReadLine();
                while (!Directory.Exists(path)) 
                {
                    Console.WriteLine("Нет директории с таким путём!");
                    Console.WriteLine("Введите путь к директории.");
                    path = Console.ReadLine();
                }
                return path;
        }
    }

    /// <summary>
    /// Ввод целого числа от единицы до заданного максимума.
    /// </summary>
    /// <param name="maxChoice">Целое число - заданный максимум вводимго числа. </param>
    /// <returns>Целое число от единицы до заданного максимума.</returns>
    public static int CheckChoice(int maxChoice)
    {
        int choice;
        while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > maxChoice)
        {
            Console.WriteLine("Вы должны ввести целое число от 1 до {0}!", maxChoice);
        }
        return choice;
    }
}