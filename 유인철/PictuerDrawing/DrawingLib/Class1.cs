using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Shapes;

namespace DrawingLib
{
    public class Class1
    {
        public Line DrawingLine(double X1, double X2, double Y1, double Y2, SolidColorBrush brush, double strokethickness) // 이렇게 하는게 맞을까요..?
        {
            Line line = new Line();
            line.X1 = X1;
            line.X2 = X2;
            line.Y1 = Y1;
            line.Y2 = Y2;
            line.Stroke = brush;
            line.StrokeThickness = strokethickness;
            return line;
        }
    }
}
