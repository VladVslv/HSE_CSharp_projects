using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Notepad_
{
    /// <summary>
    /// Класс для передачи информации между формами и хранении информации о настройках пользователя.
    /// </summary>
    class Data
    {
        private static string fileName;
        private static string closingChoice;
        private static string autoSaveFrequency = "60";
        private static string loggingFrequency = "60";
        private static string versionOfFile;
        private static Color backColor = Color.White;
        private static Color fontСolor = Color.Black;
        private static MyFile currentFile;

        // Выбранный файл, у которого рассматриваюся версии.
        public static MyFile CurrentFile
        {
            get
            {
                return currentFile;
            }
            set
            {
                currentFile = value;
            }
        }

        // Выбранная версия файла.
        public static string VersionOfFile
        {
            get
            {
                return versionOfFile;
            }
            set
            {
                versionOfFile = value;
            }
        }

        // Имя нового файла.
        public static string FileName
        {
            get
            {
                return fileName;
            }
            set
            {
                fileName = value;
            }
        }

        // Выбор действия при закрытии основной формы.
        public static string ClosingChoice
        {
            get
            {
                return closingChoice;
            }
            set
            {
                closingChoice = value;
            }
        }

        // Частота автосохранения.
        public static string AutoSaveFrequency
        {
            get
            {
                return autoSaveFrequency;
            }
            set
            {
                autoSaveFrequency = value;
            }
        }

        // Частота жруналирования.
        public static string LoggingFrequency
        {
            get
            {
                return loggingFrequency;
            }
            set
            {
                loggingFrequency = value;
            }
        }

        //Цвет фона приложения
        public static Color BackColor
        {
            get
            {
                return backColor;
            }
            set
            {
                backColor = value;
            }
        }

        //Цвет шрифта приложения.
        public static Color FontColor
        {
            get
            {
                return fontСolor;
            }
            set
            {
                fontСolor = value;
            }
        }

    }
}
