using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Notepad_
{
    /// <summary>
    /// Класс, содержащий путь к файлу, его вкладку и его richTextBox.
    /// </summary>
    internal sealed class MyFile
    {
        private RichTextBox textBox;
        private string path;
        private TabPage tabpage;

        // Путь к файлу.
        public string Path
        {
            get { return path; }
            set { path = value; }
        }

        // RichTextBox файла.
        public RichTextBox TextBox
        {
            get { return textBox; }
            set { textBox = value; }
        }

        // Вкладка данного файла.
        public TabPage Page
        {
            get { return tabpage; }
            set { tabpage = value; }
        }

        /// <summary>
        /// Конструктор для создания нового объекта данного класса.
        /// </summary>
        /// <param name="textBox">RichTextBox данного файла.</param>
        /// <param name="path">Путь к данному файлу.</param>
        /// <param name="tabpage">Вкладка данного файла.</param>
        public MyFile(RichTextBox textBox, string path, TabPage tabpage)
        {
            this.textBox = textBox;
            this.path = path;
            this.tabpage = tabpage;
        }
    }
}
