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
    /// Форма для выбора нужной версиии текущего файла.
    /// </summary>
    public partial class VersionsOfFileForm : Form
    {
        /// <summary>
        /// Применение выбранной темы к данной форме и добавление в listBox1 всех вариантов вырсий теущего файла.
        /// </summary>
        public VersionsOfFileForm()
        {
            InitializeComponent();
            label1.BackColor = Data.BackColor;
            listBox1.BackColor = Data.BackColor;
            this.BackColor = Data.BackColor;
            label1.ForeColor = Data.FontColor;
            listBox1.ForeColor = Data.FontColor;
            this.ForeColor = Data.FontColor;
            foreach (string elem in Directory.GetFiles("VersionsOfFiles\\" + 
                Path.GetFileName(Data.CurrentFile.Path)[..^4]))
            {
                listBox1.Items.Add(File.GetCreationTime(elem));
            }
        }

        /// <summary>
        /// Запись выбранной версии файла в Data и закрытие формы.
        /// </summary>\
        /// <param name="sender">Издатель.</param>
        /// <param name="e">Информация о событии.</param>
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Data.VersionOfFile = Directory.GetFiles("VersionsOfFiles\\" + 
                Path.GetFileName(Data.CurrentFile.Path)[..^4])[listBox1.SelectedIndex];
            this.Close();
        }
    }
}
