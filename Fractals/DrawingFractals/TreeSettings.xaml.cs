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
    /// Логика взаимодействия для TreeSettings.xaml
    /// Окно для изменения параметров фрактального дерева.
    /// </summary>
    public partial class TreeSettings : Window
    {
        public TreeSettings()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Изменение информации о текущем выбранном коэффиценте отношения отрезков.
        /// </summary>
        /// <param name="sender">Издатель.</param>
        /// <param name="e">Информация о событии.</param>
        private void KoefSliderValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            KoefTextBox.Text = $"Коэффицент отношения длин отрезков: {KoefSlider.Value.ToString("f2")}";
        }

        /// <summary>
        /// Изменение информации о текущем выбранном угле отклонения первого отрезка.
        /// </summary>
        /// <param name="sender">Издатель.</param>
        /// <param name="e">Информация о событии.</param>
        private void FirstAngleSliderValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            FirstAngleTextBox.Text = $"Угол наклона первого отрезка(в градусах): {FirstAngleSlider.Value}";
        }

        /// <summary>
        /// Изменение информации о текущем выбранном угле отклонения второго отрезка.
        /// </summary>
        /// <param name="sender">Издатель.</param>
        /// <param name="e">Информация о событии.</param>
        private void SecondAngleSliderValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            SecondAngleTextBox.Text = $"Угол наклона второго отрезка(в градусах): {SecondAngleSlider.Value}";
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
            Tree.Koef = KoefSlider.Value;
            Tree.FirstAngle = FirstAngleSlider.Value;
            Tree.SecondAngle = SecondAngleSlider.Value;
            this.Close();
        }
    }
}
