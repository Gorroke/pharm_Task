using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace PictuerDrawing
{
    internal class DrawingViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private Canvas can;
        public Canvas Canvas
        {
            get { return can; }
            set { can = value; }
        }
        int remote = 0;
        private Point CurrentPoint = new Point();
        Rectangle rect;
        Ellipse ellipse;
        Polygon polygon;

        private void Canvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            CurrentPoint = e.GetPosition((Canvas)sender);
            switch (remote)
            {
                case 0:
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
        private void CreatePolygon() // 삼각형 만들기
        {
            polygon = new Polygon();
            polygon.Stroke = brush;
            can.Children.Add(polygon);
        }

        private void CreateEllipse() // 원 만들기
        {
            ellipse = new Ellipse();
            ellipse.Stroke = brush;
            can.Children.Add(ellipse);
        }

        private void CreateRectangle() // 사각형 만들기
        {
            rect = new Rectangle();
            rect.Stroke = brush;
            can.Children.Add(rect);
        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            var pos = e.GetPosition((Canvas)sender);
            switch (remote)
            {
                case 0:
                    if (e.LeftButton == MouseButtonState.Pressed) // 선 그리기
                    {
                        Line line = new Line();
                        line.Stroke = brush;

                        line.X1 = CurrentPoint.X;
                        line.Y1 = CurrentPoint.Y;
                        line.X2 = e.GetPosition((Canvas)sender).X;
                        line.Y2 = e.GetPosition((Canvas)sender).Y;
                        CurrentPoint = e.GetPosition((Canvas)sender);
                        can.Children.Add(line);
                    }
                    break;
                case 1:
                    if (e.LeftButton == MouseButtonState.Pressed) // 사각형 만들기
                    {
                        if (rect != null)
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
                        }
                    }
                    break;
                case 2:
                    if (e.LeftButton == MouseButtonState.Pressed) //삼각형 그리기
                    {
                        if (polygon != null)
                        {
                            PointCollection points = new PointCollection();
                            double a = Math.Abs(CurrentPoint.X + pos.X) / 2;
                            double h = a * Math.Tan(60);
                            points.Add(new Point(CurrentPoint.X, pos.Y));
                            points.Add(new Point(a, h));
                            points.Add(pos);
                            polygon.Points = points;
                        }
                    }
                    break;
                case 3:
                    if (e.LeftButton == MouseButtonState.Pressed) // 원 그리기
                    {
                        if (ellipse != null)
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
                        }
                    }
                    break;
            }
        }
        private void Canvas_MouseUp(object sender, MouseEventArgs e)
        {
            can.ReleaseMouseCapture();
            switch (remote)
            {
                case 0:
                    break;
                case 1:
                    SetRectangle();
                    rect = null;
                    break;
                case 2:
                    SetPolygon();
                    polygon = null;
                    break;
                case 3:
                    SetEllipse();
                    ellipse = null;
                    break;
            }
        }
        private void SetPolygon() // 삼각형 유지
        {
            polygon.Opacity = 1;
            polygon.Stroke = brush;
        }
        private void SetRectangle() // 사각형 유지
        {
            rect.Opacity = 1;
            rect.Stroke = brush;
        }
        private void SetEllipse() // 원 유지
        {
            ellipse.Opacity = 1;
            ellipse.Stroke = brush;
        }

        public ICommand ButtonCommand { get; set; }

        public DrawingViewModel()
        {
            ButtonCommand = new RelayCommand(ButtonAction);
            
        }
        public DrawingViewModel(Canvas canvas)
        {
            Canvas = canvas;
            Canvas.MouseMove += Canvas_MouseMove;
            Canvas.MouseDown += Canvas_MouseDown;
            Canvas.MouseUp += Canvas_MouseUp;
            ButtonCommand = new RelayCommand(ButtonAction);
        }
        SolidColorBrush brush = new SolidColorBrush();
        protected void ButtonAction(object sender)
        {
            MessageBox.Show(sender.ToString());
            switch (sender)
            {
                case "Pen":
                    remote = 0;
                    break;
                case "Square":
                    remote = 1;
                    break;
                case "Angle":
                    remote = 2;
                    break;
                case "Circle":
                    remote = 3;
                    break;
                case "Red":
                    brush.Color = Colors.Red;
                    break;
                case "Orange":
                    brush.Color = Colors.Orange;
                    break;
                case "Yellow":
                    brush.Color = Colors.Yellow;
                    break;
                case "Green":
                    brush.Color = Colors.Green;
                    break;
                case "Blue":
                    brush.Color = Colors.Blue;
                    break;
                case "Navy":
                    brush.Color = Colors.Navy;
                    break;
                case "Purple":
                    brush.Color = Colors.Purple;
                    break;
                case "Black":
                    brush.Color = Colors.Black;
                    break;
            }
        }

        
    }
}
