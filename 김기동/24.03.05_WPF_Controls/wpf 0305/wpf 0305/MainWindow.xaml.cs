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

namespace wpf_0305
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Customer> dummyCustomer = new List<Customer>();
        class Customer
        {
            public string Name {  get; set; }
            public string Gender {  get; set; }
            public string Birth {  get; set; }

            public Customer(string name, string gender, string birth)
            {
                Name = name;
                Gender = gender;
                Birth = birth;
            }
        }
        public void Dummy()
        {
            // 더미 데이터 추가
            dummyCustomer.Add(new Customer("김기동", "남", "990506"));
            dummyCustomer.Add(new Customer("박기동", "남", "000506"));
            dummyCustomer.Add(new Customer("신기동", "남", "010506"));
        }
        public MainWindow()
        {
            InitializeComponent();
            Dummy();
            DG.ItemsSource = dummyCustomer;
            DG.SelectedItem = dummyCustomer[0];
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            string searchText = TB.Text;
            foreach (var customer in dummyCustomer)
            {
                if (customer.Name == searchText)
                {
                    DG.SelectedItem = customer;
                    return;
                }
            }
            MessageBox.Show("검색 결과가 없습니다.");
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            if (DG.SelectedItem != null)
            {
                Customer selectedCustomer = (Customer)DG.SelectedItem;
                selectedCustomer.Name = TB.Text;
                UpdateDataGrid();
            }
            else
            {
                MessageBox.Show("수정할 항목을 선택하세요.");
            }
        }

        /// <summary>
        /// DataGrid 초기화
        /// </summary>
        private void UpdateDataGrid()
        {
            CollectionViewSource.GetDefaultView(DG.ItemsSource).Refresh();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (DG.SelectedItem != null)
            {
                Customer selectedCustomer = (Customer)DG.SelectedItem;
                dummyCustomer.Remove(selectedCustomer);

                UpdateDataGrid();
            }
            else
            {
                MessageBox.Show("삭제할 항목을 선택하세요.");
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(TB.Text))
            {
                string[] words = TB.Text.Split(',');
                if(words.Length == 3)
                {
                Customer newCustomer = new Customer(words[0], words[1], words[2]);

                dummyCustomer.Add(newCustomer);

                }
                else
                {
                    MessageBox.Show("입력을 확인해주세요");
                }
                // 새로운 고객 생성
                UpdateDataGrid();

            }
            else
            {
                MessageBox.Show("고객 정보를 입력하세요.");
            }
        }

    }
}
