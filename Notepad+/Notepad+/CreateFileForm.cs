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
    /// Форма для ввода имени нового файла.
    /// </summary>
    public partial class CreateFileForm : Form
    {
        
        /// <summary>
        /// Применение выбранной темы к данной форме.
        /// </summary>
        public CreateFileForm()
        {
            InitializeComponent();
            label1.BackColor = Data.BackColor;
            textBox1.BackColor = Data.BackColor;
            button1.BackColor = Data.BackColor;
            this.BackColor = Data.BackColor;
            label1.ForeColor = Data.FontColor;
            textBox1.ForeColor = Data.FontColor;
            button1.ForeColor = Data.FontColor;
            this.ForeColor = Data.FontColor;

        }

        /// <summary>
        /// Запись в Data имени нового файла из textBox1 при нажатии на кнопку и закрытие формы.
        /// </summary>
        /// <param name="sender">Издатель.</param>
        /// <param name="e">Информация о событии.</param>
        void button1_Click(object sender, EventArgs e)
        {
            Data.FileName = textBox1.Text;
            this.Close();
        }
    }
}
