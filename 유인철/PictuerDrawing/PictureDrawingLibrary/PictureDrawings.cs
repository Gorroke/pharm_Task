using System.Collections.Generic;
using System.Drawing;
using System.Reflection.Emit;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace PictureDrawingLibrary
{
    public class PictureDrawings
    {
        public static void MouseEvent(object sender, Point currentPoint, int remote, List<UIElement> linelist)
        {

            switch (remote)
            {
                case 0:
                    linelist = new List<UIElement>();
                    break;
                case 1:
                    if (rect == null)
                    {
                        CreateRectangle();
                    }
                    break;
                case 2:
                    if (polygon == null)
                    {
                        CreatePolygon();
                    }
                    break;
                case 3:
                    if (ellipse == null)
                    {
                        CreateEllipse();
                    }
                    break;
            }
        }
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
