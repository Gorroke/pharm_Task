using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace PictuerDrawing
{
    internal class SearchViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private Canvas can;
        private string searchname;
        public string SearchName
        {
            get { return searchname; }
            set { searchname = value; }
        }
        public ICommand SearchButton { get; set; }
        public SearchViewModel(Canvas canvas)
        {
            can = canvas;
            SearchButton = new RelayCommand(SearchDB);
        }
        private void SearchDB(object sender)
        {
            // DB에 그림 제목으로 찾아서 캔버스 그리고 찾아오기
            can.Children.Clear();
            DB db = DB.GetInstance();
            string query = $"SELECT Shape, ShapeNum FROM PictureObject Where PictureName = {SearchName}";
            List<DBObject> PictureObject = db.SelectObjectDB(query);
            foreach (DBObject obj in PictureObject)
            {
                switch (obj.Shapename)
                {
                    case "Line":
                        query = $"SELECT X1,X2,Y1,Y2,Stroke,StrokeThickness FROM PictureLine Where PictureName = {SearchName} And LineNum = {obj.Shapenun}";
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
                        query = $"SELECT MarginTop,Width,Height,Stroke,StrokeThickness,MarginLeft FROM PictureRectangle Where PictureName = {SearchName} And RectNum = {obj.Shapenun}";
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
                        query = $"SELECT PointOne,Stroke,StrokeThickness,PointTwo,PointThree FROM PicturePolygon Where PictureName = {SearchName} And PolyNum = {obj.Shapenun}";
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
                        query = $"SELECT MarginTop,Width,Height,Stroke,StrokeThickness,MarginLeft FROM PictureEllipse Where PictureName = {SearchName} And ElliNum = {obj.Shapenun}";
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

    }
}
