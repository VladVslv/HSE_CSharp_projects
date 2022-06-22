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
    /// Класс фрактального дерева.
    /// </summary>
    public class Tree:Fractal
    {
        /// <summary>
        /// Угол наклона первого отрезка.
        /// </summary>
        public static double FirstAngle { get; set; } = 30;

        /// <summary>
        /// Угол наклона второго отрезка.
        /// </summary>
        public static double SecondAngle { get; set; } = 45;

        /// <summary>
        /// Коэффицент отношения длин отрезков.
        /// </summary>
        public static double Koef { get; set; } = 0.75;

        /// <summary>
        /// Рисование фрактала.
        /// </summary>
        public override void DrawFractal()
        {
            DrawOneStep(MainCanvas.ActualWidth / 2, 0, MainCanvas.ActualHeight / 4, 0.0, RecursionDepth);
        }

        /// <summary>
        /// Выполнение одного шага рекурсии и перехода к следующим шагам.
        /// </summary>
        /// <param name="x">Абцисса текущей точки.</param>
        /// <param name="y">Ордината текущей точкт.</param>
        /// <param name="len">Длина текущего отрезка.</param>
        /// <param name="angle">Угол наклона предыдущего отрезка.</param>
        /// <param name="recursionStep">Оставшееся количество шагов рекурсии.</param>
        public void DrawOneStep(double x, double y, double len, double angle, int recursionStep)
        {
            if (recursionStep !=0)
            {
                double newX = x + len * Math.Sin(angle * Math.PI * 2.0 / 360.0);
                double newY = y + len * Math.Cos(angle * Math.PI * 2.0 / 360.0);
                Color currentColor = Gradient[RecursionDepth - recursionStep];
                DrawLine(x, MainCanvas.ActualHeight-y, newX, MainCanvas.ActualHeight-newY, currentColor);
                DrawOneStep(newX, newY, len * Koef, angle - FirstAngle,  recursionStep - 1);
                DrawOneStep(newX, newY, len * Koef, angle + SecondAngle,  recursionStep - 1);
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
        public void DrawLine(double x1,double y1,double x2, double y2, Color color)
        {
            Line newLine = new();
            newLine.X1 = x1;
            newLine.X2 = x2;
            newLine.Y1 = y1;
            newLine.Y2 = y2;
            newLine.Stroke = new SolidColorBrush(color);
            newLine.StrokeThickness =2;
            MainCanvas.Children.Add(newLine);
        }
    }
}
