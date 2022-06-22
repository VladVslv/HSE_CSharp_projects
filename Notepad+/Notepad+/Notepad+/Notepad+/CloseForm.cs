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
    /// Форма для выбора действия при закрытии главной формы.
    /// </summary>
    public partial class CloseForm : Form
    {
        /// <summary>
        /// Применение выбранной темы к данной форме.
        /// </summary>
        public CloseForm()
        {
            InitializeComponent();
            this.BackColor = Data.BackColor;
            cancelClosingButton.BackColor = Data.BackColor;
            saveButton.BackColor = Data.BackColor;
            notSaveButton.BackColor = Data.BackColor;
            this.ForeColor = Data.FontColor;
            cancelClosingButton.ForeColor = Data.FontColor;
            saveButton.ForeColor = Data.FontColor;
            notSaveButton.ForeColor = Data.FontColor;
            notSaveSettingsButton.ForeColor = Data.FontColor;
            notSaveSettingsButton.BackColor = Data.BackColor;
        }

        /// <summary>
        /// Запись выбранного варианта в Data при нажатии кнопки, соответсвующей этому варианту.
        /// </summary>
        /// <param name="sender">Издатель.</param>
        /// <param name="e">Информация о событии.</param>
        private void NotSaveButton_Click(object sender, EventArgs e)
        {
            Data.ClosingChoice = "NotSave";
            this.Close();
        }

        /// <summary>
        /// Запись выбранного варианта в Data при нажатии кнопки, соответсвующей этому варианту.
        /// </summary>
        /// <param name="sender">Издатель.</param>
        /// <param name="e">Информация о событии.</param>
        private void SaveButton_Click(object sender, EventArgs e)
        {
            Data.ClosingChoice = "Save";
            this.Close();
        }

        /// <summary>
        /// Запись выбранного варианта в Data при нажатии кнопки, соответсвующей этому варианту.
        /// </summary>
        /// <param name="sender">Издатель.</param>
        /// <param name="e">Информация о событии.</param>
        private void CancelButton_Click(object sender, EventArgs e)
        {
            Data.ClosingChoice = "Cancel";
            this.Close();
        }

        /// <summary>
        /// Запись выбранного варианта в Data при нажатии кнопки, соответсвующей этому варианту.
        /// </summary>
        /// <param name="sender">Издатель.</param>
        /// <param name="e">Информация о событии.</param>
        private void NotSaveSettingsButton_Click(object sender, EventArgs e)
        {
            Data.ClosingChoice = "NotSaveSettings";
            this.Close();
        }
    }
}
