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
    /// Форма для выбора частоты автосохранения файлов.
    /// </summary>
    public partial class AutoSaveForm : Form
    {

        private string[] frequencies = new string[] { "5", "10", "30", "60", "300", "600",
            "Выключить автосохранение" };

        /// <summary>
        /// Применение выбранной темы к данной форме.
        /// </summary>
        public AutoSaveForm()
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
        /// Запись выбранного варианта в Data и закрытие формы.
        /// </summary>
        /// <param name="sender">Издатель.</param>
        /// <param name="e">Информация о событии.</param>
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Data.AutoSaveFrequency = frequencies[listBox1.SelectedIndex];
            this.Close();
        }


        /// <summary>
        /// Добавление в listBox1 всех вариантов частоты автосохранение.
        /// </summary>
        /// <param name="sender">Издатель.</param>
        /// <param name="e">Информация о событии.</param>
        private void AutoSaveForm_Load(object sender, EventArgs e)
        {
            listBox1.Items.AddRange(frequencies);
        }
    }
}
