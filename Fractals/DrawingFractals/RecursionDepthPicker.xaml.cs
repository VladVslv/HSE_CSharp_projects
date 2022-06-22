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
    /// Логика взаимодействия для RecursionDepthPicker.xaml
    /// Окно для имзенение глубины рекурсии.
    /// </summary>
    public partial class RecursionDepthPicker : Window
    {
        public RecursionDepthPicker()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Изменение информации о текущей выбранно глубине рекурсии.
        /// </summary>
        /// <param name="sender">Издатель.</param>
        /// <param name="e">Информация о событии.</param>
        private void OnDepthSliderValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            textBox1.Text= "Глубина рекурсии: "+depthSlider.Value.ToString();
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
            Fractal.RecursionDepth = (int)depthSlider.Value;
            this.Close();
        }
    }
}
