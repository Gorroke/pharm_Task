using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PictuerDrawing
{
    /// <summary>
    /// DrawingView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class DrawingView : UserControl
    {
        DrawingViewModel dvm;
        public DrawingView()
        {
            InitializeComponent();
            dvm = new DrawingViewModel(PictureCanvas, ListBox);
            this.DataContext = dvm;
        }
        private void OnListBoxItemDoubleClick(object sender, RoutedEventArgs e)
        {
            if (DataContext is DrawingViewModel viewModel && sender is ListBoxItem listBoxItem)
            {
                viewModel.listboxcommand.Execute(listBoxItem.DataContext);
            }
        }

        private void UserControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Z && Keyboard.Modifiers == ModifierKeys.Control)
            {
                dvm.UndoStack_Command();
            }
            if (e.Key == Key.Y && Keyboard.Modifiers == ModifierKeys.Control)
            {
                dvm.RedoStack_Command();
            }
        }
    }
}
