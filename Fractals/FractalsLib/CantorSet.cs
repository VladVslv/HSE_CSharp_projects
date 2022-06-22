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
    /// Класс множества Кантора.
    /// </summary>
    public class CantorSet : Fractal
    {
        /// <summary>
        /// Расстояние между соседними отрезками.
        /// </summary>
        public static int Distance { get; set; } = 30;

        /// <summary>
        /// Рисование фрактала.
        /// </summary>
        public override void DrawFractal()
        {
            if (RecursionDepth > 12)
            {
                MessageBox.Show("Маскимальня глубина рекурсии для данного фрактала равна 12.\n" +
                    "Он будет нарисован с глубиной 12.");
                int currentRecursiondepth = RecursionDepth;
                RecursionDepth = 12;
                ChangeGradient();
                DrawOneStep(0, 10, MainCanvas.ActualWidth, RecursionDepth);
                RecursionDepth = currentRecursiondepth;
                ChangeGradient();
            }
            else
            {
                DrawOneStep(0, 10, MainCanvas.ActualWidth, RecursionDepth); ;
            }
        }

        /// <summary>
        /// Выполенние одного шага рекурсии и переход к следующим шагам.
        /// </summary>
        /// <param name="x">Абцисса первой точки отрезка.</param>
        /// <param name="y">Ордината первой точки отрезка.</param>
        /// <param name="len">Длина отрезка.</param>
        /// <param name="recursionstep">Оставшееся количество шагов рекурсии.</param>
        public void DrawOneStep(double x, double y, double len, int recursionstep)
        {
            if (recursionstep != 0)
            {
                DrawLine(x, y, x + len, y, Gradient[RecursionDepth - recursionstep]);
                DrawOneStep(x, y+Distance, len / 3.0, recursionstep - 1);
                DrawOneStep(x + len * 2.0 / 3.0, y + Distance, len / 3.0, recursionstep - 1);
            }
        }

        /// <summary>
        /// Рисование отрезка по двум точкам.
        /// </summary>
        /// <param name="x1">Абцисса первой точки.</param>
        /// <param name="y1">Ордината первой точки.</param>
        /// <param name="x2">Абцисса второй точки.</param>
        /// <param name="y2">Ордината второй точки.</param>
        /// <param name="color">Цвет отрезка.</param>
        public void DrawLine(double x1, double y1, double x2, double y2, Color color)
        {
            Line newLine = new();
            newLine.X1 = x1;
            newLine.X2 = x2;
            newLine.Y1 = y1;
            newLine.Y2 = y2;
            newLine.Stroke = new SolidColorBrush(color);
            newLine.StrokeThickness = 5;
            MainCanvas.Children.Add(newLine);
        }
    }
}