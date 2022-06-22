using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using FractalsLib;

namespace DrawingFractals
{
    /// <summary>
    /// Логика взаимодействия для ColorPicker.xaml
    /// Окна для изменения начального цвета рисования.
    /// </summary>
    public partial class StartingColorPicker : Window
    {
        public StartingColorPicker()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Изменение информации о текущем выбранном цвете.
        /// </summary>
        /// <param name="s">Издатель.</param>
        /// <param name="e">Информация о событии.</param>
        void OnSliderValueChanged(Object s, RoutedEventArgs e)
        {
            brushResult.Color = Color.FromArgb(255, (byte)redSlider.Value, (byte)greenSlider.Value, 
                (byte)blueSlider.Value);
        }

        /// <summary>
        /// Закрытие окна без сохранения изменений.
        /// </summary>
        /// <param name="sender">Издатель.</param>
        /// <param name="e">Информация о событии.</param>
        private void CancelButtonClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Закрытие окна с сохранением изменений.
        /// </summary>
        /// <param name="sender">Издатель.</param>
        /// <param name="e">Информация о событии.</param>
        private void OkButtonClick(object sender, RoutedEventArgs e)
        {
            Fractal.StartingColor= Color.FromArgb(255, (byte)redSlider.Value, (byte)greenSlider.Value,
                (byte)blueSlider.Value);
            this.Close();
        }
    }
}
