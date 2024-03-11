using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using wpf_그림판.ViewModel;

namespace wpf_그림판
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            MainViewModel viewModel = new MainViewModel(canvas);

            this.DataContext = viewModel;
            //canvas.PreviewMouseLeftButtonDown += viewModel.Canvas_PreviewMouseLeftButtonDown;

        }

        //private void LeftButtonUp(object sender, MouseButtonEventArgs e)
        //{

        //}

        //private void LeftButtonDown(object sender, MouseButtonEventArgs e)
        //{

        //}

        private void ComboBoxItem_Selected(object sender, RoutedEventArgs e)
        {

        }


        //private void Canvas_MouseMove(object sender, MouseEventArgs e)
        //{
        //    if (Model != null && Model.Canvas != null)
        //    {
        //        Model.Canvas_MouseMove(sender, e);
        //    }
        //}

        //private void Canvas_MouseMove(object sender, MouseEventArgs e)
        //{
        //    if (DataContext is MainViewModel viewModel && viewModel.Model != null)
        //    {
        //        viewModel.Model.Canvas_MouseMove(sender, e);
        //    }
        //}
    }
}
