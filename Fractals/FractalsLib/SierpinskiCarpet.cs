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

namespace FractalsLib
{
    /// <summary>
    /// Класс ковра Серпинского.
    /// </summary>
    public class SierpinskiCarpet : Fractal
    {
        /// <summary>
        /// Рисование фрактала.
        /// </summary>
        public override void DrawFractal()
        {
            double maxSide = Math.Min(MainCanvas.ActualWidth, MainCanvas.ActualHeight);
            if (RecursionDepth > 6)
            {
                MessageBox.Show("Маскимальня глубина рекурсии для данного фрактала равна 6.\n" +
                    "Он будет нарисован с глубиной 6.");
                DrawSquare(maxSide / 2.0, maxSide / 2.0, maxSide, Colors.AntiqueWhite);
                int currentRecursiondepth = RecursionDepth;
                RecursionDepth = 6;
                ChangeGradient();
                DrawOneStep(maxSide / 2.0, maxSide / 2.0, maxSide, RecursionDepth);
                RecursionDepth = currentRecursiondepth;
                ChangeGradient();
            }
            else
            {
                DrawSquare(maxSide / 2.0, maxSide / 2.0, maxSide, Colors.AntiqueWhite);
                DrawOneStep(maxSide / 2.0, maxSide / 2.0, maxSide, RecursionDepth);
            }
        }

        /// <summary>
        /// Выполнение одного шага рекурсии и переход к следующим шагам.
        /// </summary>
        /// <param name="x">Абцисса центра текущего квадрата.</param>
        /// <param name="y">Ордината центра теущего квадрата.</param>
        /// <param name="len">Длина стороны квадрата, в котором должен находиться текущий.</param>
        /// <param name="recursionStep">Оставшееся количество шагов рекурсии.</param>
        public void DrawOneStep(double x, double y, double len, int recursionStep)
        {
            if (recursionStep > 0)
            {
                DrawSquare(x, y, len / 3.0, Gradient[RecursionDepth - recursionStep]);
                DrawOneStep(x - len / 3.0, y, len / 3.0, recursionStep - 1);
                DrawOneStep(x + len / 3.0, y, len / 3.0, recursionStep - 1);
                DrawOneStep(x, y - len / 3.0, len / 3.0, recursionStep - 1);
                DrawOneStep(x, y + len / 3.0, len / 3.0, recursionStep - 1);
                DrawOneStep(x - len / 3.0, y - len / 3.0, len / 3.0, recursionStep - 1);
                DrawOneStep(x + len / 3.0, y - len / 3.0, len / 3.0, recursionStep - 1);
                DrawOneStep(x - len / 3.0, y + len / 3.0, len / 3.0, recursionStep - 1);
                DrawOneStep(x + len / 3.0, y + len / 3.0, len / 3.0, recursionStep - 1);
            }
        }

        /// <summary>
        /// Рисование квадрата по координатам его центра и длине.
        /// </summary>
        /// <param name="x">Абцисса центра.</param>
        /// <param name="y">Ордината центра.</param>
        /// <param name="len">Длина стороны.</param>
        /// <param name="color">Цвет заливки квадрата.</param>
        public void DrawSquare(double x, double y, double len, Color color)
        {
            Polygon newPolygon = new();
            newPolygon.Points = new PointCollection() { new Point(x-len/2.0,y-len/2.0),
                new Point(x - len / 2.0, y + len / 2.0), new Point(x + len / 2.0, y + len / 2.0),
                new Point(x + len / 2.0, y - len / 2.0) };
            newPolygon.Fill = new SolidColorBrush(color);
            newPolygon.Stroke = new SolidColorBrush(color);
            MainCanvas.Children.Add(newPolygon);
        }
    }
}