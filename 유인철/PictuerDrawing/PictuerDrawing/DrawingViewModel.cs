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
using System.Collections.ObjectModel;

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
        int remote = 0;
        private Point CurrentPoint = new Point();
        Rectangle rect;
        Ellipse ellipse;
        Polygon polygon;
        private ListBox savelistbox;

        private void Canvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            CurrentPoint = e.GetPosition(can);
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
            var pos = e.GetPosition(can);
            switch (remote)
            {
                case 0:
                    if (e.LeftButton == MouseButtonState.Pressed) // 선 그리기
                    {
                        Line line = new Line();
                        line.Stroke = CopyColor(brush);

                        line.X1 = CurrentPoint.X;
                        line.Y1 = CurrentPoint.Y;
                        line.X2 = e.GetPosition(can).X;
                        line.Y2 = e.GetPosition(can).Y;
                        CurrentPoint = e.GetPosition(can);
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
            polygon.Stroke = CopyColor(brush);
        }
        private void SetRectangle() // 사각형 유지
        {
            rect.Opacity = 1;
            rect.Stroke = CopyColor(brush);
        }
        private void SetEllipse() // 원 유지
        {
            ellipse.Opacity = 1;
            ellipse.Stroke = CopyColor(brush);
        }
        private SolidColorBrush CopyColor(SolidColorBrush b)
        {
            SolidColorBrush brush1 = new SolidColorBrush(b.Color);
            return brush1;
        }
        public ICommand ButtonCommand { get; set; }

        public DrawingViewModel(Canvas canvas, ListBox listbox)
        {
            can = canvas;
            can.MouseMove += Canvas_MouseMove;
            can.MouseLeftButtonDown += Canvas_MouseDown;
            can.MouseLeftButtonUp += Canvas_MouseUp;
            ButtonCommand = new RelayCommand(ButtonAction);
            CanvasName = new ObservableCollection<string>();
            savelistbox = listbox;
            //savelistbox.ItemsSource = CanvasName;
        }

        SolidColorBrush brush = new SolidColorBrush(Colors.Black);

        protected void ButtonAction(object sender)
        {
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
                case "Save":
                    Savelist();
                    break;
                case "Load":
                    Load();
                    break;
                case "Search":
                    Search();
                    break;
                case "Fix":

                    break;
                case "Delete":

                    break;
                case "Reset":

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
        
        List<Canvas> Canvaslist = new List<Canvas>();

        ObservableCollection<string> _CanvasName;
        public ObservableCollection<string> CanvasName
        {
            get { return _CanvasName; }
            set
            {
                _CanvasName = value;
                OnPropertyChanged("CanvasName");
            }
        }
        private void Savelist()
        {
            Canvas canvas = CopyCanvas(can);
            Canvaslist.Add(canvas);
            string CanvasNameIndex = Canvaslist.Count.ToString();
            CanvasName.Add(CanvasNameIndex);
            can.Children.Clear();
        }
        private Canvas CopyCanvas(Canvas c)
        {
            Canvas canvas = new Canvas();
            foreach (UIElement child in c.Children)
            {
                if (child is Line line)
                {
                    Line newline = new Line
                    {
                        X1 = line.X1,
                        X2 = line.X2,
                        Y1 = line.Y1,
                        Y2 = line.Y2,
                        Stroke = line.Stroke,
                        StrokeThickness = line.StrokeThickness
                    };
                    canvas.Children.Add(newline);
                }
                else if (child is Rectangle rect)
                {
                    Rectangle newrect = new Rectangle
                    {
                        Margin = rect.Margin,
                        Width = rect.Width,
                        Height = rect.Height,
                        Stroke = rect.Stroke,
                        StrokeThickness = rect.StrokeThickness
                    };
                    canvas.Children.Add(newrect);
                }
                else if (child is Polygon polygon)
                {
                    Polygon newpolygon = new Polygon
                    {
                        Points = polygon.Points,
                        Stroke = polygon.Stroke,
                        StrokeThickness = polygon.StrokeThickness
                    };
                    canvas.Children.Add(newpolygon);
                }
                else if (child is Ellipse ellipse)
                {
                    Ellipse newellipse = new Ellipse
                    {
                        Margin = ellipse.Margin,
                        Width = ellipse.Width,
                        Height = ellipse.Height,
                        Stroke = ellipse.Stroke,
                        StrokeThickness = ellipse.StrokeThickness
                    };
                    canvas.Children.Add(newellipse);
                }
            }
            return canvas;
        }
        private void Load()
        {
            if(savelistbox.SelectedItem != null)
            {
                can.Children.Clear();
                int count = savelistbox.SelectedIndex;
                LoadCanvas(Canvaslist[count]);
                savelistbox.SelectedIndex = -1;
            }
        }
        private void LoadCanvas(Canvas c)
        {
            foreach (UIElement child in c.Children)
            {
                if (child is Line line)
                {
                    Line newline = new Line
                    {
                        X1 = line.X1,
                        X2 = line.X2,
                        Y1 = line.Y1,
                        Y2 = line.Y2,
                        Stroke = line.Stroke,
                        StrokeThickness = line.StrokeThickness
                    };
                    can.Children.Add(newline);
                }
                else if (child is Rectangle rect)
                {
                    Rectangle newrect = new Rectangle
                    {
                        Margin = rect.Margin,
                        Width = rect.Width,
                        Height = rect.Height,
                        Stroke= rect.Stroke,
                        StrokeThickness = rect.StrokeThickness
                    };
                    can.Children.Add(newrect);
                }
                else if (child is Polygon polygon)
                {
                    Polygon newpolygon = new Polygon
                    {
                        Points = polygon.Points,
                        Stroke = polygon.Stroke,
                        StrokeThickness = polygon.StrokeThickness
                    };
                    can.Children.Add(newpolygon);
                }
                else if (child is Ellipse ellipse)
                {
                    Ellipse newellipse = new Ellipse
                    {
                        Margin = ellipse.Margin,
                        Width = ellipse.Width,
                        Height = ellipse.Height,
                        Stroke = ellipse.Stroke,
                        StrokeThickness = ellipse.StrokeThickness
                    };
                    can.Children.Add(newellipse);
                }
            }
        }

        private void Search()
        {

        }
    }
}
