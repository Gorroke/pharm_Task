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

namespace _24._03._05_WPF_Controls_Project
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Customer> CustomersList = new List<Customer>();
        public MainWindow()
        {
            InitializeComponent();
            Dummy_Data_Create();
            datagrid.ItemsSource = CustomersList;
        }

        public void Dummy_Data_Create()
        {
            CustomersList.Add(new Customer() { Name = "유인철", Sex = "남성", Date_of_birth = "990628" });
            CustomersList.Add(new Customer() { Name = "김기동", Sex = "남성", Date_of_birth = "990506" });
            CustomersList.Add(new Customer() { Name = "최원민", Sex = "남성", Date_of_birth = "000109" });
        }
    }
}
