﻿using System;
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
            CanvasListName = new ObservableCollection<string>();
            savelistbox = listbox;
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
                /*case "Naming":
                    Naming();
                    break;*/
                case "Delete":
                    Delete();
                    break;
                case "Reset":
                    Reset();
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

        ObservableCollection<string> _CanvasListName;
        public ObservableCollection<string> CanvasListName
        {
            get { return _CanvasListName; }
            set
            {
                _CanvasListName = value;
                OnPropertyChanged("CanvasListName");
            }
        }
        private void Savelist()
        {
            SubWindow sw = new SubWindow(1);
            sw.ShowDialog();
            NameingPicture np = NameingPicture.GetInstance();
            string CanvasName = np.PictureName;
            SaveCanvas(can, CanvasName);
            CanvasListName.Add(CanvasName);
            can.Children.Clear();
        }
        private void SaveCanvas(Canvas c, string CanvasName)
        {
            DB db = DB.GetInstance();
            int Linecount = 0;
            int Rectcount = 0;
            int Polycount = 0;
            int Ellicount = 0;
            foreach (UIElement child in c.Children)
            {
                if (child is Line line)
                {
                    string query = $"insert into PictureObject values ('{CanvasName}','Line','{Linecount}')";
                    db.SaveDB(query);
                    query = $"insert into PictureLine values ('{CanvasName}','{line.X1}','{line.X2}','{line.Y1}','{line.Y2}','{line.Stroke.ToString()}','{line.StrokeThickness}','{Linecount}')";
                    db.SaveDB(query);
                    Linecount++;
                }
                else if (child is Rectangle rect)
                {
                    string query = $"insert into PictureObject values ('{CanvasName}','Rectangle','{Rectcount}')";
                    db.SaveDB(query);
                    query = $"insert into PictureRectangle values ('{CanvasName}','{rect.Margin.Top}','{rect.Width}','{rect.Height}','{rect.Stroke.ToString()}','{rect.StrokeThickness}','{Rectcount}','{rect.Margin.Left}')";
                    db.SaveDB(query);
                    Rectcount++;
                }
                else if (child is Polygon polygon)
                {
                    string query = $"insert into PictureObject values ('{CanvasName}','Polygon','{Polycount}')";
                    db.SaveDB(query);
                    query = $"insert into PicturePolygon values ('{CanvasName}','{polygon.Points[0]}','{polygon.Stroke.ToString()}','{polygon.StrokeThickness}','{Polycount}','{polygon.Points[1]}','{polygon.Points[2]}')";
                    db.SaveDB(query);
                    Polycount++;
                }
                else if (child is Ellipse ellipse)
                {
                    string query = $"insert into PictureObject values ('{CanvasName}','Ellipse','{Ellicount}')";
                    db.SaveDB(query);
                    query = $"insert into PictureEllipse values ('{CanvasName}','{ellipse.Margin.Top}','{ellipse.Width}','{ellipse.Height}','{ellipse.Stroke.ToString()}','{ellipse.StrokeThickness}','{Ellicount}','{ellipse.Margin.Left}')";
                    db.SaveDB(query);
                    Ellicount++;
                }
            }
        }
        private void Load()
        {
            if(savelistbox.SelectedItem != null)
            {
                can.Children.Clear();
                string Canvasname = savelistbox.SelectedItem.ToString();
                LoadCanvas(Canvasname);
                //savelistbox.SelectedIndex = -1;
            }
        }
        private void LoadCanvas(string c)
        {
            DB db = DB.GetInstance();
            string query = $"Select Shape, ShapeNum from PictureObject where PictureName = '{c}'";
            List<DBObject> listdbo = db.SelectObjectDB(query);
            foreach (DBObject obj in listdbo)
            {
                switch (obj.Shapename)
                {
                    case "Line":
                        query = $"SELECT X1,X2,Y1,Y2,Stroke,StrokeThickness FROM PictureLine Where PictureName = {c} And LineNum = {obj.Shapenun}";
                        DBLine dbl = db.SelectLineDB(query);
                        Line line = new Line
                        {
                            X1 = dbl.X1,
                            Y1 = dbl.Y1,
                            X2 = dbl.X2,
                            Y2 = dbl.Y2,
                            Stroke = new SolidColorBrush((Color)ColorConverter.ConvertFromString(dbl.Stroke)),
                            StrokeThickness = double.Parse(dbl.StrokeThickness)
                        };
                        can.Children.Add(line);
                        break;
                    case "Rectangle":
                        query = $"SELECT MarginTop,Width,Height,Stroke,StrokeThickness,MarginLeft FROM PictureRectangle Where PictureName = {c} And RectNum = {obj.Shapenun}";
                        DBRectangle dbr = db.SelectRectDB(query);
                        Rectangle rect = new Rectangle
                        {
                            Margin = new Thickness(double.Parse(dbr.MarginLeft), double.Parse(dbr.MarginTop), 0, 0),
                            Width = dbr.Width,
                            Height = dbr.Height,
                            Stroke = new SolidColorBrush((Color)ColorConverter.ConvertFromString(dbr.Stroke)),
                            StrokeThickness = double.Parse(dbr.StrokeThickness)

                        };
                        can.Children.Add(rect);
                        break;
                    case "Polygon":
                        query = $"SELECT PointOne,Stroke,StrokeThickness,PointTwo,PointThree FROM PicturePolygon Where PictureName = {c} And PolyNum = {obj.Shapenun}";
                        DBPolygon dbp = db.SelectPolyDB(query);
                        PointCollection points = new PointCollection();
                        points.Add(Point.Parse(dbp.PointOne));
                        points.Add(Point.Parse(dbp.PointTwo));
                        points.Add(Point.Parse(dbp.PointThree));
                        Polygon polygon = new Polygon
                        {
                            Points = points,
                            Stroke = new SolidColorBrush((Color)ColorConverter.ConvertFromString(dbp.Stroke)),
                            StrokeThickness = double.Parse(dbp.StrokeThickness)
                        };
                        can.Children.Add(polygon);
                        break;
                    case "Ellipse":
                        query = $"SELECT MarginTop,Width,Height,Stroke,StrokeThickness,MarginLeft FROM PictureEllipse Where PictureName = {c} And ElliNum = {obj.Shapenun}";
                        DBEllipse dbe = db.SelectEliiDB(query);
                        Ellipse elli = new Ellipse
                        {
                            Margin = new Thickness(double.Parse(dbe.MarginLeft), double.Parse(dbe.MarginTop), 0, 0),
                            Width = dbe.Width,
                            Height = dbe.Height,
                            Stroke = new SolidColorBrush((Color)ColorConverter.ConvertFromString(dbe.Stroke)),
                            StrokeThickness = double.Parse(dbe.StrokeThickness)
                        };
                        can.Children.Add(elli);
                        break;
                }
            }

        }

        private void Search()
        {
            SubWindow sw = new SubWindow(0);
            sw.ShowDialog();
            
        }
        private void Naming()
        {
            SubWindow sw = new SubWindow(1);
            sw.ShowDialog();
            
        }
        private void Delete()
        {
            SubWindow sw = new SubWindow(2);
            sw.ShowDialog();
        }
        private void Reset()
        {
            can.Children.Clear();
        }
    }
}
