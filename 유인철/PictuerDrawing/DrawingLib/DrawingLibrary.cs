using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace DrawingLib
{
    public class DrawingLibrary
    {
        public Line DrawingLine(double X1, double X2, double Y1, double Y2, SolidColorBrush brush, double strokethickness)
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

        public Ellipse DrawingMoveElli(Point pos, Point CurrentPoint, Ellipse ellipse)
        {
            double left = pos.X;
            double top = pos.Y;
            if (pos.X > CurrentPoint.X)
            {
                left = CurrentPoint.X;
            }
            if (pos.Y > CurrentPoint.Y)
            {
                top = CurrentPoint.Y;
            }
            ellipse.Margin = new Thickness(left, top, 0, 0);
            ellipse.Width = Math.Abs(pos.X - CurrentPoint.X);
            ellipse.Height = Math.Abs(pos.Y - CurrentPoint.Y);
            return ellipse;
        }

        public Polygon DrawingMovePoly(Point pos, Point CurrentPoint, Polygon polygon)
        {
            PointCollection points = new PointCollection();
            double a = Math.Abs(CurrentPoint.X + pos.X) / 2;
            double h = CurrentPoint.Y;
            points.Add(new Point(CurrentPoint.X, pos.Y));
            points.Add(new Point(a, h));
            points.Add(pos);
            polygon.Points = points;
            return polygon;
        }

        public Rectangle DrawingMoveRect(Point pos, Point CurrentPoint, Rectangle rect)
        {
            double left = pos.X;
            double top = pos.Y;
            if (pos.X > CurrentPoint.X)
            {
                left = CurrentPoint.X;
            }
            if (pos.Y > CurrentPoint.Y)
            {
                top = CurrentPoint.Y;
            }
            rect.Margin = new Thickness(left, top, 0, 0);
            rect.Width = Math.Abs(pos.X - CurrentPoint.X);
            rect.Height = Math.Abs(pos.Y - CurrentPoint.Y);
            return rect;
        }
        public Polygon CreatePolygon(Polygon polygon, SolidColorBrush brush, double strokethickness) // 삼각형 만들기
        {
            polygon = new Polygon();
            polygon.Stroke = brush;
            polygon.StrokeThickness = strokethickness;
            return polygon;
        }

        public Rectangle CreateRect(Rectangle rect, SolidColorBrush brush, double strokethickness)
        {
            rect = new Rectangle();
            rect.Stroke = brush;
            rect.StrokeThickness = strokethickness;
            return rect;
        }

        public Ellipse Createelli(Ellipse ellipse, SolidColorBrush brush, double strokethickness)
        {
            ellipse = new Ellipse();
            ellipse.Stroke = brush;
            ellipse.StrokeThickness = strokethickness;
            return ellipse;
        }
    }
}
