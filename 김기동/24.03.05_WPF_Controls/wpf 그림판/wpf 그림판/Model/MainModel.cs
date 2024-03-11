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
            //if (isDrawing)
            //{
            //    Line line = new Line();
            //    line.Stroke = brush;
            //    line.StrokeThickness = 2;
            //    line.X1 = startPoint.X;
            //    line.Y1 = startPoint.Y;
            //    line.X2 = e.GetPosition(canvas).X;
            //    line.Y2 = e.GetPosition(canvas).Y;
         
            //    canvas.Children.Add(line);

            //    startPoint = e.GetPosition(canvas);
            //}
            
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

        public void DrawRectangle()
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

        public void DrawEllipse()
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
    }
}
