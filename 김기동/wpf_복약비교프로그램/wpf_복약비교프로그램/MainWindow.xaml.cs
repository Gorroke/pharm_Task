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
using static wpf_복약비교프로그램.MainViewModel;

namespace wpf_복약비교프로그램
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            DateTime? startDate = FirstDate.SelectedDate;
            DateTime? endDate = SecondDate.SelectedDate;
            if (startDate.HasValue && endDate.HasValue)
            {
                MainViewModel viewModel = new MainViewModel();
                viewModel.Load_PRES(startDate.Value, endDate.Value, DG_Pres);
            }
            else
            {
                MessageBox.Show("시작일과 종료일을 선택하세요.");
            }
        }

        private void DG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DG_Pres.SelectedItem != null)
            {
                //PrescriptionData selectedPrescription = (PrescriptionData)DG_Pres.SelectedItem;
                MainViewModel mainViewModel = new MainViewModel();
                mainViewModel.Load_CusPres(e, DG_Custom, DG_Pres);
            }

        }
    }
}
