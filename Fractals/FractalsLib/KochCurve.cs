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
    /// Класс кривой Коха.
    /// </summary>
    public class KochCurve : Fractal
    {
        //Отрезки, из которых состоит текущая фигура.
        protected List<Line> figure;

        /// <summary>
        /// Рисование фрактала.
        /// </summary>
        public override void DrawFractal()
        {
            figure = new();
            figure.Add(NewLine(0, MainCanvas.ActualHeight, MainCanvas.ActualWidth,
                MainCanvas.ActualHeight, StartingColor));
            if (RecursionDepth > 8)
            {
                MessageBox.Show("Маскимальня глубина рекурсии для данного фрактала равна 8.\n" +
                    "Он будет нарисован с глубиной 8.");
                int currentRecursiondepth = RecursionDepth;
                RecursionDepth = 8;
                ChangeGradient();
                for (int i = 1; i < RecursionDepth; i++)
                {
                    DrawOneStep(i);
                }
                RecursionDepth = currentRecursiondepth;
                ChangeGradient();
            }
            else
            {
                for (int i = 1; i < RecursionDepth; i++)
                {
                    DrawOneStep(i);
                }
            }
            foreach(Line line in figure)
            {
                MainCanvas.Children.Add(line);
            }
        }

        /// <summary>
        /// Возвращает отрезка по двум точкам.
        /// </summary>
        /// <param name="x1">Абцисса первой точки.</param>
        /// <param name="y1">Ордината первой точки.</param>
        /// <param name="x2">Абцисса второй точки.</param>
        /// <param name="y2">Ордината вторйо точки.</param>
        /// <param name="color">Цвет отрезка.</param>
        /// <returns>Отрезок по двум данным точкам и цвету.</returns>
        public Line NewLine(double x1, double y1, double x2, double y2, Color color)
        {
            Line newLine = new();
            newLine.X1 = x1;
            newLine.X2 = x2;
            newLine.Y1 = y1;
            newLine.Y2 = y2;
            newLine.Stroke = new SolidColorBrush(color);
            newLine.StrokeThickness = 1.5;
            return newLine;
        }

        /// <summary>
        /// Выполение одного шага рекурсии.
        /// </summary>
        /// <param name="recursionStep">Номер шага рекурсии для определения цвета отрезка.</param>
        public void DrawOneStep(int recursionStep)
        {
            List<Line> newFigure = new();
            foreach(Line line in figure)
            {
                newFigure.AddRange(TranformLine(line, Gradient[recursionStep]));
            }
            figure.Clear();
            figure.AddRange(newFigure);
        }

        /// <summary>
        /// Замена одного отрезка на нужную фигуру.
        /// </summary>
        /// <param name="line">Исходный отрезок.</param>
        /// <param name="color">Цвет построенных отрезков.</param>
        /// <returns>Отрезки, из которых состоит нужная фигура.</returns>
        public List<Line> TranformLine(Line line,Color color)
        {
            List<Line> tranformedLine = new();
            double x1 = line.X1;
            double y1 = line.Y1;
            double x5 = line.X2;
            double y5 = line.Y2;
            double x2 = (2.0 * x1 + x5) / 3.0;
            double y2 = (2.0 * y1 + y5) / 3.0;
            double x4 = (2.0 * x5 + x1) / 3.0;
            double y4 = (2.0 * y5 + y1) / 3.0;
            double len = Math.Sqrt((x2 - x4) * (x2 - x4) + (y2 - y4) * (y2 - y4));
            double x3 = x2 + len * (((x4 - x2) / len) / 2.0 + ((y4 - y2) / len) * Math.Sqrt(3) / 2.0);
            double y3 = y2 + len * (((y4 - y2) / len) / 2.0 - ((x4 - x2) / len) * Math.Sqrt(3) / 2.0);
            tranformedLine.Add(NewLine(x1, y1, x2, y2, ((SolidColorBrush)(line.Stroke)).Color));
            tranformedLine.Add(NewLine(x2, y2, x3, y3, color));
            tranformedLine.Add(NewLine(x3, y3, x4, y4, color));
            tranformedLine.Add(NewLine(x4, y4, x5, y5, ((SolidColorBrush)(line.Stroke)).Color));
            return tranformedLine;
        }
    }
}