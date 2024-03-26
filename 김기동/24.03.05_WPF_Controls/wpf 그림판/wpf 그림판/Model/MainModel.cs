using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows;
using System.Windows.Controls;

namespace wpf_그림판.Model
{
    internal class MainModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler propertyChangedEventHandler = this.PropertyChanged;
            if (propertyChangedEventHandler != null)
            {
                propertyChangedEventHandler(this, new PropertyChangedEventArgs(name));
            }
        }

        private Canvas canvas;

        public MainModel(Canvas canvas)
        {
            this.canvas = canvas;
            canvas.MouseLeftButtonDown += Canvas_MouseLeftButtonDown;
            canvas.MouseMove += Canvas_MouseMove;
            canvas.MouseLeftButtonUp += Canvas_MouseLeftButtonUp;
        }

        public bool isDrawing = false;
        public Point startPoint;
        private SolidColorBrush brush = new SolidColorBrush(Colors.Black);

        public void SetColor(SolidColorBrush _brush)
        {
            brush = _brush;
        }
        private void Canvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //isDrawing = true;
            //startPoint = e.GetPosition(canvas);
        }

        public void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
        }

        public string TempText { get; set; }

        private string someStr;
        public string SomeStr
        {
            get
            {
                return someStr;
            }
            set
            {
                someStr = value;
            }
        }

        private SolidColorBrush penColor = new SolidColorBrush(Colors.Black);
        public SolidColorBrush PenColor
        {
            get { return penColor; }
            set
            {
                if (penColor != value)
                {
                    penColor = value;
                    OnPropertyChanged(nameof(PenColor));
                }
            }
        }

        private void Canvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //isDrawing = false;
        }

        public void DrawRectangle(object obj)
        {
            // 네모 그리기
            Rectangle rectangle = new Rectangle();
            rectangle.Width = 100;
            rectangle.Height = 100;
            rectangle.Fill = PenColor; // PenColor 사용

            // 마우스 클릭 위치를 기준으로 사각형 위치 설정
            
            Canvas.SetLeft(rectangle, startPoint.X);
            Canvas.SetTop(rectangle, startPoint.Y);

            canvas.Children.Add(rectangle);
        }
        //public void DrawRectangle(object parameter)
        //{
        //    if (parameter is Canvas canvas)
        //    {
        //        // 네모를 그릴 중심점과 크기를 정의합니다.
        //        Point center = new Point(50, 50); // 예시로 사용한 중심점
        //        double size = 100; // 예시로 사용한 크기

        //        DrawSquare(canvas, center, size, Colors.Blue);
        //    }
        //}

        //private void DrawSquare(Canvas canvas, Point center, double size, Color color)
        //{
        //    Point topLeft = new Point(center.X - size / 2, center.Y - size / 2);
        //    Point topRight = new Point(center.X + size / 2, center.Y - size / 2);
        //    Point bottomLeft = new Point(center.X - size / 2, center.Y + size / 2);
        //    Point bottomRight = new Point(center.X + size / 2, center.Y + size / 2);

        //    DrawPoint(canvas, topLeft, color);
        //    DrawPoint(canvas, topRight, color);
        //    DrawPoint(canvas, bottomLeft, color);
        //    DrawPoint(canvas, bottomRight, color);
        //}
        //private void DrawPoint(Canvas canvas, Point point, Color color)
        //{
        //    Ellipse ellipse = new Ellipse
        //    {
        //        Width = 4,
        //        Height = 4,
        //        Fill = new SolidColorBrush(color)
        //    };
        //    Canvas.SetLeft(ellipse, point.X - ellipse.Width / 2);
        //    Canvas.SetTop(ellipse, point.Y - ellipse.Height / 2);
        //    canvas.Children.Add(ellipse);
        //}
        public void DrawEllipse(object obj)
        {
            // 원 그리기
            Ellipse ellipse = new Ellipse();
            ellipse.Width = 100;
            ellipse.Height = 100;
            ellipse.Fill = PenColor; // PenColor 사용

            // 마우스 클릭 위치를 기준으로 원 위치 설정
            Canvas.SetLeft(ellipse, startPoint.X);
            Canvas.SetTop(ellipse, startPoint.Y);

            canvas.Children.Add(ellipse);
        }
        private void DrawPoint(Point point, Color color)
        {
            Ellipse ellipse = new Ellipse
            {
                Width = 4,
                Height = 4,
                Fill = new SolidColorBrush(color)
            };
            Canvas.SetLeft(ellipse, point.X - ellipse.Width / 2);
            Canvas.SetTop(ellipse, point.Y - ellipse.Height / 2);
            canvas.Children.Add(ellipse);
        }


    }
}
