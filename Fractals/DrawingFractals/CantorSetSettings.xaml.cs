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
    /// Логика взаимодействия для CantorSetSettings.xaml
    /// Окно для изменения параметров множества Кантора.
    /// </summary>
    public partial class CantorSetSettings : Window
    {
        public CantorSetSettings()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Изменение информации о текущем значении слайдера.
        /// </summary>
        /// <param name="sender">Издатель.</param>
        /// <param name="e">Информация о событии.</param>
        private void DistanceSliderVAlueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            DistanceTextBox.Text = $"Растояние между отрезками (в пикселях): {(int)DistanceSlider.Value}";
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
        /// Закрытие окна с сохранением  изменений.
        /// </summary>
        /// <param name="sender">Издатель.</param>
        /// <param name="e">Информация о событии.</param>
        private void OkButtonClick(object sender, RoutedEventArgs e)
        {
            CantorSet.Distance = (int)DistanceSlider.Value;
            this.Close();
        }
    }
}
