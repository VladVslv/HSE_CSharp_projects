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
    /// Форма, в которой содержится текст с инфомацией о горячих клавишах.
    /// </summary>
    public partial class InstructionForm : Form
    {
        public InstructionForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Применение нашой "темы" к даннлй форме.
        /// </summary>
        private void Instruction_Load(object sender, EventArgs e)
        {
            label1.BackColor = Data.BackColor;
            this.BackColor = Data.BackColor;
            label1.ForeColor = Data.FontColor;
            this.ForeColor = Data.FontColor;
            button1.BackColor = Data.BackColor;
            button1.ForeColor = Data.FontColor;
        }

        /// <summary>
        /// Закрытие формы.
        /// </summary>
        /// <param name="sender">Издатель.</param>
        /// <param name="e">Информация о событии.</param>
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
