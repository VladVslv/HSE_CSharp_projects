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
    /// Базовых класс для фракталов.
    /// </summary>
    public abstract class Fractal
    {
        /// <summary>
        /// Canvas, где рисуются все фракталы.
        /// </summary>
        public static Canvas MainCanvas { get; set; }

        /// <summary>
        /// Глубина рекурсии.
        /// </summary>
        public static int RecursionDepth { get; set; } = 5;

        /// <summary>
        /// Начальный цвет рисования.
        /// </summary>
        public static Color StartingColor { get; set; } = Colors.Black;

        /// <summary>
        /// Конечный цвет рисования.
        /// </summary>
        public static Color EndingColor { get; set; } = Colors.Salmon;

        /// <summary>
        /// Список цветов для каждого шага рекурсии.
        /// </summary>
        public static List<Color> Gradient { get; set; }

        /// <summary>
        /// Изменение списка цветов.
        /// </summary>
        public static void ChangeGradient()
        {
            Gradient = new();
            for(int i = 0; i < RecursionDepth; i++)
            {
                Gradient.Add(Color.FromArgb(255,
                    (byte)(StartingColor.R - (StartingColor.R - EndingColor.R) * i / (RecursionDepth-1)),
                    (byte)(StartingColor.G - (StartingColor.G - EndingColor.G) * i / (RecursionDepth-1)),
                    (byte)(StartingColor.B - (StartingColor.B - EndingColor.B) * i / (RecursionDepth-1))));
            }
        }

        /// <summary>
        /// Рисование фрактала.
        /// </summary>
        public abstract void DrawFractal();

    }
}
