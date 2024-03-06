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
        public List<Customer> CustomersList = new List<Customer>();
        Customer SelectedCustomer { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            Dummy_Data_Create();
            datagrid.ItemsSource = CustomersList;
            SelectedCustomer = CustomersList[0];
            datagrid.SelectedItem = SelectedCustomer;
        }

        public void Dummy_Data_Create()
        {
            CustomersList.Add(new Customer() { Name = "유인철", Sex = "남성", Date_of_birth = "990628" });
            CustomersList.Add(new Customer() { Name = "유인철", Sex = "남성", Date_of_birth = "990628" });
            CustomersList.Add(new Customer() { Name = "김기동", Sex = "남성", Date_of_birth = "990506" });
            CustomersList.Add(new Customer() { Name = "최원민", Sex = "남성", Date_of_birth = "000109" });
        }

        private void Search_Click(object sender, RoutedEventArgs e) // 검색
        {
            Search search = new Search();
            search.ShowDialog();
            if(search.OK_Cancel)
            {
                datagrid.ItemsSource = null;
                var result = CustomersList.FindAll(x => x.Name == search.SearchName);
                datagrid.ItemsSource = result;
            }
        }

        private void Correction_Click(object sender, RoutedEventArgs e) // 수정
        {
            if(datagrid.SelectedItem != null)
            {
                Customer result = (Customer)datagrid.SelectedItem;
                Correction correction = new Correction();
                correction.CorrectionName = result.Name;
                correction.CorrectionSex = result.Sex;
                correction.CorrectionBirth = result.Date_of_birth;

                correction.ShowDialog();
                if(correction.OK_Cancel)
                {
                    result.Name = correction.CorrectionName;
                    result.Sex = correction.CorrectionSex;
                    result.Date_of_birth = correction.CorrectionBirth;
                    datagrid.Items.Refresh();
                }
            }
            else
            {
                MessageBox.Show("선택된 정보가 없습니다.");
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e) // 삭제
        {
            Delete delete = new Delete();
            delete.ShowDialog();
            if(delete.OK_Cancel)
            {
                datagrid.ItemsSource = null;
                var result = CustomersList.Where(x => x.Name != delete.DeleteName).ToList();
                datagrid.ItemsSource = result;
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e) // 추가
        {
            Add add = new Add();
            add.ShowDialog();
            if(add.OK_Cancel)
            {
                datagrid.ItemsSource = null;
                CustomersList.Add(new Customer() { Name = add.Addname, Sex = add.Addsex, Date_of_birth = add.Addbirth });
                datagrid.ItemsSource = CustomersList;
            }
        }

        private void Reset_Click(object sender, RoutedEventArgs e) // 초기화
        {
            datagrid.ItemsSource = null;
            datagrid.ItemsSource = CustomersList;
        }
    }
}
