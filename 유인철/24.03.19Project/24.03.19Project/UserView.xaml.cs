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
                userViewModel.SelectedDates();
            }
        }

        private void ListViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            PDRUDRUG = null;
            PCUSCUST = null;
            if (DataContext is UserViewModel userViewModel)
            {
                if(PPRESCR.SelectedItems != null)
                {
                    string Pres_id = PPRESCR.SelectedItems[0].ToString();
                    userViewModel.SelectedPDRUDRUG(Pres_id);
                    userViewModel.SelectedPCUSCUST(Pres_id);
                }
            }
        }
    }
}
