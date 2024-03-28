using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography;
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
using System.Windows.Threading;

namespace _24._03._19Project
{
    /// <summary>
    /// UserView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class UserView : UserControl
    {
        public UserView()
        {
            InitializeComponent();
        }

        private void SelectDate_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            if(DataContext is UserViewModel userViewModel)
            {
                userViewModel.PDRUDRUGList = new ObservableCollection<Medicine>();
                userViewModel.SelectedDates();
            }
        }

        private void ListViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (DataContext is UserViewModel userViewModel && PPRESCR.SelectedIndex != -1)
            {
                userViewModel.PDRUDRUGList = new ObservableCollection<Medicine>();
                userViewModel.SelectedPDRUDRUG(PPRESCR.SelectedIndex);
            }
        }

        private void PPRESCR_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataContext is UserViewModel userViewModel && PPRESCR.SelectedIndex != -1)
            {
                userViewModel.PDRUDRUGList = new ObservableCollection<Medicine>();
                userViewModel.SelectedPDRUDRUG(PPRESCR.SelectedIndex);
                userViewModel.SelectedHS_INFO(PPRESCR.SelectedIndex);
            }
        }

        private void PDRUDRUG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(DataContext is UserViewModel userViewModel && PDRUDRUG.SelectedIndex != -1)
            {
                userViewModel.SelectedDrugInfoName(PDRUDRUG.SelectedIndex);
            }
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if(DataContext is UserViewModel userViewModel && PDRUDRUG.SelectedIndex != -1)
            {
                string checkstring = "";
                RadioButton rb = sender as RadioButton;
                foreach (CheckBox cbx in Checkboxlist.Children.OfType<CheckBox>())
                {
                    if(cbx.IsChecked == true)
                    {
                        checkstring += cbx.Content.ToString() + ' ';
                        cbx.IsChecked = false;
                    }
                }
                userViewModel.Usage1Changed(PDRUDRUG.SelectedIndex, checkstring, rb.Content.ToString());
                rb.IsChecked = false;
                PDRUDRUG.Items.Refresh();
            }
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            if (DataContext is UserViewModel userViewModel && PDRUDRUG.SelectedIndex != -1) 
            {
                RadioButton rb = sender as RadioButton;
                userViewModel.Usage2Changed(PDRUDRUG.SelectedIndex, rb.Content.ToString());
                PDRUDRUG.Items.Refresh();
            }
        }

        private void PDRUDRUG_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            if (DataContext is UserViewModel userViewModel && PDRUDRUG.SelectedIndex != -1)
            {
                userViewModel.CellChangeAction(PDRUDRUG.SelectedIndex);
            }
            DataGrid grid = sender as DataGrid;
            grid.Dispatcher.BeginInvoke(new Action(() =>
            {
                grid.Items.Refresh();
            }), DispatcherPriority.Background); // 수정 트랜잭션이 완료된 후에 실행하는 코드
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            int i = 0;
            TextBox tb = sender as TextBox;
            string te = tb.Text;
            bool result = int.TryParse(te, out i);
            if(DataContext is UserViewModel userViewModel && result)
            {
                userViewModel.BagMedicineAllDrug();
            }
        }
    }
}
