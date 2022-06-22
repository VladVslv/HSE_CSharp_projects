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
    /// Форма для изменения частоты журналирования файлов.
    /// </summary>
    public partial class LoggingForm : Form
    {
        private string[] frequencies = new string[] { "1","2","5", "10", "30", "60",
            "90", "120" ,"Выключить журналирование" };

        /// <summary>
        /// Применение выбранной темы к данной форме.
        /// </summary>
        public LoggingForm()
        {
            InitializeComponent();
            label1.BackColor = Data.BackColor;
            listBox1.BackColor = Data.BackColor;
            this.BackColor = Data.BackColor;
            label1.ForeColor = Data.FontColor;
            listBox1.ForeColor = Data.FontColor;
            this.ForeColor = Data.FontColor;
        }

        /// <summary>
        /// Добавление в listBox1 всех фаринтов частоты журналирования.
        /// </summary>
        /// <param name="sender">Издатель.</param>
        /// <param name="e">Информация о событии.</param>
        private void LoggingForm_Load(object sender, EventArgs e)
        {
            listBox1.Items.AddRange(frequencies);
        }

        /// <summary>
        /// Запись в Data  выбранную частоту журналирования и закрытие формы.
        /// </summary>
        /// <param name="sender">Издатель.</param>
        /// <param name="e">Информация о событии.</param>
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Data.LoggingFrequency = frequencies[listBox1.SelectedIndex];
            this.Close();
        }
    }
}
