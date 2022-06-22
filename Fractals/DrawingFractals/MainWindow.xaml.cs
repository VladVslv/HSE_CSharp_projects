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
using System.Windows.Navigation;
using System.Windows.Shapes;
using FractalsLib;
using System.IO;

namespace DrawingFractals
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// Основное окно программы.
    /// </summary>
    public partial class MainWindow : Window
    {
        //Выбранный фрактал.
        Fractal currentFractal;
        public MainWindow()
        {
            InitializeComponent();

            ///Изменение минимального размера окна в соответсвии с размеров экрана.
            this.MinHeight = SystemParameters.PrimaryScreenHeight / 2.0;
            this.MinWidth = SystemParameters.PrimaryScreenWidth / 2.0;
        }

        /// <summary>
        /// Открытие окна для изменения параметров фрактального дерева и его рисование.
        /// </summary>
        /// <param name="sender">Издатель.</param>
        /// <param name="e">Информация о событии.</param>
        private void TreeButtonClick(object sender, MouseButtonEventArgs e)
        {
            (new TreeSettings()).ShowDialog();
            currentFractal = new Tree();
            FractalComboBox.SelectedIndex = 0;
            Draw();
        }

        /// <summary>
        /// Рисование кривой Коха.
        /// </summary>
        /// <param name="sender">Издатель.</param>
        /// <param name="e">Информация о событии.</param>
        private void KochSnowFlakeButtonClick(object sender, MouseButtonEventArgs e)
        {
            currentFractal = new KochCurve();
            Draw();
        }

        /// <summary>
        /// Рисование ковра Серпинского.
        /// </summary>
        /// <param name="sender">Издатель.</param>
        /// <param name="e">Информация о событии.</param>
        private void SierpinskiCarpetButtonClick(object sender, MouseButtonEventArgs e)
        {
            currentFractal = new SierpinskiCarpet();
            Draw();
        }

        /// <summary>
        /// Рисование треугольника Серпинского.
        /// </summary>
        /// <param name="sender">Издатель.</param>
        /// <param name="e">Информация о событии.</param>
        private void SierpinskiTriangleButtonClick(object sender, MouseButtonEventArgs e)
        {
            currentFractal = new SierpinskiTriangle();
            Draw();
        }

        /// <summary>
        /// Открытие окна для изменения параметров множества Кантора и его рисование.
        /// </summary>
        /// <param name="sender">Издатель.</param>
        /// <param name="e">Информация о событии.</param>
        private void CantorSetButtonClick(object sender, MouseButtonEventArgs e)
        {
            (new CantorSetSettings()).ShowDialog();
            currentFractal = new CantorSet();
            FractalComboBox.SelectedIndex = 4;
            Draw();
        }

        /// <summary>
        /// Вывод информации о максимальной глубине рекурсии для каждого фрактала,
        /// и окрытие окна для изменения глубины рекурсии.
        /// </summary>
        /// <param name="sender">Издатель.</param>
        /// <param name="e">Информация о событии.</param>
        private void RecursionDepthButtonClick(object sender, RoutedEventArgs e)
        {
            (new RecursionDepthPicker()).ShowDialog();
            Draw();
        }

        /// <summary>
        /// Открытие окна для измененя начального цвета рисования, перерисовка фрактала.
        /// </summary>
        /// <param name="sender">Издатель.</param>
        /// <param name="e">Информация о событии.</param>
        private void StartingColorButtonClick(object sender, RoutedEventArgs e)
        {
            (new StartingColorPicker()).ShowDialog();
            Draw();
        }

        /// <summary>
        /// Сохранение изображения текущего фрактала в виде PNG-файла.
        /// </summary>
        /// <param name="sender">Издатель.</param>
        /// <param name="e">Информация о событии.</param>
        private void SaveImageButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                RenderTargetBitmap btm = new RenderTargetBitmap((int)mainCanvas.ActualWidth,
                (int)mainCanvas.ActualHeight, 96d, 96d, PixelFormats.Pbgra32);
                btm.Render(mainCanvas); ;
                PngBitmapEncoder encoder = new PngBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(btm));
                using (FileStream fileStream = File.OpenWrite($"ImagesOfFractals\\imageOfFractal_" +
                    $"{Directory.GetFiles("ImagesOfFractals").Length + 1}.png"))
                {
                    encoder.Save(fileStream);
                }
                MessageBox.Show($"Изображение было сохранено в папку: {System.IO.Path.GetFullPath("ImagesOfFractals")}");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        /// <summary>
        /// Рисование текущего фрактала.
        /// </summary>
        private void Draw()
        {
            Fractal.ChangeGradient();
            mainCanvas.Children.Clear();
            currentFractal.DrawFractal();
        }

        /// <summary>
        /// Открытие окна для измененя конечного цвета рисования, перерисовка фрактала.
        /// </summary>
        /// <param name="sender">Издатель.</param>
        /// <param name="e">Информация о событии.</param>
        private void EndingColorButtonClick(object sender, RoutedEventArgs e)
        {
            (new EndingColorPicker()).ShowDialog();
            Draw();
        }

        /// <summary>
        /// Инициализация свойства Fractal.MainCanvas для рисования всех фракталов,
        /// подписка на обработчик события изменения размера окна.
        /// </summary>
        /// <param name="sender">Издатель.</param>
        /// <param name="e">Информация о событии.</param>
        private void MainWindowLoaded(object sender, RoutedEventArgs e)
        {
            Fractal.MainCanvas = this.mainCanvas;
            currentFractal = new Tree();
            Draw();
            FractalComboBox.SelectedIndex = 0;
            this.SizeChanged += WindowSizeChanged;
        }

        /// <summary>
        /// Перерисовка фрактала при изменении размера окна.
        /// </summary>
        /// <param name="sender">Издатель.</param>
        /// <param name="e">Информация о событии.</param>
        private void WindowSizeChanged(object sender, SizeChangedEventArgs e)
        {
            Draw();
        }
    }
}
