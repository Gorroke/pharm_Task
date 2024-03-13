using Microsoft.Expression.Interactivity.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PictuerDrawing
{
    public class DBClass
    {

    }
    public class DBObject
    {
        public string Shapename { get; set; }
        public int Shapenun {  get; set; }
        public DBObject(string name, int num)
        {
            Shapename = name;
            Shapenun = num;
        }
    }
    public class DBLine
    {
        public double X1 { get; set; }
        public double Y1 { get; set; }
        public double X2 { get; set; }
        public double Y2 { get; set; }
        public string Stroke { get; set; }
        public string StrokeThickness { get; set; }
        public DBLine(string x1, string y1, string x2, string y2, string strokecolor, string strokethickness)
        {
            X1 = Double.Parse(x1);
            Y1 = Double.Parse(y1);
            X2 = Double.Parse(x2);
            Y2 = Double.Parse(y2);
            Stroke = strokecolor;
            StrokeThickness = strokethickness;
        }
    }
    public class DBRectangle
    {
        public string MarginTop { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public string Stroke { get; set; }
        public string StrokeThickness { get; set;}
        public string MarginLeft { get; set; }
        public DBRectangle(string margin, string width, string height, string stroke, string strokeThickness, string marginLeft)
        {
            MarginTop = margin;
            Width = double.Parse(width);
            Height = double.Parse(height);
            Stroke = stroke;
            StrokeThickness = strokeThickness;
            MarginLeft = marginLeft;
        }
    }
    public class DBPolygon
    {
        public string PointOne { get; set; }
        public string Stroke { get; set; }
        public string StrokeThickness { get; set;}
        public string PointTwo { get; set; }
        public string PointThree { get; set; }
        public DBPolygon(string pointone, string stroke, string strokeThickness, string pointtwo, string pointthree)
        {
            PointOne = pointone;
            Stroke = stroke;
            StrokeThickness = strokeThickness;
            PointTwo = pointtwo;
            PointThree = pointthree;
        }
    }
    public class DBEllipse
    {
        public string MarginTop { get; set;}
        public double Width { get; set; }
        public double Height { get; set; }
        public string Stroke { get; set; }
        public string StrokeThickness { get; set;}
        public string MarginLeft { get; set; }
        public DBEllipse(string margintop, string width, string height, string stroke, string strokeThickness, string marginleft)
        {
            MarginTop = margintop;
            Width = double.Parse(width);
            Height = double.Parse(height);
            Stroke = stroke;
            StrokeThickness = strokeThickness;
            MarginLeft = marginleft;
        }
    }
    public class NameingPicture
    {
        private static NameingPicture instance = new NameingPicture();
        public static NameingPicture GetInstance()
        {
            if(instance == null)
            {
                instance = new NameingPicture();
            }
            return instance;
        }
        public string PictureName { get; set; }
    }
}
