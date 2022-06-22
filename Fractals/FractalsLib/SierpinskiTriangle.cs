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
    /// Класс треугольника Срепинского.
    /// </summary>
    public class SierpinskiTriangle : Fractal
    {
        /// <summary>
        /// Рисование фрактала.
        /// </summary>
        public override void DrawFractal()
        {
            if (RecursionDepth > 8)
            {
                MessageBox.Show("Маскимальня глубина рекурсии для данного фрактала равна 8.\n" +
                    "Он будет нарисован с глубиной 8.");
                int currentRecursiondepth = RecursionDepth;
                RecursionDepth = 8;
                ChangeGradient();
                DrawRightTriangle(0, Math.Min(MainCanvas.ActualHeight * 2.0 / Math.Sqrt(3),
                MainCanvas.ActualWidth), MainCanvas.ActualHeight, 1, StartingColor);
                DrawOneStep(0, Math.Min(MainCanvas.ActualHeight * 2.0 / Math.Sqrt(3),
                MainCanvas.ActualWidth), MainCanvas.ActualHeight, RecursionDepth - 1);
                RecursionDepth = currentRecursiondepth;
                ChangeGradient();
            }
            else
            {
                DrawRightTriangle(0, Math.Min(MainCanvas.ActualHeight * 2.0 / Math.Sqrt(3),
                MainCanvas.ActualWidth), MainCanvas.ActualHeight, 1, StartingColor);
                DrawOneStep(0, Math.Min(MainCanvas.ActualHeight * 2.0 / Math.Sqrt(3),
                MainCanvas.ActualWidth), MainCanvas.ActualHeight, RecursionDepth - 1);
            }
            
        }

        /// <summary>
        /// Выполнение одного шага рекурсии и перехода к следующим шагам.
        /// </summary>
        /// <param name="x1">
        /// Абцисса первой точки основания равностороннего треугольника,
        /// который был нарисован на предыдущем шаге.
        /// </param>
        /// <param name="x2">
        /// Абцисса второй точки основания равностороннего треугольника,
        /// который был нарисован на предыдущем шаге.
        /// </param>
        /// <param name="y">
        /// Ордината второй и первой точки основания равностороннего треугольника,
        /// который был нарисован на предыдущем шаге.
        /// </param>
        /// <param name="recursionStep">Оставшееся количество шагов рекурсии.</param>
        public void DrawOneStep(double x1, double x2,double y, int recursionStep)
        {
            if (recursionStep != 0)
            {
                DrawRightTriangle((x1 + (x1 + x2) / 2.0)/2.0, (x2 + (x1 + x2) / 2.0)/2.0,
                    y - 0.5*(Math.Abs(x1 - x2) * Math.Sqrt(3) / 2.0), -1, Gradient[RecursionDepth - recursionStep]);
                DrawOneStep(x1, (x1 + x2) / 2.0, y, recursionStep - 1);
                DrawOneStep((x1 + x2) / 2.0, x2, y, recursionStep - 1);
                DrawOneStep((x1 + (x1 + x2) / 2.0) / 2.0, (x2 + (x1 + x2) / 2.0) / 2.0,
                    y - 0.5*(Math.Abs(x1 - x2) * Math.Sqrt(3) / 2.0), recursionStep - 1);
            }
        }

        /// <summary>
        /// Рисование правильного треугольника по 2 точкам.
        /// </summary>
        /// <param name="x1">Абцисса первой точки.</param>
        /// <param name="x2">Абцисса второй точки.</param>
        /// <param name="y">Ордината первой и второй точки.</param>
        /// <param name="direction">"Направление" треугольника.</param>
        /// <param name="color">Цвет границ треугольника.</param>
        public void DrawRightTriangle(double x1, double x2, double y, int direction, Color color)
        {
            DrawTriangle(x1, y, x2, y, (x1 + x2) / 2.0,
                (double)(-direction) * (Math.Abs(x1 - x2) * Math.Sqrt(3) / 2.0) + y, color);
        }

        /// <summary>
        /// Рисование тругольника по 3 точкам.
        /// </summary>
        /// <param name="x1">Абцисса первой точки.</param>
        /// <param name="y1">Ордината первой точки.</param>
        /// <param name="x2">Абцисса второй точки.</param>
        /// <param name="y2">Ордината второй точки.</param>
        /// <param name="x3">Абцисса третьей точки.</param>
        /// <param name="y3">Ордината третьей точки.</param>
        /// <param name="color">Цвет границ треугольника.</param>
        public void DrawTriangle(double x1,double y1,double x2,double y2,double x3,double y3, Color color)
        {
            Polygon newTriangle = new();
            newTriangle.Points = new PointCollection() { new Point(x1, y1), new Point(x2, y2), new Point(x3, y3) };
            newTriangle.StrokeThickness = 1;
            newTriangle.Stroke = new SolidColorBrush(color);
            MainCanvas.Children.Add(newTriangle);

        }
    }
}
