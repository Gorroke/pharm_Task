using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using wpf_그림판.Model;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Input;
using System.Windows;

namespace wpf_그림판.ViewModel
{
    internal class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        //protected void OnpropertyChanged(string name)
        //{
        //    PropertyChangedEventHandler propertyChangedEventHandler = PropertyChanged;
        //    if (propertyChangedEventHandler != null)
        //    {
        //        propertyChangedEventHandler(this, new PropertyChangedEventArgs(name));
        //    }
        //}
        public MainViewModel()
        {
            // 초기화 코드 추가
            Canvas canvas = new Canvas();
            model = new Model.MainModel(canvas);
            model.isDrawing = false;

            MyCommand = new RelayCommand(MyMouseDown);
            CMD_CanvasLeftDown = new RelayCommand(CanvasLeftDown);
            CMD_MouseMove = new RelayCommand(MouseMove);
            CMD_CanvaLeftUp = new RelayCommand(CanvaLeftUp);
        }
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public ICommand MyCommand { get; set; }
        public ICommand CMD_CanvasLeftDown { get; set; }
        public ICommand CMD_MouseMove { get; set; }
        public ICommand CMD_CanvaLeftUp { get; set; }

        private void MyMouseDown(object obj)
        {
            //if (obj is Canvas c)
            //{
            //    if(Model.isDrawing)
            //    {
            //        Point p = Mouse.GetPosition(App.Current.MainWindow);
            //        Model.startPoint = p;
            //    }
            //}
        }

        private void CanvasLeftDown(object sender)
        {
            if (sender is Canvas c)
            {
                Model.isDrawing = true;

                Point p = Mouse.GetPosition(App.Current.MainWindow);
                Model.startPoint = p;
            }
        }

        private void MouseMove(object sender)
        {
            if (Model.isDrawing && sender is Canvas c)
            {
                Line line = new Line();
                line.Stroke = PenColor;
                line.StrokeThickness = 2;
                line.X1 = Model.startPoint.X;
                line.Y1 = model.startPoint.Y;

                Point p = Mouse.GetPosition(App.Current.MainWindow);

                line.X2 = p.X;
                line.Y2 = p.Y;

                c.Children.Add(line);

                Model.startPoint = p;

                int zIdx = c.Children.Count;
                Canvas.SetZIndex(line, zIdx);
            }
        }

        public void CanvaLeftUp(object sender)
        {
            Model.isDrawing = false;
            //if (sender is Canvas c)
            //{
            //    Model.isDrawing = false;

            //    Line line = new Line();
            //    line.Stroke = PenColor;
            //    line.StrokeThickness = 2;
            //    line.X1 = Model.startPoint.X;
            //    line.Y1 = Model.startPoint.Y;

            //    Point p = Mouse.GetPosition(App.Current.MainWindow);
            //    line.X2 = p.X + 10;
            //    line.Y2 = p.Y + 10;

            //    c.Children.Add(line);

            //    int zIdx = c.Children.Count;
            //    Canvas.SetZIndex(line, zIdx);
            //}

        }



        private MainModel model;

        public MainModel Model
        {
            get { return model; }
            set
            {
                if (model != value)
                {
                    model = value;
                    OnPropertyChanged(nameof(Model));
                }
            }
        }

        private List<SolidColorBrush> penColors = new List<SolidColorBrush>
        {
            new SolidColorBrush(Colors.Black),
            new SolidColorBrush(Colors.Red),
            new SolidColorBrush(Colors.Blue),
            new SolidColorBrush(Colors.Green),
            new SolidColorBrush(Colors.Yellow)
        };
        public List<SolidColorBrush> PenColors
        {
            get { return penColors; }
            set
            {
                if (penColors != value)
                {
                    penColors = value;
                    OnPropertyChanged(nameof(PenColors));
                }
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
                    //Model.PenColor = value;
                    OnPropertyChanged(nameof(PenColor));
                }
            }
        }
        public ICommand DrawRectangleCommand { get; }
        public ICommand DrawEllipseCommand { get; }

        public MainViewModel(Canvas canvas)
        {
            Model = new MainModel(canvas);

            // 네모 그리기 명령
            DrawRectangleCommand = new RelayCommand(
                param => Model.DrawRectangle(),
                param => true);

            // 원 그리기 명령
            DrawEllipseCommand = new RelayCommand(
                param => Model.DrawEllipse(),
                param => true);
        }
        //public MainViewModel(Canvas canvas)
        //{
        //    // 네모 그리기 명령
        //    DrawRectangleCommand = new RelayCommand(
        //        param => Model.DrawRectangle(),
        //        param => true);

        //    // 원 그리기 명령
        //    DrawEllipseCommand = new RelayCommand(
        //        param => Model.DrawEllipse(),
        //        param => true);
        //}

        public void Canvas_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
        }

    }

    public class RelayCommand : ICommand
    {
        private readonly Action<object> execute;
        private readonly Predicate<object> canExecute;

        public RelayCommand(Action<object> execute, Predicate<object> canExecute = null)
        {
            this.execute = execute ?? throw new ArgumentNullException(nameof(execute));
            this.canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return canExecute == null || canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            execute(parameter);
        }
    }

}
